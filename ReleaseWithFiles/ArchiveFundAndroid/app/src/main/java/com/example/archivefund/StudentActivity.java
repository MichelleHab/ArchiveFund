package com.example.archivefund;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import com.example.archivefund.R;
import com.example.archivefund.DatabaseHelper;
import com.example.archivefund.Group;
import com.example.archivefund.PersonalFile;
import com.example.archivefund.Student;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class StudentActivity extends AppCompatActivity {
    private EditText etFullName;
    private Spinner spinnerGroup;
    private DatePicker dpAdmissionYear, dpDeductionYear;
    private EditText etReason;
    private CheckBox cbNoDeductionDate, cbIsDelete;
    private Button btnSave, btnCancel;

    private DatabaseHelper dbHelper;
    private int studentId = -1;
    private int persFileId = -1;
    private boolean isDeletedPersonalFile = false;
    private List<Group> groups;
    private ArrayAdapter<String> groupAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_student);

        dbHelper = new DatabaseHelper(this);

        initViews();
        setupToolbar();
        loadGroups();
        loadDataIfEdit();
        setupListeners();
    }

    private void initViews() {
        etFullName = findViewById(R.id.etFullName);
        spinnerGroup = findViewById(R.id.spinnerGroup);
        dpAdmissionYear = findViewById(R.id.dpAdmissionYear);
        dpDeductionYear = findViewById(R.id.dpDeductionYear);
        etReason = findViewById(R.id.etReason);
        cbNoDeductionDate = findViewById(R.id.cbNoDeductionDate);
        cbIsDelete = findViewById(R.id.cbIsDelete);
        btnSave = findViewById(R.id.btnSave);
        btnCancel = findViewById(R.id.btnCancel);

        // Скрываем чекбокс удаления, если это не нужно
        cbIsDelete.setVisibility(View.GONE);
    }

    private void setupToolbar() {
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        if (getSupportActionBar() != null) {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        }
    }

    private void loadGroups() {
        groups = dbHelper.getAllGroups();
        List<String> groupNames = new ArrayList<>();
        for (Group group : groups) {
            groupNames.add(group.getGroupName());
        }
        groupAdapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, groupNames);
        groupAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerGroup.setAdapter(groupAdapter);
    }

    private void loadDataIfEdit() {
        studentId = getIntent().getIntExtra("student_id", -1);
        persFileId = getIntent().getIntExtra("pers_file_id", -1);
        isDeletedPersonalFile = getIntent().getBooleanExtra("is_deleted", false);

        if (studentId != -1) {
            setTitle("Редактирование студента");
            loadStudentData();
        } else if (persFileId != -1) {
            setTitle("Редактирование личного дела");
            loadPersonalFileData();
        } else {
            setTitle("Добавление студента");
        }
    }

    private void loadStudentData() {
        List<Student> students = dbHelper.getAllStudents();
        for (Student student : students) {
            if (student.getStudentId() == studentId) {
                etFullName.setText(student.getFullName());

                // Установка группы
                for (int i = 0; i < groups.size(); i++) {
                    if (groups.get(i).getGroupId() == student.getGroupId()) {
                        spinnerGroup.setSelection(i);
                        break;
                    }
                }

                // Загружаем личное дело студента
                PersonalFile pf = dbHelper.getPersonalFileByStudentId(studentId, false);
                if (pf != null) {
                    dpAdmissionYear.updateDate(pf.getAdmissionYear(), 0, 1);
                    if (pf.getDeductionYear() > 0) {
                        dpDeductionYear.updateDate(pf.getDeductionYear(), 0, 1);
                        cbNoDeductionDate.setChecked(false);
                    } else {
                        cbNoDeductionDate.setChecked(true);
                        dpDeductionYear.setEnabled(false);
                    }
                    if (pf.getReason() != null) {
                        etReason.setText(pf.getReason());
                    }
                    persFileId = pf.getPersFileId();
                }
                break;
            }
        }
    }

    private void loadPersonalFileData() {
        PersonalFile pf = dbHelper.getPersonalFileById(persFileId, isDeletedPersonalFile);
        if (pf != null) {
            // Загружаем данные студента
            Student student = dbHelper.getStudentById(pf.getStudentId());
            if (student != null) {
                etFullName.setText(student.getFullName());

                // Установка группы
                for (int i = 0; i < groups.size(); i++) {
                    if (groups.get(i).getGroupId() == student.getGroupId()) {
                        spinnerGroup.setSelection(i);
                        break;
                    }
                }
                studentId = student.getStudentId();
            }

            // Загружаем данные личного дела
            dpAdmissionYear.updateDate(pf.getAdmissionYear(), 0, 1);
            if (pf.getDeductionYear() > 0) {
                dpDeductionYear.updateDate(pf.getDeductionYear(), 0, 1);
                cbNoDeductionDate.setChecked(false);
            } else {
                cbNoDeductionDate.setChecked(true);
                dpDeductionYear.setEnabled(false);
            }
            if (pf.getReason() != null) {
                etReason.setText(pf.getReason());
            }

            // Показываем информационное сообщение
            if (isDeletedPersonalFile) {
                Toast.makeText(this, "Редактирование удаленного личного дела", Toast.LENGTH_LONG).show();
            }
        } else {
            Toast.makeText(this, "Личное дело не найдено", Toast.LENGTH_SHORT).show();
            finish();
        }
    }

    private void setupListeners() {
        btnSave.setOnClickListener(v -> saveStudent());
        btnCancel.setOnClickListener(v -> finish());

        cbNoDeductionDate.setOnCheckedChangeListener((buttonView, isChecked) -> {
            dpDeductionYear.setEnabled(!isChecked);
        });
    }

    private void saveStudent() {
        String fullName = etFullName.getText().toString().trim();

        if (fullName.isEmpty()) {
            etFullName.setError("Введите ФИО студента");
            etFullName.requestFocus();
            return;
        }

        if (spinnerGroup.getSelectedItemPosition() == -1) {
            Toast.makeText(this, "Выберите группу", Toast.LENGTH_SHORT).show();
            return;
        }

        int groupId = groups.get(spinnerGroup.getSelectedItemPosition()).getGroupId();

        // Получаем или создаем студента
        if (studentId == -1) {
            // Создаем нового студента
            Student student = new Student(fullName, groupId);

            int admissionYear = dpAdmissionYear.getYear();
            int deductionYear = cbNoDeductionDate.isChecked() ? 0 : dpDeductionYear.getYear();
            String reason = etReason.getText().toString().trim();

            PersonalFile personalFile = new PersonalFile(admissionYear, deductionYear, reason);
            student.setPersonalFile(personalFile);

            long id = dbHelper.insertStudent(student);
            if (id != -1) {
                Toast.makeText(this, "Студент добавлен", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при добавлении", Toast.LENGTH_LONG).show();
            }
        } else if (persFileId != -1) {
            // Редактируем существующее личное дело
            int admissionYear = dpAdmissionYear.getYear();
            int deductionYear = cbNoDeductionDate.isChecked() ? 0 : dpDeductionYear.getYear();
            String reason = etReason.getText().toString().trim();

            PersonalFile personalFile = new PersonalFile(admissionYear, deductionYear, reason);
            personalFile.setPersFileId(persFileId);
            personalFile.setStudentId(studentId);
            personalFile.setDeleted(isDeletedPersonalFile);

            int rows = dbHelper.updatePersonalFile(personalFile);
            if (rows > 0) {
                Toast.makeText(this, "Личное дело обновлено", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при обновлении личного дела", Toast.LENGTH_LONG).show();
            }
        } else {
            // Обновляем студента и его личное дело
            Student student = new Student(fullName, groupId);
            student.setStudentId(studentId);

            int rows = dbHelper.updateStudent(student);

            // Обновляем личное дело
            int admissionYear = dpAdmissionYear.getYear();
            int deductionYear = cbNoDeductionDate.isChecked() ? 0 : dpDeductionYear.getYear();
            String reason = etReason.getText().toString().trim();

            PersonalFile personalFile = new PersonalFile(admissionYear, deductionYear, reason);
            personalFile.setPersFileId(persFileId);
            personalFile.setStudentId(studentId);
            personalFile.setDeleted(isDeletedPersonalFile);

            int pfRows = dbHelper.updatePersonalFile(personalFile);

            if (rows > 0 || pfRows > 0) {
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