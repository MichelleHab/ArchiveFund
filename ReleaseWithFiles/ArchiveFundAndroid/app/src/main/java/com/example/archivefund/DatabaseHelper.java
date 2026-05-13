package com.example.archivefund;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Environment;

import androidx.annotation.Nullable;
import android.content.ContentValues;
import android.content.Context;
import android.text.TextUtils;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import com.example.archivefund.*;
public class DatabaseHelper extends SQLiteOpenHelper {
    private static final String DATABASE_NAME = "archive_fund.db";
    private static final int DATABASE_VERSION = 11;

    // Таблицы
    public static final String TABLE_USER = "User";
    public static final String TABLE_STUDENT = "Student";
    public static final String TABLE_GROUP = "Groups";
    public static final String TABLE_DOCUMENTS = "Documents";
    public static final String TABLE_DELETED_DOCUMENTS = "DeletedDocuments";
    public static final String TABLE_BOXES = "Boxes";
    public static final String TABLE_DOCUMENT_TYPES = "DocumentTypes";
    public static final String TABLE_STUDENTS_PERS_FILES = "StudentsPersFiles";
    public static final String TABLE_DELETED_STUDENTS_PERS_FILES = "DeletedStudentsPersFiles";

    private static final String KEY_CREATED_AT = "created_at";

    public DatabaseHelper(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
        this.context = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // Создание таблицы User
        String CREATE_USER_TABLE = "CREATE TABLE " + TABLE_USER + "("
                + "user_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "FIO TEXT,"
                + "role TEXT,"
                + "login TEXT UNIQUE,"
                + "password TEXT,"
                + KEY_CREATED_AT + " DATETIME DEFAULT CURRENT_TIMESTAMP"
                + ")";
        db.execSQL(CREATE_USER_TABLE);

        // Создание таблицы Group
        String CREATE_GROUP_TABLE = "CREATE TABLE " + TABLE_GROUP + "("
                + "group_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "group_name TEXT NOT NULL,"
                + "formation_year INTEGER,"
                + "specialization TEXT"
                + ")";
        db.execSQL(CREATE_GROUP_TABLE);

        // Создание таблицы Student
        String CREATE_STUDENT_TABLE = "CREATE TABLE " + TABLE_STUDENT + "("
                + "student_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "full_name TEXT NOT NULL,"
                + "group_id INTEGER,"
                + "FOREIGN KEY(group_id) REFERENCES " + TABLE_GROUP + "(group_id) ON DELETE SET NULL"
                + ")";
        db.execSQL(CREATE_STUDENT_TABLE);

        // Создание таблицы DocumentTypes
        String CREATE_DOCUMENT_TYPES_TABLE = "CREATE TABLE " + TABLE_DOCUMENT_TYPES + "("
                + "type_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "type_name TEXT NOT NULL"
                + ")";
        db.execSQL(CREATE_DOCUMENT_TYPES_TABLE);

        // Создание таблицы Boxes
        String CREATE_BOXES_TABLE = "CREATE TABLE " + TABLE_BOXES + "("
                + "box_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "box_name TEXT,"
                + "rack_number INTEGER,"
                + "shelf_number INTEGER,"
                + "group_id INTEGER,"
                + "type_id INTEGER,"
                + "year_work INTEGER,"
                + "FOREIGN KEY(group_id) REFERENCES " + TABLE_GROUP + "(group_id) ON DELETE SET NULL,"
                + "FOREIGN KEY(type_id) REFERENCES " + TABLE_DOCUMENT_TYPES + "(type_id)"
                + ")";
        db.execSQL(CREATE_BOXES_TABLE);

        // Создание таблицы Documents
        String CREATE_DOCUMENTS_TABLE = "CREATE TABLE " + TABLE_DOCUMENTS + "("
                + "doc_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "document_subject TEXT NOT NULL,"
                + "start_data INTEGER,"
                + "type_id INTEGER,"
                + "Supervisor_full_name TEXT,"
                + "student_id INTEGER,"
                + "box_id INTEGER,"
                + "FOREIGN KEY(type_id) REFERENCES " + TABLE_DOCUMENT_TYPES + "(type_id),"
                + "FOREIGN KEY(student_id) REFERENCES " + TABLE_STUDENT + "(student_id) ON DELETE CASCADE,"
                + "FOREIGN KEY(box_id) REFERENCES " + TABLE_BOXES + "(box_id)"
                + ")";
        db.execSQL(CREATE_DOCUMENTS_TABLE);

        // Создание таблицы DeletedDocuments
        String CREATE_DELETED_DOCUMENTS_TABLE = "CREATE TABLE " + TABLE_DELETED_DOCUMENTS + "("
                + "doc_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "document_subject TEXT NOT NULL,"
                + "start_data INTEGER,"
                + "type_id INTEGER,"
                + "Supervisor_full_name TEXT,"
                + "student_id INTEGER,"
                + "box_id INTEGER"
                + ")";
        db.execSQL(CREATE_DELETED_DOCUMENTS_TABLE);

        // Создание таблицы StudentsPersFiles
        String CREATE_STUDENTS_PERS_FILES_TABLE = "CREATE TABLE " + TABLE_STUDENTS_PERS_FILES + "("
                + "pers_file_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "admission_year INTEGER,"
                + "deduction_year INTEGER,"
                + "reason TEXT,"
                + "student_id INTEGER,"
                + "FOREIGN KEY(student_id) REFERENCES " + TABLE_STUDENT + "(student_id) ON DELETE CASCADE"
                + ")";
        db.execSQL(CREATE_STUDENTS_PERS_FILES_TABLE);

        // Создание таблицы DeletedStudentsPersFiles
        String CREATE_DELETED_STUDENTS_PERS_FILES_TABLE = "CREATE TABLE " + TABLE_DELETED_STUDENTS_PERS_FILES + "("
                + "pers_file_id INTEGER PRIMARY KEY AUTOINCREMENT,"
                + "admission_year INTEGER,"
                + "deduction_year INTEGER,"
                + "reason TEXT,"
                + "student_id INTEGER"
                + ")";
        db.execSQL(CREATE_DELETED_STUDENTS_PERS_FILES_TABLE);

        // Вставка начальных данных
        insertInitialData(db);
    }

