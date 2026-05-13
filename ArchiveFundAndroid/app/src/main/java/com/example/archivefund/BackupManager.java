package com.example.archivefund;

import android.app.Activity;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.Environment;
import android.provider.MediaStore;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AlertDialog;

import com.example.archivefund.DatabaseHelper;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;
public class BackupManager {
    private final Context context;
    private final DatabaseHelper dbHelper;

    public BackupManager(Context context) {
        this.context = context;
        this.dbHelper = new DatabaseHelper(context);
    }

    // Создание резервной копии с выбором имени
    public void createBackup() {
        String defaultName = "backup_" + new SimpleDateFormat("yyyyMMdd_HHmmss", Locale.getDefault()).format(new Date()) + ".sql";
        EditText input = new EditText(context);
        input.setText(defaultName);
        new AlertDialog.Builder(context)
                .setTitle("Имя файла резервной копии")
                .setMessage("Введите имя файла (расширение .sql)")
                .setView(input)
                .setPositiveButton("Создать", (dialog, which) -> {
                    String fileName = input.getText().toString().trim();
                    if (fileName.isEmpty()) fileName = defaultName;
                    if (!fileName.endsWith(".sql")) fileName += ".sql";
                    performBackup(fileName);
                })
                .setNegativeButton("Отмена", null)
                .show();
    }

    private void performBackup(String fileName) {
        try {
            OutputStream outputStream = null;
            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.Q) {
                // Для Android 10+ используем MediaStore
                ContentValues values = new ContentValues();
                values.put(MediaStore.MediaColumns.DISPLAY_NAME, fileName);
                values.put(MediaStore.MediaColumns.MIME_TYPE, "application/sql");
                values.put(MediaStore.MediaColumns.RELATIVE_PATH, Environment.DIRECTORY_DOWNLOADS);
                Uri uri = context.getContentResolver().insert(MediaStore.Files.getContentUri("external"), values);
                if (uri != null) {
                    outputStream = context.getContentResolver().openOutputStream(uri);
                } else {
                    Toast.makeText(context, "Не удалось создать файл в Загрузках", Toast.LENGTH_SHORT).show();
                    return;
                }
            } else {
                // Для старых версий Android
                File downloadDir = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS);
                if (!downloadDir.exists() && !downloadDir.mkdirs()) {
                    Toast.makeText(context, "Не удалось получить доступ к папке Загрузки", Toast.LENGTH_SHORT).show();
                    return;
                }
                File backupFile = new File(downloadDir, fileName);
                outputStream = new FileOutputStream(backupFile);
            }

            StringBuilder sql = new StringBuilder();
            // Добавляем структуру и данные всех таблиц
            exportTable(sql, DatabaseHelper.TABLE_USER);
            exportTable(sql, DatabaseHelper.TABLE_GROUP);
            exportTable(sql, DatabaseHelper.TABLE_STUDENT);
            exportTable(sql, DatabaseHelper.TABLE_DOCUMENT_TYPES);
            exportTable(sql, DatabaseHelper.TABLE_BOXES);
            exportTable(sql, DatabaseHelper.TABLE_DOCUMENTS);
            exportTable(sql, DatabaseHelper.TABLE_DELETED_DOCUMENTS);
            exportTable(sql, DatabaseHelper.TABLE_STUDENTS_PERS_FILES);
            exportTable(sql, DatabaseHelper.TABLE_DELETED_STUDENTS_PERS_FILES);

            outputStream.write(sql.toString().getBytes());
            outputStream.close();

