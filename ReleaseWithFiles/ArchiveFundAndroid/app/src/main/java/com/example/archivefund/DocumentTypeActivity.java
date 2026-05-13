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
import com.example.archivefund.DocumentType;

import java.util.List;
public class DocumentTypeActivity extends AppCompatActivity {
    private EditText etTypeName;
    private Button btnSave, btnCancel;

    private DatabaseHelper dbHelper;
    private int typeId = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_document_type);

        dbHelper = new DatabaseHelper(this);

        initViews();
        setupToolbar();
        loadDataIfEdit();
        setupListeners();
    }

    private void initViews() {
        etTypeName = findViewById(R.id.etTypeName);
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
        typeId = getIntent().getIntExtra("type_id", -1);
        if (typeId != -1) {
            setTitle("Редактирование типа документа");
            loadTypeData();
        } else {
            setTitle("Добавление типа документа");
        }
    }

    private void loadTypeData() {
        List<DocumentType> types = dbHelper.getAllDocumentTypes();
        for (DocumentType type : types) {
            if (type.getTypeId() == typeId) {
                etTypeName.setText(type.getTypeName());
                break;
            }
        }
    }

    private void setupListeners() {
        btnSave.setOnClickListener(v -> saveDocumentType());
        btnCancel.setOnClickListener(v -> finish());
    }

    private void saveDocumentType() {
        String typeName = etTypeName.getText().toString().trim();

        if (TextUtils.isEmpty(typeName)) {
            etTypeName.setError("Введите название типа документа");
            etTypeName.requestFocus();
            return;
        }

        DocumentType documentType = new DocumentType(typeName);

        if (typeId == -1) {
            long id = dbHelper.insertDocumentType(documentType);
            if (id != -1) {
                Toast.makeText(this, "Тип документа добавлен", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при добавлении", Toast.LENGTH_LONG).show();
            }
        } else {
            documentType.setTypeId(typeId);
            int rows = dbHelper.updateDocumentType(documentType);
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