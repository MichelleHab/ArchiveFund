package com.example.archivefund;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.SubMenu;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.SearchView;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class MainActivity extends AppCompatActivity
        implements TableAdapter.OnItemClickListener
{

    private RecyclerView recyclerView;
    private TableAdapter adapter;
    private DatabaseHelper dbHelper;
    private SessionManager sessionManager;
    private SearchView searchView;
    private FloatingActionButton fabAdd, fabEdit, fabDelete;

    private TableType currentTable = TableType.STUDENTS;
    private List<Object> currentData = new ArrayList<>();

    public enum TableType {
        USERS, STUDENTS, GROUPS, DOCUMENTS, DELETED_DOCUMENTS,
        BOXES, DOCUMENT_TYPES, PERSONAL_FILES, DELETED_PERSONAL_FILES, NONE
    }

    private BackupManager backupManager;
    private static final int REQUEST_RESTORE_BACKUP = 100;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        backupManager = new BackupManager(this);
        dbHelper = new DatabaseHelper(this);

        sessionManager = new SessionManager(this);

        setupToolbar();
        initViews();
        setupRecyclerView();
        setupListeners();

        switchToTable(TableType.STUDENTS);
        updateFabVisibility(false);
    }

    private void setupToolbar() {
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        if (getSupportActionBar() != null) {
            getSupportActionBar().setTitle("Архивный фонд");

            // Показываем и ФИО, и логин
            String userFio = sessionManager.getUserFio();
            String userLogin = sessionManager.getUserLogin();
            String subtitle = "";
            if (userFio != null && !userFio.isEmpty()) {
                subtitle = userFio;
                if (userLogin != null && !userLogin.isEmpty()) {
                    subtitle += " (" + userLogin + ")";
                }
            } else if (userLogin != null && !userLogin.isEmpty()) {
                subtitle = userLogin;
            }
            if (!subtitle.isEmpty()) {
                getSupportActionBar().setSubtitle(subtitle);
            }
        }
    }

    private void initViews() {
        recyclerView = findViewById(R.id.recyclerView);
        fabAdd = findViewById(R.id.fabAdd);
        fabEdit = findViewById(R.id.fabEdit);
        fabDelete = findViewById(R.id.fabDelete);
        searchView = findViewById(R.id.searchView);
    }

    private void setupRecyclerView() {
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        adapter = new TableAdapter(this);
        recyclerView.setAdapter(adapter);
    }

    private void setupListeners() {
        fabAdd.setOnClickListener(v -> onAddClick());
        fabEdit.setOnClickListener(v -> onEditClick());
        fabDelete.setOnClickListener(v -> onDeleteClick());

        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                performSearch(query);
                return true;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                performSearch(newText);
                return true;
            }
        });
    }

    private void performSearch(String query) {
        if (query == null || query.isEmpty()) {
            loadData();
            return;
        }

        String searchQuery = query.toLowerCase().trim();
        List<Object> filtered = new ArrayList<>();

        for (Object item : currentData) {
            if (item instanceof Student) {
                Student student = (Student) item;
                if (student.getFullName().toLowerCase().contains(searchQuery) ||
                        (student.getGroupName() != null && student.getGroupName().toLowerCase().contains(searchQuery))) {
                    filtered.add(item);
                }
            } else if (item instanceof Group) {
                Group group = (Group) item;
                if (group.getGroupName().toLowerCase().contains(searchQuery) ||
                        group.getSpecialization().toLowerCase().contains(searchQuery)) {
                    filtered.add(item);
                }
            } else if (item instanceof Document) {
                Document doc = (Document) item;
                if (doc.getDocumentSubject().toLowerCase().contains(searchQuery) ||
                        (doc.getStudentName() != null && doc.getStudentName().toLowerCase().contains(searchQuery))) {
                    filtered.add(item);
                }
            } else if (item instanceof User) {
                User user = (User) item;
                if (user.getFio().toLowerCase().contains(searchQuery) ||
                        user.getLogin().toLowerCase().contains(searchQuery)) {
                    filtered.add(item);
                }
            } else if (item instanceof PersonalFile) {
                PersonalFile pf = (PersonalFile) item;
                if (pf.getStudentName() != null && pf.getStudentName().toLowerCase().contains(searchQuery)) {
                    filtered.add(item);
                }
            }
        }
        adapter.setData(filtered);
    }

    private void switchToTable(TableType table) {
        currentTable = table;
        loadData();
    }

    private void loadData() {
        switch (currentTable) {
            case USERS:
                if (sessionManager.isAdmin()) {
                    currentData = new ArrayList<>(dbHelper.getAllUsers());
                    adapter.setData(currentData);
                } else {
                    Toast.makeText(this, "Недостаточно прав", Toast.LENGTH_SHORT).show();
                }
                break;
            case STUDENTS:
                currentData = new ArrayList<>(dbHelper.getAllStudents());
                adapter.setData(currentData);
                break;
            case PERSONAL_FILES:
                currentData = new ArrayList<>(dbHelper.getAllPersonalFiles(false));
                adapter.setData(currentData);
                break;
            case DELETED_PERSONAL_FILES:
                if (sessionManager.isAdmin()) {
                    currentData = new ArrayList<>(dbHelper.getAllPersonalFiles(true));
                    adapter.setData(currentData);
                } else {
                    Toast.makeText(this, "Недостаточно прав", Toast.LENGTH_SHORT).show();
                }
                break;
            case GROUPS:
                currentData = new ArrayList<>(dbHelper.getAllGroups());
                adapter.setData(currentData);
                break;
            case DOCUMENTS:
                currentData = new ArrayList<>(dbHelper.getAllDocuments(false));
                adapter.setData(currentData);
                break;
            case DELETED_DOCUMENTS:
                if (sessionManager.isAdmin()) {
                    currentData = new ArrayList<>(dbHelper.getAllDocuments(true));
                    adapter.setData(currentData);
                } else {
                    Toast.makeText(this, "Недостаточно прав", Toast.LENGTH_SHORT).show();
                }
                break;
            case BOXES:
                currentData = new ArrayList<>(dbHelper.getAllBoxes());
                adapter.setData(currentData);
                break;
            case DOCUMENT_TYPES:
                currentData = new ArrayList<>(dbHelper.getAllDocumentTypes());
                adapter.setData(currentData);
                break;
            default:
                adapter.setData(new ArrayList<>());
                break;
        }
        adapter.clearSelection();
        updateFabVisibility(false);
    }

    private void updateFabVisibility(boolean hasSelection) {
        fabEdit.setVisibility(hasSelection ? View.VISIBLE : View.GONE);
        fabDelete.setVisibility(hasSelection ? View.VISIBLE : View.GONE);
    }

    private void onAddClick() {
        Intent intent = null;
        switch (currentTable) {
            case USERS:
                intent = new Intent(this, UserActivity.class);
                break;
            case PERSONAL_FILES:
            case DELETED_PERSONAL_FILES:
            case STUDENTS:
                intent = new Intent(this, StudentActivity.class);
                break;
            case GROUPS:
                intent = new Intent(this, GroupActivity.class);
                break;
            case DOCUMENTS:
            case DELETED_DOCUMENTS:
                intent = new Intent(this, DocumentActivity.class);
                intent.putExtra("is_deleted", currentTable == TableType.DELETED_DOCUMENTS);
                break;
            case BOXES:
                intent = new Intent(this, BoxesActivity.class);
                break;
            case DOCUMENT_TYPES:
                intent = new Intent(this, DocumentTypeActivity.class);
                break;
            default:
                return;
        }
        if (intent != null) {
            startActivityForResult(intent, 1);
        }
    }

    private void onEditClick() {
        int selectedId = adapter.getSelectedId();
        if (selectedId == -1) return;

        Intent intent = null;
        switch (currentTable) {
            case USERS:
                intent = new Intent(this, UserActivity.class);
                intent.putExtra("user_id", selectedId);
                break;
            case STUDENTS:
                intent = new Intent(this, StudentActivity.class);
                intent.putExtra("student_id", selectedId);
                break;
            case PERSONAL_FILES:
            case DELETED_PERSONAL_FILES:
                intent = new Intent(this, StudentActivity.class);
                intent.putExtra("pers_file_id", selectedId);
                intent.putExtra("is_deleted", currentTable == TableType.DELETED_PERSONAL_FILES);
                break;
            case GROUPS:
                intent = new Intent(this, GroupActivity.class);
                intent.putExtra("group_id", selectedId);
                break;
            case DOCUMENTS:
            case DELETED_DOCUMENTS:
                intent = new Intent(this, DocumentActivity.class);
                intent.putExtra("doc_id", selectedId);
                intent.putExtra("is_deleted", currentTable == TableType.DELETED_DOCUMENTS);
                break;
            case BOXES:
                intent = new Intent(this, BoxesActivity.class);
                intent.putExtra("box_id", selectedId);
                break;
            case DOCUMENT_TYPES:
                intent = new Intent(this, DocumentTypeActivity.class);
                intent.putExtra("type_id", selectedId);
                break;
            default:
                return;
        }
        if (intent != null) {
            startActivityForResult(intent, 2);
        }
    }

    private void onDeleteClick() {
        int selectedId = adapter.getSelectedId();
        if (selectedId == -1) return;

        new AlertDialog.Builder(this)
                .setTitle("Подтверждение удаления")
                .setMessage("Вы уверены, что хотите удалить выбранную запись?")
                .setPositiveButton("Удалить", (dialog, which) -> performDelete(selectedId))
                .setNegativeButton("Отмена", null)
                .show();
    }

    private void performDelete(int id) {
        switch (currentTable) {
            case USERS:
                dbHelper.deleteUser(id);
                break;
            case STUDENTS:
                dbHelper.deleteStudent(id, false);
                break;
            case PERSONAL_FILES:
                dbHelper.deletePersonalFile(id, false);
                break;
            case DELETED_PERSONAL_FILES:
                dbHelper.deletePersonalFile(id, true);
                break;
            case GROUPS:
                dbHelper.deleteGroup(id);
                break;
            case DOCUMENTS:
                dbHelper.deleteDocument(id, false);
                break;
            case DELETED_DOCUMENTS:
                dbHelper.deleteDocument(id, true);
                break;
            case BOXES:
                dbHelper.deleteBox(id);
                break;
            case DOCUMENT_TYPES:
                dbHelper.deleteDocumentType(id);
                break;
            default:
                break;
        }
        Toast.makeText(this, "Запись удалена", Toast.LENGTH_SHORT).show();
        loadData();
        adapter.clearSelection();
        updateFabVisibility(false);
    }

    // Реализация интерфейса TableAdapter.OnItemClickListener
    @Override
    public void onItemClick(int position, int id) {
        adapter.setSelectedPosition(position);
        updateFabVisibility(id != -1);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);

        if (!sessionManager.isAdmin()) {
            menu.findItem(R.id.action_users).setVisible(false);
            menu.findItem(R.id.action_deleted_documents).setVisible(false);
            menu.findItem(R.id.action_deleted_personal_files).setVisible(false);
            menu.findItem(R.id.action_backup).setVisible(false);
            menu.findItem(R.id.action_restore).setVisible(false);
        }
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.action_users) {
            switchToTable(TableType.USERS);
        } else if (id == R.id.action_students) {
            switchToTable(TableType.STUDENTS);
        } else if (id == R.id.action_personal_files) {
            switchToTable(TableType.PERSONAL_FILES);
        } else if (id == R.id.action_deleted_personal_files) {
            switchToTable(TableType.DELETED_PERSONAL_FILES);
        } else if (id == R.id.action_groups) {
            switchToTable(TableType.GROUPS);
        } else if (id == R.id.action_documents) {
            switchToTable(TableType.DOCUMENTS);
        } else if (id == R.id.action_deleted_documents) {
            switchToTable(TableType.DELETED_DOCUMENTS);
        } else if (id == R.id.action_boxes) {
            switchToTable(TableType.BOXES);
        } else if (id == R.id.action_document_types) {
            switchToTable(TableType.DOCUMENT_TYPES);
        } else if (id == R.id.action_backup) {
            backupManager.createBackup();
        } else if (id == R.id.action_restore) {
            backupManager.startRestore(this, REQUEST_RESTORE_BACKUP);
        }
        else if (id == R.id.action_exit) {
            sessionManager.logout();
            finish();
        }
        return true;
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == REQUEST_RESTORE_BACKUP) {
            backupManager.handleRestoreResult(resultCode, data, () -> {
                loadData();
                adapter.clearSelection();
                updateFabVisibility(false);
                Toast.makeText(this, "База данных восстановлена", Toast.LENGTH_LONG).show();
            });
        } else if (resultCode == RESULT_OK) {
            loadData();
            adapter.clearSelection();
            updateFabVisibility(false);
        }
    }
}