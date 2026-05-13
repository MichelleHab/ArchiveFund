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
import com.example.archivefund.Group;

import java.util.List;

public class GroupActivity extends AppCompatActivity {
    private EditText etGroupName, etFormationYear, etSpecialization;
    private Button btnSave, btnCancel;

    private DatabaseHelper dbHelper;
    private int groupId = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_group);

        dbHelper = new DatabaseHelper(this);

        initViews();
        setupToolbar();
        loadDataIfEdit();
        setupListeners();
    }

    private void initViews() {
        etGroupName = findViewById(R.id.etGroupName);
        etFormationYear = findViewById(R.id.etFormationYear);
        etSpecialization = findViewById(R.id.etSpecialization);
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

    private void loadDataIfEdit() {
        groupId = getIntent().getIntExtra("group_id", -1);
        if (groupId != -1) {
            setTitle("Редактирование группы");
            loadGroupData();
        } else {
            setTitle("Добавление группы");
        }
    }

    private void loadGroupData() {
        List<Group> groups = dbHelper.getAllGroups();
        for (Group group : groups) {
            if (group.getGroupId() == groupId) {
                etGroupName.setText(group.getGroupName());
                etFormationYear.setText(String.valueOf(group.getFormationYear()));
                etSpecialization.setText(group.getSpecialization());
                break;
            }
        }
    }

    private void setupListeners() {
        btnSave.setOnClickListener(v -> saveGroup());
        btnCancel.setOnClickListener(v -> finish());
    }

    private void saveGroup() {
        String groupName = etGroupName.getText().toString().trim();
        String formationYearStr = etFormationYear.getText().toString().trim();
        String specialization = etSpecialization.getText().toString().trim();

        // Валидация
        if (TextUtils.isEmpty(groupName)) {
            etGroupName.setError("Введите название группы");
            etGroupName.requestFocus();
            return;
        }

        if (TextUtils.isEmpty(specialization)) {
            etSpecialization.setError("Введите специализацию");
            etSpecialization.requestFocus();
            return;
        }

        int formationYear = 2024;
        if (!TextUtils.isEmpty(formationYearStr)) {
            try {
                formationYear = Integer.parseInt(formationYearStr);
            } catch (NumberFormatException e) {
                etFormationYear.setError("Введите корректный год");
                etFormationYear.requestFocus();
                return;
            }
        }

        Group group = new Group(groupName, formationYear, specialization);

        if (groupId == -1) {
            long id = dbHelper.insertGroup(group);
            if (id != -1) {
                Toast.makeText(this, "Группа добавлена", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при добавлении", Toast.LENGTH_LONG).show();
            }
        } else {
            group.setGroupId(groupId);
            int rows = dbHelper.updateGroup(group);
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