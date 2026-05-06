package com.archivfund.app.activities;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.archivfund.app.R;
import com.archivfund.app.models.User;
import com.archivfund.app.network.DatabaseHelper;
import com.archivfund.app.utils.ConfigManager;

import java.util.Map;

/**
 * Активность авторизации
 * Адаптирована из C# Authorization.cs
 */
public class LoginActivity extends AppCompatActivity {
    
    private EditText editTextLogin;
    private EditText editTextPassword;
    private Button buttonLogin;
    private ProgressBar progressBar;
    private TextView textViewTitle;
    
    private ConfigManager configManager;
    private DatabaseHelper dbHelper;
    private Handler handler;
    
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        
        initViews();
        
        configManager = new ConfigManager(this);
        handler = new Handler(Looper.getMainLooper());
        
        setupLoginButton();
    }
    
    private void initViews() {
        editTextLogin = findViewById(R.id.editTextLogin);
        editTextPassword = findViewById(R.id.editTextPassword);
        buttonLogin = findViewById(R.id.buttonLogin);
        progressBar = findViewById(R.id.progressBar);
        textViewTitle = findViewById(R.id.textViewTitle);
        
        textViewTitle.setText("Авторизация");
    }
    
    private void setupLoginButton() {
        buttonLogin.setOnClickListener(v -> performLogin());
    }
    
    private void performLogin() {
        String login = editTextLogin.getText().toString().trim();
        String password = editTextPassword.getText().toString().trim();
        
        // Валидация ввода
        if (login.isEmpty()) {
            editTextLogin.setError("Не введен логин!");
            editTextLogin.requestFocus();
            Toast.makeText(this, "Не введен логин!", Toast.LENGTH_SHORT).show();
            return;
        }
        
        if (password.isEmpty()) {
            editTextPassword.setError("Не введен пароль!");
            editTextPassword.requestFocus();
            Toast.makeText(this, "Не введен пароль!", Toast.LENGTH_SHORT).show();
            return;
        }
        
        // Показываем индикатор загрузки
        showLoading(true);
        
        // Выполняем авторизацию в фоновом потоке
        new Thread(() -> {
            try {
                dbHelper = new DatabaseHelper(
                    configManager.getServer(),
                    configManager.getPort(),
                    configManager.getDatabase(),
                    configManager.getUser(),
                    configManager.getPassword()
                );
                
                Map<String, Object> result = dbHelper.authenticateUser(login, password);
                
                handler.post(() -> {
                    showLoading(false);
                    
                    Boolean success = (Boolean) result.get("success");
                    if (success != null && success) {
                        // Успешная авторизация
                        User.Role role = User.parseRole((String) result.get("role"));
                        String fio = (String) result.get("fio");
                        
                        Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                        intent.putExtra("user_id", (Integer) result.get("user_id"));
                        intent.putExtra("login", login);
                        intent.putExtra("fio", fio);
                        intent.putExtra("role", role.toString());
                        startActivity(intent);
                        finish();
                    } else {
                        // Ошибка авторизации
                        String error = (String) result.get("error");
                        Toast.makeText(LoginActivity.this, 
                            error != null ? error : "Ошибка авторизации", 
                            Toast.LENGTH_SHORT).show();
                    }
                });
                
            } catch (Exception e) {
                handler.post(() -> {
                    showLoading(false);
                    Toast.makeText(LoginActivity.this, 
                        "Ошибка подключения: " + e.getMessage(), 
                        Toast.LENGTH_LONG).show();
                });
            }
        }).start();
    }
    
    private void showLoading(boolean isLoading) {
        if (isLoading) {
            progressBar.setVisibility(View.VISIBLE);
            buttonLogin.setEnabled(false);
            editTextLogin.setEnabled(false);
            editTextPassword.setEnabled(false);
        } else {
            progressBar.setVisibility(View.GONE);
            buttonLogin.setEnabled(true);
            editTextLogin.setEnabled(true);
            editTextPassword.setEnabled(true);
        }
    }
}
