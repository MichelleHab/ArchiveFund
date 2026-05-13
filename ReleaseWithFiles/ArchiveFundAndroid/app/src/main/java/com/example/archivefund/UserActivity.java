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
import com.example.archivefund.User;

import java.util.ArrayList;
import java.util.List;

public class UserActivity extends AppCompatActivity {
    private EditText etFIO, etLogin, etPassword;
    private Spinner spinnerRole;
    private Button btnSave, btnCancel;

    private DatabaseHelper dbHelper;
    private int userId = -1;
    private String[] roles = {"Admin", "Manager"};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user);

        dbHelper = new DatabaseHelper(this);

        initViews();
        setupToolbar();
        setupSpinner();
        loadDataIfEdit();
        setupListeners();
    }

    private void initViews() {
        etFIO = findViewById(R.id.etFIO);
        etLogin = findViewById(R.id.etLogin);
        etPassword = findViewById(R.id.etPassword);
        spinnerRole = findViewById(R.id.spinnerRole);
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

    private void setupSpinner() {
        ArrayAdapter<String> adapter = new ArrayAdapter<>(this,
                android.R.layout.simple_spinner_item, roles);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerRole.setAdapter(adapter);
    }

    private void loadDataIfEdit() {
        userId = getIntent().getIntExtra("user_id", -1);
        if (userId != -1) {
            setTitle("Редактирование пользователя");
            loadUserData();
        } else {
            setTitle("Добавление пользователя");
        }
    }

    private void loadUserData() {
        List<User> users = dbHelper.getAllUsers();
        for (User user : users) {
            if (user.getUserId() == userId) {
                etFIO.setText(user.getFio());
                etLogin.setText(user.getLogin());
                // Пароль не загружаем для безопасности
                etPassword.setHint("Оставьте пустым, чтобы не менять");

                // Установка роли
                for (int i = 0; i < roles.length; i++) {
                    if (roles[i].equals(user.getRole())) {
                        spinnerRole.setSelection(i);
                        break;
                    }
                }
                break;
            }
        }
    }

    private void setupListeners() {
        btnSave.setOnClickListener(v -> saveUser());
        btnCancel.setOnClickListener(v -> finish());
    }

    private void saveUser() {
        String fio = etFIO.getText().toString().trim();
        String login = etLogin.getText().toString().trim();
        String password = etPassword.getText().toString().trim();
        String role = spinnerRole.getSelectedItem().toString();

        // Валидация
        if (TextUtils.isEmpty(login)) {
            etLogin.setError("Введите логин");
            etLogin.requestFocus();
            return;
        }

        if (TextUtils.isEmpty(password) && userId == -1) {
            etPassword.setError("Введите пароль");
            etPassword.requestFocus();
            return;
        }

        if (TextUtils.isEmpty(fio)) {
            etFIO.setText(login); // Если ФИО не указано, используем логин
        }

        User user = new User(fio, role, login, password);

        if (userId == -1) {
            // Добавление нового пользователя
            long id = dbHelper.insertUser(user);
            if (id != -1) {
                Toast.makeText(this, "Пользователь добавлен", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при добавлении. Возможно, логин уже существует",
                        Toast.LENGTH_LONG).show();
            }
        } else {
            // Обновление существующего
            user.setUserId(userId);
            if (TextUtils.isEmpty(password)) {
                user.setPassword(null); // Не меняем пароль
            }
            int rows = dbHelper.updateUser(user);
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