    private void insertInitialData(SQLiteDatabase db) {
        // Вставка типов документов
        /*String[] documentTypes = {"Дипломная работа", "Курсовая работа", "Отчет по практике"};
        for (String type : documentTypes) {
            ContentValues values = new ContentValues();
            values.put("type_name", type);
            db.insert(TABLE_DOCUMENT_TYPES, null, values);
        }

        // Вставка групп
        String[][] groups = {{"ИС-41", "Информационные системы"}, {"ПИ-41", "Программная инженерия"}};
        for (String[] group : groups) {
            ContentValues values = new ContentValues();
            values.put("group_name", group[0]);
            values.put("formation_year", 2020);
            values.put("specialization", group[1]);
            db.insert(TABLE_GROUP, null, values);
        }

        // Вставка администратора по умолчанию
        ContentValues values = new ContentValues();
        values.put("FIO", "Администратор");
        values.put("role", "Admin");
        values.put("login", "admin");
        values.put("password", hashPassword("admin123"));
        db.insert(TABLE_USER, null, values);*/
        // ==================== Типы документов ====================
        String[][] documentTypes = {
                {"1", "Дипломная работа"},
                {"2", "Курсовая работа"},
                {"3", "Отчет по практике"}
        };
        for (String[] type : documentTypes) {
            ContentValues values = new ContentValues();
            values.put("type_id", type[0]);
            values.put("type_name", type[1]);
            db.insert(TABLE_DOCUMENT_TYPES, null, values);
        }

        // ==================== Группы ====================
        String[][] groups = {
                {"1", "ИП3", "2023", "09.02.07 Информационные системы и программирование"},
                {"2", "ИС3-Б", "2023", "09.02.07 Разработка веб и мультимедийных приложений"},
                {"3", "Ф3-А", "2023", "33.02.01 Фармация (на базе 9 классов)"},
                {"4", "Ф3-Б", "2023", "33.02.07 Фармация (на базе 11 классов)"},
                {"5", "Э3", "2023", "38.02.01 Экономика и бухгалтерский учет"},
                {"6", "ПД3-Г", "2023", "40.02.02 Правоохранительная деятельность"},
                {"7", "Т3-А", "2023", "43.02.13 Технология парикмахерского искусства"},
                {"8", "Д3-В", "2023", "44.02.02 Дошкольное образование"},
                {"9", "Н3-Д", "2023", "44.02.02 Преподавание в начальных классах"}
        };
        for (String[] group : groups) {
            ContentValues values = new ContentValues();
            values.put("group_id", group[0]);
            values.put("group_name", group[1]);
            values.put("formation_year", group[2]);
            values.put("specialization", group[3]);
            db.insert(TABLE_GROUP, null, values);
        }

        // ==================== Студенты ====================
        String[][] students = {
                {"1", "Иванов А.С.", "1"},
                {"2", "Петров Б.В.", "2"},
                {"3", "Сидорова Е.М.", "3"},
                {"4", "Козлов Д.И.", "4"},
                {"5", "Новикова О.П.", "5"},
                {"6", "Смирнов К.Л.", "6"},
                {"7", "Васильева Н.Т.", "7"},
                {"8", "Морозов Р.Ю.", "8"},
                {"9", "Лебедева Т.А.", "9"}
        };
        for (String[] student : students) {
            ContentValues values = new ContentValues();
            values.put("student_id", student[0]);
            values.put("full_name", student[1]);
            values.put("group_id", student[2]);
            db.insert(TABLE_STUDENT, null, values);
        }

        // ==================== Коробки ====================
        String[][] boxes = {
                {"1", "А1", "1", "1", "1", "1", "2024"},
                {"2", "А2", "1", "2", "2", "2", "2024"},
                {"3", "А3", "1", "3", "3", "3", "2024"},
                {"4", "Б1", "2", "1", "4", "1", "2024"},
                {"5", "Б2", "2", "2", "5", "1", "2024"},
                {"6", "Б3", "2", "3", "6", "2", "2024"},
                {"7", "В1", "3", "1", "7", "3", "2024"},
                {"8", "В2", "3", "2", "8", "1", "2024"},
                {"9", "В3", "3", "3", "9", "1", "2024"}
        };
        for (String[] box : boxes) {
            ContentValues values = new ContentValues();
            values.put("box_id", box[0]);
            values.put("box_name", box[1]);
            values.put("rack_number", box[2]);
            values.put("shelf_number", box[3]);
            values.put("group_id", box[4]);
            values.put("type_id", box[5]);
            values.put("year_work", box[6]);
            db.insert(TABLE_BOXES, null, values);
        }

        // ==================== Активные документы ====================
        String[][] documents = {
                {"1", "Разработка веб-приложения", "2022", "1", "Скрыльников Дмитрий Константинович", "1", "1"},
                {"2", "Анализ алгоритмов", "2023", "2", "Нуралиева Ирина Евгеньевна", "2", "2"},
                {"3", "Отчет ООО \"Техно\"", "2024", "3", "Федусева Элла Юрьевна", "3", "3"},
                {"4", "История права", "2023", "1", "Нуралиев Арсен Абдулжалилович", "4", "4"},
                {"5", "Машинное обучение", "2023", "1", "Стрельцова Анна Федоровна", "5", "5"},
                {"6", "Квантовая физика", "2023", "2", "Ермольчев Константин Васильевич", "6", "6"},
                {"7", "Органический синтез", "2023", "2", "Кирюхина Оксана Юрьевна", "7", "7"},
                {"8", "Генетика человека", "2023", "3", "Дудник Наталья Борисовна", "8", "8"},
                {"9", "Археология Гуси", "2023", "2", "Попова Вероника Владимировна", "9", "9"}
        };
        for (String[] doc : documents) {
            ContentValues values = new ContentValues();
            values.put("doc_id", doc[0]);
            values.put("document_subject", doc[1]);
            values.put("start_data", doc[2]);
            values.put("type_id", doc[3]);
            values.put("Supervisor_full_name", doc[4]);
            values.put("student_id", doc[5]);
            values.put("box_id", doc[6]);
            db.insert(TABLE_DOCUMENTS, null, values);
        }

        // ==================== УДАЛЕННЫЕ ДОКУМЕНТЫ ====================
        String[][] deletedDocuments = {
                {"1", "Старая версия диплома", "2022", "1", "Скрыльников Дмитрий Константинович", "1", "1"},
                {"2", "курсовая 1", "2023", "2", "Нуралиева Ирина Евгеньевна", "2", "2"},
                {"3", "Предварительный отчет", "2024", "3", "Федусева Элла Юрьевна", "3", "3"},
                {"4", "Неактуальный реферат", "2023", "2", "Нуралиев Арсен Абдулжалилович", "4", "4"},
                {"5", "Дубликат диплома", "2023", "2", "Стрельцова Анна Федоровна", "5", "5"},
                {"6", "Устаревшая статья н11", "2023", "3", "Ермольчев Константин Васильевич", "6", "6"},
                {"7", "Отклоненный патент", "2023", "2", "Кирюхина Оксана Юрьевна", "7", "7"},
                {"8", "свидетельство о рождения", "2023", "1", "Дудник Наталья Борисовна", "8", "8"},
                {"9", "Просроченный сертификат", "2023", "1", "Попова Вероника Владимировна", "9", "9"}
        };
        for (String[] doc : deletedDocuments) {
            ContentValues values = new ContentValues();
            values.put("doc_id", doc[0]);
            values.put("document_subject", doc[1]);
            values.put("start_data", doc[2]);
            values.put("type_id", doc[3]);
            values.put("Supervisor_full_name", doc[4]);
            values.put("student_id", doc[5]);
            values.put("box_id", doc[6]);
            db.insert(TABLE_DELETED_DOCUMENTS, null, values);
        }

        // ==================== Личные дела студентов ====================
        String[][] personalFiles = {
                {"1", "2024", null, null, "1"},
                {"2", "2024", null, null, "2"},
                {"3", "2024", null, null, "3"},
                {"4", "2021", "2023", "Окончание", "4"},
                {"5", "2024", null, null, "5"},
                {"6", "2023", null, null, "6"},
                {"7", "2021", "2023", "Окончание", "7"},
                {"8", "2023", null, null, "8"},
                {"9", "2023", null, null, "9"}
        };
        for (String[] pf : personalFiles) {
            ContentValues values = new ContentValues();
            values.put("pers_file_id", pf[0]);
            values.put("admission_year", pf[1]);
            if (pf[2] != null) values.put("deduction_year", pf[2]);
            if (pf[3] != null) values.put("reason", pf[3]);
            values.put("student_id", pf[4]);
            db.insert(TABLE_STUDENTS_PERS_FILES, null, values);
        }

        // ==================== УДАЛЕННЫЕ ЛИЧНЫЕ ДЕЛА ====================
        String[][] deletedPersonalFiles = {
                {"1", "2020", "2022", "Отчисление", "1"},
                {"2", "2021", "2023", "Перевод", "2"},
                {"3", "2020", "2022", "Академический", "3"},
                {"4", "2019", "2023", "Окончание", "4"},
                {"5", "2021", "2023", "Отчисление", "5"},
                {"6", "2020", "2023", "Окончание", "6"},
                {"7", "2019", "2022", "Перевод", "7"},
                {"8", "2021", "2023", "Окончание", "8"},
                {"9", "2020", "2023", "Академический", "9"}
        };
        for (String[] dpf : deletedPersonalFiles) {
            ContentValues values = new ContentValues();
            values.put("pers_file_id", dpf[0]);
            values.put("admission_year", dpf[1]);
            if (dpf[2] != null) values.put("deduction_year", dpf[2]);
            if (dpf[3] != null) values.put("reason", dpf[3]);
            values.put("student_id", dpf[4]);
            db.insert(TABLE_DELETED_STUDENTS_PERS_FILES, null, values);
        }

        // ==================== Пользователи (пароль: 123456) ====================
        String[][] users = {
                {"1", "Администратор", "Admin", "admin", hashPassword("123456")},
                {"2", "Сотрудник", "Employer", "user", hashPassword("123456")},
                {"3", "Скрыльников Дмитрий Константинович", "Admin", "derector_sdk", hashPassword("123456")},
                {"4", "Федусева Элла Юрьевна", "Employer", "fedusia_eu", hashPassword("123456")},
                {"5", "Мартыненко Вадим Алексеевич", "Admin", "martinenko_cool", hashPassword("123456")},
                {"6", "Истомина Анна Николаевна", "Admin", "upravlauszh_an", hashPassword("123456")},
                {"7", "Павлов Андрей", "Admin", "very_developer", hashPassword("123456")},
                {"8", "Пользователь", "Employer", "user", hashPassword("123456")}
        };
        for (String[] user : users) {
            ContentValues values = new ContentValues();
            values.put("user_id", user[0]);
            values.put("FIO", user[1]);
            values.put("role", user[2]);
            values.put("login", user[3]);
            values.put("password", user[4]);
            db.insert(TABLE_USER, null, values);
        }
    }

