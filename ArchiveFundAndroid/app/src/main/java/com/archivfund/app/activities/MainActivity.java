package com.archivfund.app.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.archivfund.app.R;
import com.archivfund.app.adapters.GenericListAdapter;
import com.google.android.material.navigation.NavigationView;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * Главная активность приложения
 * Адаптирована из C# MainForm.cs
 */
public class MainActivity extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {
    
    public enum Table {
        NONE,
        BOXES,
        DELETED_DOCUMENTS,
        DELETED_STUDENTS_PERS_FILES,
        DOCUMENTS,
        DOCUMENT_TYPES,
        GROUP,
        STUDENT,
        STUDENTS_PERS_FILES,
        USER
    }
    
    private RecyclerView recyclerView;
    private GenericListAdapter adapter;
    private TextView statusLabel;
    private TextView headerUserinfo;
    
    private Table currentTable = Table.NONE;
    private String userLogin;
    private String userFio;
    private User.Role userRole;
    
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        
        // Получаем данные пользователя
        Intent intent = getIntent();
        userLogin = intent.getStringExtra("login");
        userFio = intent.getStringExtra("fio");
        String roleStr = intent.getStringExtra("role");
        userRole = User.Role.valueOf(roleStr != null ? roleStr : "NONE");
        
        initViews();
        setupToolbar();
        setupNavigationDrawer();
        updateUserInfo();
    }
    
    private void initViews() {
        recyclerView = findViewById(R.id.recyclerView);
        statusLabel = findViewById(R.id.statusLabel);
        headerUserinfo = findViewById(R.id.headerUserinfo);
        
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        adapter = new GenericListAdapter(this, new ArrayList<>());
        recyclerView.setAdapter(adapter);
    }
    
    private void setupToolbar() {
        androidx.appcompat.widget.Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        
        if (getSupportActionBar() != null) {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
            getSupportActionBar().setTitle("ArchiveFund");
        }
    }
    
    private void setupNavigationDrawer() {
        NavigationView navigationView = findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
        
        // Скрываем пункт меню пользователей если не админ
        Menu menu = navigationView.getMenu();
        MenuItem usersMenuItem = menu.findItem(R.id.nav_users);
        if (usersMenuItem != null) {
            usersMenuItem.setVisible(userRole == User.Role.ADMIN);
        }
    }
    
    private void updateUserInfo() {
        if (headerUserinfo != null) {
            StringBuilder sb = new StringBuilder("ArchiveFund");
            if (userLogin != null) {
                sb.append(" >- ").append(userLogin).append(" <-");
            }
            if (userFio != null) {
                sb.append(": >- ").append(userFio).append(" <-");
            }
            headerUserinfo.setText(sb.toString());
        }
    }
    
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        int itemId = item.getItemId();
        
        if (itemId == R.id.nav_boxes) {
            currentTable = Table.BOXES;
            showTable();
        } else if (itemId == R.id.nav_groups) {
            currentTable = Table.GROUP;
            showTable();
        } else if (itemId == R.id.nav_students) {
            currentTable = Table.STUDENT;
            showTable();
        } else if (itemId == R.id.nav_documents) {
            currentTable = Table.DOCUMENTS;
            showTable();
        } else if (itemId == R.id.nav_document_types) {
            currentTable = Table.DOCUMENT_TYPES;
            showTable();
        } else if (itemId == R.id.nav_persfiles) {
            currentTable = Table.STUDENTS_PERS_FILES;
            showTable();
        } else if (itemId == R.id.nav_users) {
            if (userRole == User.Role.ADMIN) {
                currentTable = Table.USER;
                showTable();
            } else {
                Toast.makeText(this, "Доступно только администраторам", Toast.LENGTH_SHORT).show();
            }
        } else if (itemId == R.id.nav_logout) {
            logout();
        }
        
        return true;
    }
    
    private void showTable() {
        // Здесь будет логика загрузки данных из БД
        // Пока заглушка
        List<Map<String, Object>> data = new ArrayList<>();
        adapter.setData(data);
        adapter.notifyDataSetChanged();
        
        statusLabel.setText("Получено " + data.size() + " строк");
    }
    
    private void logout() {
        Intent intent = new Intent(this, LoginActivity.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
        startActivity(intent);
        finish();
    }
    
    @Override
    public void onBackPressed() {
        // Закрываем приложение или возвращаемся к главному экрану
        super.onBackPressed();
    }
}
