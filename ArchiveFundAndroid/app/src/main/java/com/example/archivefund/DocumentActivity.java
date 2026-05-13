package com.example.archivefund;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import android.os.Bundle;
import android.text.TextUtils;
import android.widget.*;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.archivefund.R;
import com.example.archivefund.DatabaseHelper;
import com.example.archivefund.Box;
import com.example.archivefund.Document;
import com.example.archivefund.DocumentType;
import com.example.archivefund.Student;

import java.util.ArrayList;
import java.util.List;

public class DocumentActivity extends AppCompatActivity {
    private EditText etDocumentSubject, etCreationYear, etSupervisorName;
    private Spinner spinnerType, spinnerStudent, spinnerBox;
    private CheckBox cbIsDelete;
    private Button btnSave, btnCancel;

    private DatabaseHelper dbHelper;
    private int docId = -1;
    private boolean isDeleted = false;

    private List<DocumentType> documentTypes;
    private List<Student> students;
    private List<Box> boxes;

    private ArrayAdapter<String> typeAdapter, studentAdapter, boxAdapter;
    private List<String> typeNames, studentNames, boxNames;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_document);

        dbHelper = new DatabaseHelper(this);

        initViews();
        setupToolbar();
        loadDataFromDb();
        setupSpinners();
        loadDataIfEdit();
        setupListeners();
    }

    private void initViews() {
        etDocumentSubject = findViewById(R.id.etDocumentSubject);
        etCreationYear = findViewById(R.id.etCreationYear);
        etSupervisorName = findViewById(R.id.etSupervisorName);
        spinnerType = findViewById(R.id.spinnerType);
        spinnerStudent = findViewById(R.id.spinnerStudent);
        spinnerBox = findViewById(R.id.spinnerBox);
        cbIsDelete = findViewById(R.id.cbIsDelete);
        btnSave = findViewById(R.id.btnSave);
        btnCancel = findViewById(R.id.btnCancel);
    }

    private void setupToolbar() {
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        if (getSupportActionBar() != null) {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        }
    }

    private void loadDataFromDb() {
        documentTypes = dbHelper.getAllDocumentTypes();
        students = dbHelper.getAllStudents();
        boxes = getAllBoxes(); // Нужно реализовать в DatabaseHelper

        typeNames = new ArrayList<>();
        for (DocumentType type : documentTypes) {
            typeNames.add(type.getTypeName());
        }

        studentNames = new ArrayList<>();
        for (Student student : students) {
            studentNames.add(student.getFullName());
        }

        boxNames = new ArrayList<>();
        for (Box box : boxes) {
            boxNames.add(box.getBoxName() != null ? box.getBoxName() :
                    "Коробка " + box.getBoxId());
        }
    }

    private List<Box> getAllBoxes() {
        // Временно возвращаем пустой список
        // Нужно реализовать метод в DatabaseHelper
        return new ArrayList<>();
    }

    private void setupSpinners() {
        typeAdapter = new ArrayAdapter<>(this,
                android.R.layout.simple_spinner_item, typeNames);
        typeAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerType.setAdapter(typeAdapter);

        studentAdapter = new ArrayAdapter<>(this,
                android.R.layout.simple_spinner_item, studentNames);
        studentAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerStudent.setAdapter(studentAdapter);

        boxAdapter = new ArrayAdapter<>(this,
                android.R.layout.simple_spinner_item, boxNames);
        boxAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerBox.setAdapter(boxAdapter);
    }

    private void loadDataIfEdit() {
        docId = getIntent().getIntExtra("doc_id", -1);
        isDeleted = getIntent().getBooleanExtra("is_deleted", false);

        if (docId != -1) {
            setTitle("Редактирование документа");
            cbIsDelete.setChecked(isDeleted);
            loadDocumentData();
        } else {
            setTitle("Добавление документа");
        }
    }

    private void loadDocumentData() {
        List<Document> documents = dbHelper.getAllDocuments(isDeleted);
        for (Document doc : documents) {
            if (doc.getDocId() == docId) {
                etDocumentSubject.setText(doc.getDocumentSubject());
                etCreationYear.setText(String.valueOf(doc.getStartData()));
                etSupervisorName.setText(doc.getSupervisorFullName());

                // Установка типа
                for (int i = 0; i < documentTypes.size(); i++) {
                    if (documentTypes.get(i).getTypeId() == doc.getTypeId()) {
                        spinnerType.setSelection(i);
                        break;
                    }
                }

                // Установка студента
                for (int i = 0; i < students.size(); i++) {
                    if (students.get(i).getStudentId() == doc.getStudentId()) {
                        spinnerStudent.setSelection(i);
                        break;
                    }
                }

                // Установка коробки
                for (int i = 0; i < boxes.size(); i++) {
                    if (boxes.get(i).getBoxId() == doc.getBoxId()) {
                        spinnerBox.setSelection(i);
                        break;
                    }
                }
                break;
            }
        }
    }

    private void setupListeners() {
        btnSave.setOnClickListener(v -> saveDocument());
        btnCancel.setOnClickListener(v -> finish());
    }

    private void saveDocument() {
        String subject = etDocumentSubject.getText().toString().trim();
        String yearStr = etCreationYear.getText().toString().trim();
        String supervisor = etSupervisorName.getText().toString().trim();

        // Валидация
        if (TextUtils.isEmpty(subject)) {
            etDocumentSubject.setError("Введите тему документа");
            etDocumentSubject.requestFocus();
            return;
        }

        if (TextUtils.isEmpty(yearStr)) {
            etCreationYear.setError("Введите год создания");
            etCreationYear.requestFocus();
            return;
        }

        int year;
        try {
            year = Integer.parseInt(yearStr);
        } catch (NumberFormatException e) {
            etCreationYear.setError("Введите корректный год");
            etCreationYear.requestFocus();
            return;
        }

        if (spinnerType.getSelectedItemPosition() == -1 || documentTypes.isEmpty()) {
            Toast.makeText(this, "Выберите тип документа", Toast.LENGTH_SHORT).show();
            return;
        }

        if (spinnerStudent.getSelectedItemPosition() == -1 || students.isEmpty()) {
            Toast.makeText(this, "Выберите студента", Toast.LENGTH_SHORT).show();
            return;
        }

        int typeId = documentTypes.get(spinnerType.getSelectedItemPosition()).getTypeId();
        int studentId = students.get(spinnerStudent.getSelectedItemPosition()).getStudentId();
        int boxId = -1;

        if (spinnerBox.getSelectedItemPosition() != -1 && !boxes.isEmpty()) {
            boxId = boxes.get(spinnerBox.getSelectedItemPosition()).getBoxId();
        }

        Document document = new Document(subject, year, typeId, supervisor, studentId, boxId);
        document.setDeleted(cbIsDelete.isChecked());

        if (docId == -1) {
            long id = dbHelper.insertDocument(document);
            if (id != -1) {
                Toast.makeText(this, "Документ добавлен", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при добавлении", Toast.LENGTH_LONG).show();
            }
        } else {
            document.setDocId(docId);
            int rows = dbHelper.updateDocument(document);
            if (rows > 0) {
                Toast.makeText(this, "Данные обновлены", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при обновлении", Toast.LENGTH_LONG).show();
            }
        }
    }

    @Override
    public boolean onSupportNavigateUp() {
        finish();
        return true;
    }
}