    public static String hashPassword(String password) {
        try {
            java.security.MessageDigest md = java.security.MessageDigest.getInstance("SHA-512");
            byte[] hash = md.digest(password.getBytes());
            StringBuilder hexString = new StringBuilder();
            for (byte b : hash) {
                hexString.append(String.format("%02x", b));
            }
            return hexString.toString();
        } catch (java.security.NoSuchAlgorithmException e) {
            return password;
        }
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_USER);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_STUDENT);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_GROUP);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_DOCUMENTS);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_DELETED_DOCUMENTS);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_BOXES);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_DOCUMENT_TYPES);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_STUDENTS_PERS_FILES);
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_DELETED_STUDENTS_PERS_FILES);
        onCreate(db);
    }

    // ==================== CRUD операции для User ====================

    public long insertUser(User user) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("FIO", user.getFio());
        values.put("role", user.getRole());
        values.put("login", user.getLogin());
        values.put("password", hashPassword(user.getPassword()));
        long id = db.insert(TABLE_USER, null, values);
        db.close();
        return id;
    }

    public User getUser(String login, String password) {
        SQLiteDatabase db = this.getReadableDatabase();
        String hashedPassword = hashPassword(password);
        Cursor cursor = db.query(TABLE_USER, null, "login = ? AND password = ?",
                new String[]{login, hashedPassword}, null, null, null);

        User user = null;
        if (cursor.moveToFirst()) {
            user = new User();
            user.setUserId(cursor.getInt(cursor.getColumnIndexOrThrow("user_id")));
            user.setFio(cursor.getString(cursor.getColumnIndexOrThrow("FIO")));
            user.setRole(cursor.getString(cursor.getColumnIndexOrThrow("role")));
            user.setLogin(cursor.getString(cursor.getColumnIndexOrThrow("login")));
        }
        cursor.close();
        db.close();
        return user;
    }

    public List<User> getAllUsers() {
        List<User> users = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.query(TABLE_USER, null, null, null, null, null, null);

        if (cursor.moveToFirst()) {
            do {
                User user = new User();
                user.setUserId(cursor.getInt(cursor.getColumnIndexOrThrow("user_id")));
                user.setFio(cursor.getString(cursor.getColumnIndexOrThrow("FIO")));
                user.setRole(cursor.getString(cursor.getColumnIndexOrThrow("role")));
                user.setLogin(cursor.getString(cursor.getColumnIndexOrThrow("login")));
                users.add(user);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return users;
    }

    public int updateUser(User user) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("FIO", user.getFio());
        values.put("role", user.getRole());
        values.put("login", user.getLogin());
        if (user.getPassword() != null && !user.getPassword().isEmpty()) {
            values.put("password", hashPassword(user.getPassword()));
        }
        return db.update(TABLE_USER, values, "user_id = ?", new String[]{String.valueOf(user.getUserId())});
    }

    public void deleteUser(int userId) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_USER, "user_id = ?", new String[]{String.valueOf(userId)});
        db.close();
    }

    // ==================== CRUD операции для Student ====================

    public long insertStudent(Student student) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("full_name", student.getFullName());
        values.put("group_id", student.getGroupId());
        long id = db.insert(TABLE_STUDENT, null, values);

        if (student.getPersonalFile() != null) {
            ContentValues pfValues = new ContentValues();
            pfValues.put("admission_year", student.getPersonalFile().getAdmissionYear());
            pfValues.put("deduction_year", student.getPersonalFile().getDeductionYear());
            pfValues.put("reason", student.getPersonalFile().getReason());
            pfValues.put("student_id", id);
            db.insert(TABLE_STUDENTS_PERS_FILES, null, pfValues);
        }
        db.close();
        return id;
    }

    public List<Student> getAllStudents() {
        List<Student> students = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        String query = "SELECT s.*, g.group_name FROM " + TABLE_STUDENT + " s " +
                "LEFT JOIN " + TABLE_GROUP + " g ON s.group_id = g.group_id";
        Cursor cursor = db.rawQuery(query, null);

        if (cursor.moveToFirst()) {
            do {
                Student student = new Student();
                student.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
                student.setFullName(cursor.getString(cursor.getColumnIndexOrThrow("full_name")));
                student.setGroupId(cursor.getInt(cursor.getColumnIndexOrThrow("group_id")));
                student.setGroupName(cursor.getString(cursor.getColumnIndexOrThrow("group_name")));
                students.add(student);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return students;
    }

    public Student getStudentById(int studentId) {
        SQLiteDatabase db = this.getReadableDatabase();
        Student student = null;

        String query = "SELECT s.*, g.group_name FROM " + TABLE_STUDENT + " s " +
                "LEFT JOIN " + TABLE_GROUP + " g ON s.group_id = g.group_id " +
                "WHERE s.student_id = ?";

        Cursor cursor = db.rawQuery(query, new String[]{String.valueOf(studentId)});

        if (cursor.moveToFirst()) {
            student = new Student();
            student.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
            student.setFullName(cursor.getString(cursor.getColumnIndexOrThrow("full_name")));
            student.setGroupId(cursor.getInt(cursor.getColumnIndexOrThrow("group_id")));
            student.setGroupName(cursor.getString(cursor.getColumnIndexOrThrow("group_name")));
            loadPersonalFileForStudent(db, student);
        }
        cursor.close();
        db.close();
        return student;
    }

    private void loadPersonalFileForStudent(SQLiteDatabase db, Student student) {
        String query = "SELECT * FROM " + TABLE_STUDENTS_PERS_FILES + " WHERE student_id = ?";
        Cursor cursor = db.rawQuery(query, new String[]{String.valueOf(student.getStudentId())});

        if (cursor.moveToFirst()) {
            PersonalFile pf = new PersonalFile();
            pf.setPersFileId(cursor.getInt(cursor.getColumnIndexOrThrow("pers_file_id")));
            pf.setAdmissionYear(cursor.getInt(cursor.getColumnIndexOrThrow("admission_year")));
            pf.setDeductionYear(cursor.getInt(cursor.getColumnIndexOrThrow("deduction_year")));
            pf.setReason(cursor.getString(cursor.getColumnIndexOrThrow("reason")));
            pf.setStudentId(student.getStudentId());
            student.setPersonalFile(pf);
        }
        cursor.close();
    }

    public int updateStudent(Student student) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("full_name", student.getFullName());
        values.put("group_id", student.getGroupId());
        return db.update(TABLE_STUDENT, values, "student_id = ?", new String[]{String.valueOf(student.getStudentId())});
    }

    public void deleteStudent(int studentId, boolean moveToDeleted) {
        SQLiteDatabase db = this.getWritableDatabase();
        if (moveToDeleted) {
            ContentValues values = new ContentValues();
            values.put("student_id", studentId);
            db.insert(TABLE_DELETED_STUDENTS_PERS_FILES, null, values);
        }
        db.delete(TABLE_STUDENT, "student_id = ?", new String[]{String.valueOf(studentId)});
        db.close();
    }

    // ==================== CRUD операции для Group ====================

    public long insertGroup(Group group) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("group_name", group.getGroupName());
        values.put("formation_year", group.getFormationYear());
        values.put("specialization", group.getSpecialization());
        long id = db.insert(TABLE_GROUP, null, values);
        db.close();
        return id;
    }

    public List<Group> getAllGroups() {
        List<Group> groups = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.query(TABLE_GROUP, null, null, null, null, null, null);

        if (cursor.moveToFirst()) {
            do {
                Group group = new Group();
                group.setGroupId(cursor.getInt(cursor.getColumnIndexOrThrow("group_id")));
                group.setGroupName(cursor.getString(cursor.getColumnIndexOrThrow("group_name")));
                group.setFormationYear(cursor.getInt(cursor.getColumnIndexOrThrow("formation_year")));
                group.setSpecialization(cursor.getString(cursor.getColumnIndexOrThrow("specialization")));
                groups.add(group);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return groups;
    }

    public Group getGroupById(int groupId) {
        SQLiteDatabase db = this.getReadableDatabase();
        Group group = null;
        Cursor cursor = db.query(TABLE_GROUP, null, "group_id = ?",
                new String[]{String.valueOf(groupId)}, null, null, null);

        if (cursor.moveToFirst()) {
            group = new Group();
            group.setGroupId(cursor.getInt(cursor.getColumnIndexOrThrow("group_id")));
            group.setGroupName(cursor.getString(cursor.getColumnIndexOrThrow("group_name")));
            group.setFormationYear(cursor.getInt(cursor.getColumnIndexOrThrow("formation_year")));
            group.setSpecialization(cursor.getString(cursor.getColumnIndexOrThrow("specialization")));
        }
        cursor.close();
        db.close();
        return group;
    }

    public int updateGroup(Group group) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("group_name", group.getGroupName());
        values.put("formation_year", group.getFormationYear());
        values.put("specialization", group.getSpecialization());
        return db.update(TABLE_GROUP, values, "group_id = ?", new String[]{String.valueOf(group.getGroupId())});
    }

    public void deleteGroup(int groupId) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_GROUP, "group_id = ?", new String[]{String.valueOf(groupId)});
        db.close();
    }

    // ==================== CRUD операции для Document ====================

    public long insertDocument(Document document) {
        SQLiteDatabase db = this.getWritableDatabase();
        String table = document.isDeleted() ? TABLE_DELETED_DOCUMENTS : TABLE_DOCUMENTS;
        ContentValues values = new ContentValues();
        values.put("document_subject", document.getDocumentSubject());
        values.put("start_data", document.getStartData());
        values.put("type_id", document.getTypeId());
        values.put("Supervisor_full_name", document.getSupervisorFullName());
        values.put("student_id", document.getStudentId());
        values.put("box_id", document.getBoxId());
        long id = db.insert(table, null, values);
        db.close();
        return id;
    }

    public List<Document> getAllDocuments(boolean includeDeleted) {
        List<Document> documents = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        String table = includeDeleted ? TABLE_DELETED_DOCUMENTS : TABLE_DOCUMENTS;

        String query = "SELECT d.*, dt.type_name, s.full_name as student_name " +
                "FROM " + table + " d " +
                "LEFT JOIN " + TABLE_DOCUMENT_TYPES + " dt ON d.type_id = dt.type_id " +
                "LEFT JOIN " + TABLE_STUDENT + " s ON d.student_id = s.student_id";

        Cursor cursor = db.rawQuery(query, null);

        if (cursor.moveToFirst()) {
            do {
                Document doc = new Document();
                doc.setDocId(cursor.getInt(cursor.getColumnIndexOrThrow("doc_id")));
                doc.setDocumentSubject(cursor.getString(cursor.getColumnIndexOrThrow("document_subject")));
                doc.setStartData(cursor.getInt(cursor.getColumnIndexOrThrow("start_data")));
                doc.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
                doc.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
                doc.setSupervisorFullName(cursor.getString(cursor.getColumnIndexOrThrow("Supervisor_full_name")));
                doc.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
                doc.setStudentName(cursor.getString(cursor.getColumnIndexOrThrow("student_name")));
                doc.setDeleted(includeDeleted);
                documents.add(doc);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return documents;
    }

    public Document getDocumentById(int docId, boolean isDeleted) {
        SQLiteDatabase db = this.getReadableDatabase();
        String table = isDeleted ? TABLE_DELETED_DOCUMENTS : TABLE_DOCUMENTS;
        Document doc = null;

        String query = "SELECT d.*, dt.type_name, s.full_name as student_name " +
                "FROM " + table + " d " +
                "LEFT JOIN " + TABLE_DOCUMENT_TYPES + " dt ON d.type_id = dt.type_id " +
                "LEFT JOIN " + TABLE_STUDENT + " s ON d.student_id = s.student_id " +
                "WHERE d.doc_id = ?";

        Cursor cursor = db.rawQuery(query, new String[]{String.valueOf(docId)});

        if (cursor.moveToFirst()) {
            doc = new Document();
            doc.setDocId(cursor.getInt(cursor.getColumnIndexOrThrow("doc_id")));
            doc.setDocumentSubject(cursor.getString(cursor.getColumnIndexOrThrow("document_subject")));
            doc.setStartData(cursor.getInt(cursor.getColumnIndexOrThrow("start_data")));
            doc.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
            doc.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
            doc.setSupervisorFullName(cursor.getString(cursor.getColumnIndexOrThrow("Supervisor_full_name")));
            doc.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
            doc.setStudentName(cursor.getString(cursor.getColumnIndexOrThrow("student_name")));
            doc.setDeleted(isDeleted);
        }
        cursor.close();
        db.close();
        return doc;
    }

    public List<Document> getDocumentsByGroupAndType(int groupId, String typeName) {
        List<Document> documents = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();

        int typeId = -1;
        Cursor typeCursor = db.query(TABLE_DOCUMENT_TYPES, new String[]{"type_id"},
                "type_name = ?", new String[]{typeName}, null, null, null);
        if (typeCursor.moveToFirst()) {
            typeId = typeCursor.getInt(0);
        }
        typeCursor.close();

        if (typeId == -1) {
            db.close();
            return documents;
        }

        String query = "SELECT d.*, s.full_name as student_name, dt.type_name " +
                "FROM " + TABLE_DOCUMENTS + " d " +
                "INNER JOIN " + TABLE_STUDENT + " s ON d.student_id = s.student_id " +
                "INNER JOIN " + TABLE_DOCUMENT_TYPES + " dt ON d.type_id = dt.type_id " +
                "WHERE s.group_id = ? AND d.type_id = ?";

        Cursor cursor = db.rawQuery(query, new String[]{String.valueOf(groupId), String.valueOf(typeId)});

        if (cursor.moveToFirst()) {
            do {
                Document doc = new Document();
                doc.setDocId(cursor.getInt(cursor.getColumnIndexOrThrow("doc_id")));
                doc.setDocumentSubject(cursor.getString(cursor.getColumnIndexOrThrow("document_subject")));
                doc.setStartData(cursor.getInt(cursor.getColumnIndexOrThrow("start_data")));
                doc.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
                doc.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
                doc.setSupervisorFullName(cursor.getString(cursor.getColumnIndexOrThrow("Supervisor_full_name")));
                doc.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
                doc.setStudentName(cursor.getString(cursor.getColumnIndexOrThrow("student_name")));
                documents.add(doc);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return documents;
    }

    public int updateDocument(Document document) {
        SQLiteDatabase db = this.getWritableDatabase();
        String table = document.isDeleted() ? TABLE_DELETED_DOCUMENTS : TABLE_DOCUMENTS;
        ContentValues values = new ContentValues();
        values.put("document_subject", document.getDocumentSubject());
        values.put("start_data", document.getStartData());
        values.put("type_id", document.getTypeId());
        values.put("Supervisor_full_name", document.getSupervisorFullName());
        values.put("student_id", document.getStudentId());
        values.put("box_id", document.getBoxId());
        return db.update(table, values, "doc_id = ?", new String[]{String.valueOf(document.getDocId())});
    }

    public void deleteDocument(int docId, boolean moveToDeleted) {
        SQLiteDatabase db = this.getWritableDatabase();

        if (moveToDeleted) {
            Cursor cursor = db.query(TABLE_DOCUMENTS, null, "doc_id = ?", new String[]{String.valueOf(docId)}, null, null, null);
            if (cursor.moveToFirst()) {
                ContentValues values = new ContentValues();
                values.put("doc_id", docId);
                values.put("document_subject", cursor.getString(cursor.getColumnIndexOrThrow("document_subject")));
                values.put("start_data", cursor.getInt(cursor.getColumnIndexOrThrow("start_data")));
                values.put("type_id", cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
                values.put("Supervisor_full_name", cursor.getString(cursor.getColumnIndexOrThrow("Supervisor_full_name")));
                values.put("student_id", cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
                values.put("box_id", cursor.getInt(cursor.getColumnIndexOrThrow("box_id")));
                db.insert(TABLE_DELETED_DOCUMENTS, null, values);
            }
            cursor.close();
        }
        db.delete(TABLE_DOCUMENTS, "doc_id = ?", new String[]{String.valueOf(docId)});
        db.close();
    }

    // ==================== CRUD операции для DocumentType ====================

    public long insertDocumentType(DocumentType documentType) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("type_name", documentType.getTypeName());
        long id = db.insert(TABLE_DOCUMENT_TYPES, null, values);
        db.close();
        return id;
    }

    public List<DocumentType> getAllDocumentTypes() {
        List<DocumentType> types = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor cursor = db.query(TABLE_DOCUMENT_TYPES, null, null, null, null, null, null);

        if (cursor.moveToFirst()) {
            do {
                DocumentType type = new DocumentType();
                type.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
                type.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
                types.add(type);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return types;
    }

    public int updateDocumentType(DocumentType documentType) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("type_name", documentType.getTypeName());
        return db.update(TABLE_DOCUMENT_TYPES, values, "type_id = ?", new String[]{String.valueOf(documentType.getTypeId())});
    }

    public void deleteDocumentType(int typeId) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_DOCUMENT_TYPES, "type_id = ?", new String[]{String.valueOf(typeId)});
        db.close();
    }

    // ==================== CRUD операции для Boxes ====================

    public long insertBox(Box box) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("box_name", box.getBoxName());
        values.put("rack_number", box.getRackNumber());
        values.put("shelf_number", box.getShelfNumber());
        values.put("group_id", box.getGroupId() > 0 ? box.getGroupId() : null);
        values.put("type_id", box.getTypeId());
        values.put("year_work", box.getYearWork() > 0 ? box.getYearWork() : null);
        long id = db.insert(TABLE_BOXES, null, values);
        db.close();
        return id;
    }

    public List<Box> getAllBoxes() {
        List<Box> boxes = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();

        String query = "SELECT b.*, g.group_name, dt.type_name FROM " + TABLE_BOXES + " b " +
                "LEFT JOIN " + TABLE_GROUP + " g ON b.group_id = g.group_id " +
                "LEFT JOIN " + TABLE_DOCUMENT_TYPES + " dt ON b.type_id = dt.type_id";

        Cursor cursor = db.rawQuery(query, null);

        if (cursor.moveToFirst()) {
            do {
                Box box = new Box();
                box.setBoxId(cursor.getInt(cursor.getColumnIndexOrThrow("box_id")));
                box.setBoxName(cursor.getString(cursor.getColumnIndexOrThrow("box_name")));
                box.setRackNumber(cursor.getInt(cursor.getColumnIndexOrThrow("rack_number")));
                box.setShelfNumber(cursor.getInt(cursor.getColumnIndexOrThrow("shelf_number")));
                box.setGroupId(cursor.getInt(cursor.getColumnIndexOrThrow("group_id")));
                box.setGroupName(cursor.getString(cursor.getColumnIndexOrThrow("group_name")));
                box.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
                box.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
                box.setYearWork(cursor.getInt(cursor.getColumnIndexOrThrow("year_work")));
                boxes.add(box);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return boxes;
    }

    public Box getBoxById(int boxId) {
        SQLiteDatabase db = this.getReadableDatabase();
        Box box = null;

        String query = "SELECT b.*, g.group_name, dt.type_name FROM " + TABLE_BOXES + " b " +
                "LEFT JOIN " + TABLE_GROUP + " g ON b.group_id = g.group_id " +
                "LEFT JOIN " + TABLE_DOCUMENT_TYPES + " dt ON b.type_id = dt.type_id " +
                "WHERE b.box_id = ?";

        Cursor cursor = db.rawQuery(query, new String[]{String.valueOf(boxId)});

        if (cursor.moveToFirst()) {
            box = new Box();
            box.setBoxId(cursor.getInt(cursor.getColumnIndexOrThrow("box_id")));
            box.setBoxName(cursor.getString(cursor.getColumnIndexOrThrow("box_name")));
            box.setRackNumber(cursor.getInt(cursor.getColumnIndexOrThrow("rack_number")));
            box.setShelfNumber(cursor.getInt(cursor.getColumnIndexOrThrow("shelf_number")));
            box.setGroupId(cursor.getInt(cursor.getColumnIndexOrThrow("group_id")));
            box.setGroupName(cursor.getString(cursor.getColumnIndexOrThrow("group_name")));
            box.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
            box.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
            box.setYearWork(cursor.getInt(cursor.getColumnIndexOrThrow("year_work")));
        }
        cursor.close();
        db.close();
        return box;
    }

    public int updateBox(Box box) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("box_name", box.getBoxName());
        values.put("rack_number", box.getRackNumber());
        values.put("shelf_number", box.getShelfNumber());
        values.put("group_id", box.getGroupId() > 0 ? box.getGroupId() : null);
        values.put("type_id", box.getTypeId());
        values.put("year_work", box.getYearWork() > 0 ? box.getYearWork() : null);
        return db.update(TABLE_BOXES, values, "box_id = ?", new String[]{String.valueOf(box.getBoxId())});
    }

    public void deleteBox(int boxId) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_BOXES, "box_id = ?", new String[]{String.valueOf(boxId)});
        db.close();
    }

    // ==================== Методы для резервного копирования ====================
    private Context context;

    public boolean exportToFile() {

        try {
            // Используем внешнее хранилище для Android 10+
            File backupDir;
            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.Q) {
                // Для Android 10+ используем специальную директорию
                backupDir = new File(context.getExternalFilesDir(null), "Backups");
            } else {
                backupDir = new File(Environment.getExternalStorageDirectory(), "ArchiveFundBackups");
            }

            if (!backupDir.exists()) {
                backupDir.mkdirs();
            }

            String timestamp = new SimpleDateFormat("yyyyMMdd_HHmmss", Locale.getDefault()).format(new Date());
            File backupFile = new File(backupDir, "backup_" + timestamp + ".db");

            // Копируем файл базы данных
            File dbFile = new File(this.getWritableDatabase().getPath());
            FileInputStream fis = new FileInputStream(dbFile);
            FileOutputStream fos = new FileOutputStream(backupFile);

            byte[] buffer = new byte[1024];
            int length;
            while ((length = fis.read(buffer)) > 0) {
                fos.write(buffer, 0, length);
            }

            fos.flush();
            fos.close();
            fis.close();

            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }

    public boolean importFromFile() {
        try {
            File backupDir;
            if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.Q) {
                backupDir = new File(context.getExternalFilesDir(null), "Backups");
            } else {
                backupDir = new File(Environment.getExternalStorageDirectory(), "ArchiveFundBackups");
            }

            if (!backupDir.exists()) {
                return false;
            }

            File[] backups = backupDir.listFiles((dir, name) -> name.endsWith(".db"));
            if (backups == null || backups.length == 0) {
                return false;
            }

            // Выбираем последний файл резервной копии
            File latestBackup = backups[0];
            for (File backup : backups) {
                if (backup.lastModified() > latestBackup.lastModified()) {
                    latestBackup = backup;
                }
            }

            // Закрываем текущее соединение с БД
            SQLiteDatabase db = this.getWritableDatabase();
            db.close();

            // Копируем файл резервной копии
            File dbFile = new File(this.getWritableDatabase().getPath());
            FileInputStream fis = new FileInputStream(latestBackup);
            FileOutputStream fos = new FileOutputStream(dbFile);

            byte[] buffer = new byte[1024];
            int length;
            while ((length = fis.read(buffer)) > 0) {
                fos.write(buffer, 0, length);
            }

            fos.flush();
            fos.close();
            fis.close();

            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }

    // ==================== Поиск ====================

    public List<Student> searchStudents(String query) {
        List<Student> students = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        String sql = "SELECT s.*, g.group_name FROM " + TABLE_STUDENT + " s " +
                "LEFT JOIN " + TABLE_GROUP + " g ON s.group_id = g.group_id " +
                "WHERE s.full_name LIKE ? OR g.group_name LIKE ?";
        Cursor cursor = db.rawQuery(sql, new String[]{"%" + query + "%", "%" + query + "%"});

        if (cursor.moveToFirst()) {
            do {
                Student student = new Student();
                student.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
                student.setFullName(cursor.getString(cursor.getColumnIndexOrThrow("full_name")));
                student.setGroupId(cursor.getInt(cursor.getColumnIndexOrThrow("group_id")));
                student.setGroupName(cursor.getString(cursor.getColumnIndexOrThrow("group_name")));
                students.add(student);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return students;
    }
    /**
     * Проверяет, существует ли база данных
     */


    /**
     * Создает базу данных если она не существует
     */


    /**
     * Проверяет и создает таблицы если их нет
     */
    public void checkAndCreateTables() {
        SQLiteDatabase db = this.getWritableDatabase();

        // Проверяем существует ли таблица User
        Cursor cursor = db.rawQuery("SELECT name FROM sqlite_master WHERE type='table' AND name=?",
                new String[]{TABLE_USER});

        if (cursor.getCount() == 0) {
            // Таблицы не существуют, создаем их
            onCreate(db);
        }
        cursor.close();
        db.close();
    }

    /**
     * Получает читаемую базу данных с проверкой
     */
    public SQLiteDatabase getReadableDatabaseSafe() {
        try {
            return this.getReadableDatabase();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    /**
     * Получает записываемую базу данных с проверкой
     */
    public SQLiteDatabase getWritableDatabaseSafe() {
        try {
            return this.getWritableDatabase();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
    public List<PersonalFile> getAllPersonalFiles(boolean includeDeleted) {
        List<PersonalFile> personalFiles = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        String table = includeDeleted ? TABLE_DELETED_STUDENTS_PERS_FILES : TABLE_STUDENTS_PERS_FILES;

        String query = "SELECT pf.*, s.full_name as student_name " +
                "FROM " + table + " pf " +
                "LEFT JOIN " + TABLE_STUDENT + " s ON pf.student_id = s.student_id";

        Cursor cursor = db.rawQuery(query, null);

        if (cursor.moveToFirst()) {
            do {
                PersonalFile pf = new PersonalFile();
                pf.setPersFileId(cursor.getInt(cursor.getColumnIndexOrThrow("pers_file_id")));
                pf.setAdmissionYear(cursor.getInt(cursor.getColumnIndexOrThrow("admission_year")));
                int deductionYear = cursor.getInt(cursor.getColumnIndexOrThrow("deduction_year"));
                pf.setDeductionYear(deductionYear);
                pf.setReason(cursor.getString(cursor.getColumnIndexOrThrow("reason")));
                pf.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
                pf.setStudentName(cursor.getString(cursor.getColumnIndexOrThrow("student_name")));
                pf.setDeleted(includeDeleted);
                personalFiles.add(pf);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return personalFiles;
    }
    public PersonalFile getPersonalFileById(int persFileId, boolean isDeleted) {
        SQLiteDatabase db = this.getReadableDatabase();
        String table = isDeleted ? TABLE_DELETED_STUDENTS_PERS_FILES : TABLE_STUDENTS_PERS_FILES;
        PersonalFile pf = null;

        String query = "SELECT pf.*, s.full_name as student_name " +
                "FROM " + table + " pf " +
                "LEFT JOIN " + TABLE_STUDENT + " s ON pf.student_id = s.student_id " +
                "WHERE pf.pers_file_id = ?";

        Cursor cursor = db.rawQuery(query, new String[]{String.valueOf(persFileId)});

        if (cursor.moveToFirst()) {
            pf = new PersonalFile();
            pf.setPersFileId(cursor.getInt(cursor.getColumnIndexOrThrow("pers_file_id")));
            pf.setAdmissionYear(cursor.getInt(cursor.getColumnIndexOrThrow("admission_year")));
            pf.setDeductionYear(cursor.getInt(cursor.getColumnIndexOrThrow("deduction_year")));
            pf.setReason(cursor.getString(cursor.getColumnIndexOrThrow("reason")));
            pf.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
            pf.setStudentName(cursor.getString(cursor.getColumnIndexOrThrow("student_name")));
            pf.setDeleted(isDeleted);
        }
        cursor.close();
        db.close();
        return pf;
    }
    public PersonalFile getPersonalFileByStudentId(int studentId, boolean isDeleted) {
        SQLiteDatabase db = this.getReadableDatabase();
        String table = isDeleted ? TABLE_DELETED_STUDENTS_PERS_FILES : TABLE_STUDENTS_PERS_FILES;
        PersonalFile pf = null;

        Cursor cursor = db.query(table, null, "student_id = ?",
                new String[]{String.valueOf(studentId)}, null, null, null);

        if (cursor.moveToFirst()) {
            pf = new PersonalFile();
            pf.setPersFileId(cursor.getInt(cursor.getColumnIndexOrThrow("pers_file_id")));
            pf.setAdmissionYear(cursor.getInt(cursor.getColumnIndexOrThrow("admission_year")));
            pf.setDeductionYear(cursor.getInt(cursor.getColumnIndexOrThrow("deduction_year")));
            pf.setReason(cursor.getString(cursor.getColumnIndexOrThrow("reason")));
            pf.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
            pf.setDeleted(isDeleted);
        }
        cursor.close();
        db.close();
        return pf;
    }

    public long insertPersonalFile(PersonalFile personalFile) {
        SQLiteDatabase db = this.getWritableDatabase();
        String table = personalFile.isDeleted() ? TABLE_DELETED_STUDENTS_PERS_FILES : TABLE_STUDENTS_PERS_FILES;
        ContentValues values = new ContentValues();
        values.put("admission_year", personalFile.getAdmissionYear());
        values.put("deduction_year", personalFile.getDeductionYear());
        values.put("reason", personalFile.getReason());
        values.put("student_id", personalFile.getStudentId());
        long id = db.insert(table, null, values);
        db.close();
        return id;
    }

    public int updatePersonalFile(PersonalFile personalFile) {
        SQLiteDatabase db = this.getWritableDatabase();
        String table = personalFile.isDeleted() ? TABLE_DELETED_STUDENTS_PERS_FILES : TABLE_STUDENTS_PERS_FILES;
        ContentValues values = new ContentValues();
        values.put("admission_year", personalFile.getAdmissionYear());
        values.put("deduction_year", personalFile.getDeductionYear());
        values.put("reason", personalFile.getReason());
        values.put("student_id", personalFile.getStudentId());
        return db.update(table, values, "pers_file_id = ?",
                new String[]{String.valueOf(personalFile.getPersFileId())});
    }

    public void deletePersonalFile(int persFileId, boolean isDeleted) {
        SQLiteDatabase db = this.getWritableDatabase();
        String table = isDeleted ? TABLE_DELETED_STUDENTS_PERS_FILES : TABLE_STUDENTS_PERS_FILES;
        db.delete(table, "pers_file_id = ?", new String[]{String.valueOf(persFileId)});
        db.close();
    }
    public List<Document> getDocumentsByStudent(int studentId, boolean includeDeleted) {
        List<Document> list = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        String table = includeDeleted ? TABLE_DELETED_DOCUMENTS : TABLE_DOCUMENTS;
        String query = "SELECT d.*, dt.type_name, s.full_name as student_name " +
                "FROM " + table + " d " +
                "LEFT JOIN " + TABLE_DOCUMENT_TYPES + " dt ON d.type_id = dt.type_id " +
                "LEFT JOIN " + TABLE_STUDENT + " s ON d.student_id = s.student_id " +
                "WHERE d.student_id = ?";
        Cursor cursor = db.rawQuery(query, new String[]{String.valueOf(studentId)});
        while (cursor.moveToNext()) {
            Document doc = new Document();
            doc.setDocId(cursor.getInt(cursor.getColumnIndexOrThrow("doc_id")));
            doc.setDocumentSubject(cursor.getString(cursor.getColumnIndexOrThrow("document_subject")));
            doc.setStartData(cursor.getInt(cursor.getColumnIndexOrThrow("start_data")));
            doc.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
            doc.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
            doc.setSupervisorFullName(cursor.getString(cursor.getColumnIndexOrThrow("Supervisor_full_name")));
            doc.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
            doc.setStudentName(cursor.getString(cursor.getColumnIndexOrThrow("student_name")));
            doc.setBoxId(cursor.getInt(cursor.getColumnIndexOrThrow("box_id")));
            doc.setDeleted(includeDeleted);
            list.add(doc);
        }
        cursor.close();
        db.close();
        return list;
    }

    public List<Document> getDocumentsByGroup(int groupId, boolean includeDeleted) {
        List<Document> list = new ArrayList<>();
        // Получаем всех студентов группы
        List<Integer> studentIds = new ArrayList<>();
        SQLiteDatabase db = this.getReadableDatabase();
        Cursor studentCursor = db.query(TABLE_STUDENT, new String[]{"student_id"}, "group_id = ?",
                new String[]{String.valueOf(groupId)}, null, null, null);
        while (studentCursor.moveToNext()) {
            studentIds.add(studentCursor.getInt(0));
        }
        studentCursor.close();
        if (studentIds.isEmpty()) return list;

        String placeholders = TextUtils.join(",", Collections.nCopies(studentIds.size(), "?"));
        String[] args = new String[studentIds.size()];
        for (int i = 0; i < studentIds.size(); i++) args[i] = String.valueOf(studentIds.get(i));

        String table = includeDeleted ? TABLE_DELETED_DOCUMENTS : TABLE_DOCUMENTS;
        String query = "SELECT d.*, dt.type_name, s.full_name as student_name " +
                "FROM " + table + " d " +
                "LEFT JOIN " + TABLE_DOCUMENT_TYPES + " dt ON d.type_id = dt.type_id " +
                "LEFT JOIN " + TABLE_STUDENT + " s ON d.student_id = s.student_id " +
                "WHERE d.student_id IN (" + placeholders + ")";
        Cursor cursor = db.rawQuery(query, args);
        while (cursor.moveToNext()) {
            Document doc = new Document();
            doc.setDocId(cursor.getInt(cursor.getColumnIndexOrThrow("doc_id")));
            doc.setDocumentSubject(cursor.getString(cursor.getColumnIndexOrThrow("document_subject")));
            doc.setStartData(cursor.getInt(cursor.getColumnIndexOrThrow("start_data")));
            doc.setTypeId(cursor.getInt(cursor.getColumnIndexOrThrow("type_id")));
            doc.setTypeName(cursor.getString(cursor.getColumnIndexOrThrow("type_name")));
            doc.setSupervisorFullName(cursor.getString(cursor.getColumnIndexOrThrow("Supervisor_full_name")));
            doc.setStudentId(cursor.getInt(cursor.getColumnIndexOrThrow("student_id")));
            doc.setStudentName(cursor.getString(cursor.getColumnIndexOrThrow("student_name")));
            doc.setBoxId(cursor.getInt(cursor.getColumnIndexOrThrow("box_id")));
            doc.setDeleted(includeDeleted);
            list.add(doc);
        }
        cursor.close();
        db.close();
        return list;
    }
}