            Toast.makeText(context, "Резервная копия сохранена в Загрузки: " + fileName, Toast.LENGTH_LONG).show();
        } catch (Exception e) {
            Toast.makeText(context, "Ошибка при создании резервной копии: " + e.getMessage(), Toast.LENGTH_LONG).show();
            e.printStackTrace();
        }
    }

    // Экспорт одной таблицы (данные + структура)
    private void exportTable(StringBuilder sql, String tableName) {
        SQLiteDatabase db = dbHelper.getReadableDatabase();
        // Экспортируем только данные, без CREATE TABLE
        Cursor cursor = db.query(tableName, null, null, null, null, null, null);
        if (cursor.moveToFirst()) {
            do {
                sql.append("INSERT INTO ").append(tableName).append(" VALUES (");
                for (int i = 0; i < cursor.getColumnCount(); i++) {
                    if (i > 0) sql.append(",");
                    String value = cursor.getString(i);
                    if (value == null) {
                        sql.append("NULL");
                    } else {
                        sql.append("'").append(value.replace("'", "''")).append("'");
                    }
                }
                sql.append(");\n");
            } while (cursor.moveToNext());
        }
        cursor.close();
        sql.append("\n");
    }

    // Запуск выбора файла для восстановления (использует старый startActivityForResult)
    public void startRestore(Activity activity, int requestCode) {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT);  // вместо ACTION_OPEN_DOCUMENT
        intent.addCategory(Intent.CATEGORY_OPENABLE);
        intent.setType("*/*");
        // Можно указать MIME-типы для фильтрации
        String[] mimeTypes = {"application/sql", "text/plain", "*/*"};
        intent.putExtra(Intent.EXTRA_MIME_TYPES, mimeTypes);
        activity.startActivityForResult(intent, requestCode);
    }

    // Обработка результата выбора файла (вызывается из onActivityResult)
    public void handleRestoreResult(int resultCode, Intent data, Runnable onSuccess) {
        if (resultCode == Activity.RESULT_OK && data != null) {
            Uri uri = data.getData();
            if (uri != null) {
                restoreFromUri(uri, onSuccess);
            } else {
                Toast.makeText(context, "Файл не выбран", Toast.LENGTH_SHORT).show();
            }
        }
    }

    private void restoreFromUri(Uri uri, Runnable onSuccess) {
        new AlertDialog.Builder(context)
                .setTitle("Восстановление")
                .setMessage("Внимание! Все текущие данные будут заменены. Продолжить?")
                .setPositiveButton("Восстановить", (dialog, which) -> {
                    try (InputStream inputStream = context.getContentResolver().openInputStream(uri);
                         BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream))) {
                        StringBuilder sql = new StringBuilder();
                        String line;
                        while ((line = reader.readLine()) != null) {
                            sql.append(line).append("\n");
                        }
                        executeSqlScript(sql.toString());
                        if (onSuccess != null) onSuccess.run();
                        Toast.makeText(context, "Восстановление завершено", Toast.LENGTH_LONG).show();
                    } catch (Exception e) {
                        Toast.makeText(context, "Ошибка восстановления: " + e.getMessage(), Toast.LENGTH_LONG).show();
                        e.printStackTrace();
                    }
                })
                .setNegativeButton("Отмена", null)
                .show();
    }

    // Выполняет SQL‑скрипт (очищает таблицы и заполняет)
    private void executeSqlScript(String script) {
        SQLiteDatabase db = dbHelper.getWritableDatabase();
        db.beginTransaction();
        try {
            // Удаляем все данные из всех таблиц (структуру оставляем)
            String[] tables = {
                    DatabaseHelper.TABLE_DELETED_STUDENTS_PERS_FILES,
                    DatabaseHelper.TABLE_STUDENTS_PERS_FILES,
                    DatabaseHelper.TABLE_DELETED_DOCUMENTS,
                    DatabaseHelper.TABLE_DOCUMENTS,
                    DatabaseHelper.TABLE_BOXES,
                    DatabaseHelper.TABLE_DOCUMENT_TYPES,
                    DatabaseHelper.TABLE_STUDENT,
                    DatabaseHelper.TABLE_GROUP,
                    DatabaseHelper.TABLE_USER
            };
            for (String table : tables) {
                db.execSQL("DELETE FROM " + table);
                // Сброс автоинкремента (опционально)
                db.execSQL("DELETE FROM sqlite_sequence WHERE name='" + table + "'");
            }

            // Выполняем скрипт (разделяем по ';')
            String[] statements = script.split(";");
            for (String stmt : statements) {
                String trimmed = stmt.trim();
                if (!trimmed.isEmpty()) {
                    db.execSQL(trimmed);
                }
            }
            db.setTransactionSuccessful();
        } finally {
            db.endTransaction();
            db.close();
        }
    }
}
