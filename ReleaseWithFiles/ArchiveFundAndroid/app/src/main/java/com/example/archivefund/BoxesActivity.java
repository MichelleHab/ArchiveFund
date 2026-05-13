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
import com.example.archivefund.DocumentType;
import com.example.archivefund.Group;

import java.util.ArrayList;
import java.util.List;

public class BoxesActivity extends AppCompatActivity {
    private EditText etRackNumber, etShelfNumber, etBoxName, etYearWork;
    private Spinner spinnerGroup, spinnerType;
    private CheckBox cbNoSaveDate;
    private Button btnSave, btnCancel;

    private DatabaseHelper dbHelper;
    private int boxId = -1;

    private List<Group> groups;
    private List<DocumentType> documentTypes;
    private ArrayAdapter<String> groupAdapter, typeAdapter;
    private List<String> groupNames, typeNames;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_boxes);

        dbHelper = new DatabaseHelper(this);

        initViews();
        setupToolbar();
        loadDataFromDb();
        setupSpinners();
        loadDataIfEdit();
        setupListeners();

        // Автозаполнение имени коробки
        setupAutoBoxName();
    }

    private void initViews() {
        etRackNumber = findViewById(R.id.etRackNumber);
        etShelfNumber = findViewById(R.id.etShelfNumber);
        etBoxName = findViewById(R.id.etBoxName);
        etYearWork = findViewById(R.id.etYearWork);
        spinnerGroup = findViewById(R.id.spinnerGroup);
        spinnerType = findViewById(R.id.spinnerType);
        cbNoSaveDate = findViewById(R.id.cbNoSaveDate);
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
        groups = dbHelper.getAllGroups();
        documentTypes = dbHelper.getAllDocumentTypes();

        groupNames = new ArrayList<>();
        groupNames.add("(Не выбрана)");
        for (Group group : groups) {
            groupNames.add(group.getGroupName());
        }

        typeNames = new ArrayList<>();
        for (DocumentType type : documentTypes) {
            typeNames.add(type.getTypeName());
        }
    }

    private void setupSpinners() {
        groupAdapter = new ArrayAdapter<>(this,
                android.R.layout.simple_spinner_item, groupNames);
        groupAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerGroup.setAdapter(groupAdapter);

        typeAdapter = new ArrayAdapter<>(this,
                android.R.layout.simple_spinner_item, typeNames);
        typeAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerType.setAdapter(typeAdapter);
    }

    private void loadDataIfEdit() {
        boxId = getIntent().getIntExtra("box_id", -1);
        if (boxId != -1) {
            setTitle("Редактирование коробки");
            loadBoxData();
        } else {
            setTitle("Добавление коробки");
        }
    }

    private void loadBoxData() {
        Box box = dbHelper.getBoxById(boxId);
        if (box != null) {
            etRackNumber.setText(String.valueOf(box.getRackNumber()));
            etShelfNumber.setText(String.valueOf(box.getShelfNumber()));
            etBoxName.setText(box.getBoxName());

            if (box.getYearWork() > 0) {
                cbNoSaveDate.setChecked(false);
                etYearWork.setEnabled(true);
                etYearWork.setText(String.valueOf(box.getYearWork()));
            } else {
                cbNoSaveDate.setChecked(true);
                etYearWork.setEnabled(false);
            }

            // Установка группы
            if (box.getGroupId() > 0) {
                for (int i = 0; i < groups.size(); i++) {
                    if (groups.get(i).getGroupId() == box.getGroupId()) {
                        spinnerGroup.setSelection(i + 1); // +1 из-за "(Не выбрана)"
                        break;
                    }
                }
            }

            // Установка типа
            for (int i = 0; i < documentTypes.size(); i++) {
                if (documentTypes.get(i).getTypeId() == box.getTypeId()) {
                    spinnerType.setSelection(i);
                    break;
                }
            }
        }
    }

    private void setupAutoBoxName() {
        android.text.TextWatcher textWatcher = new android.text.TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {}

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {}

            @Override
            public void afterTextChanged(android.text.Editable s) {
                autoGenerateBoxName();
            }
        };

        etRackNumber.addTextChangedListener(textWatcher);
        etShelfNumber.addTextChangedListener(textWatcher);

        etBoxName.setOnFocusChangeListener((v, hasFocus) -> {
            if (hasFocus && TextUtils.isEmpty(etBoxName.getText())) {
                autoGenerateBoxName();
            }
        });
    }

    private void autoGenerateBoxName() {
        String rack = etRackNumber.getText().toString().trim();
        String shelf = etShelfNumber.getText().toString().trim();

        if (!TextUtils.isEmpty(rack) && !TextUtils.isEmpty(shelf) &&
                TextUtils.isEmpty(etBoxName.getText().toString())) {
            String boxName = "Box:" + rack + "-" + shelf;
            etBoxName.setText(boxName);
        }
    }

    private void setupListeners() {
        btnSave.setOnClickListener(v -> saveBox());
        btnCancel.setOnClickListener(v -> finish());

        cbNoSaveDate.setOnCheckedChangeListener((buttonView, isChecked) -> {
            etYearWork.setEnabled(!isChecked);
            if (isChecked) {
                etYearWork.setText("");
            }
        });
    }

    private void saveBox() {
        String rackStr = etRackNumber.getText().toString().trim();
        String shelfStr = etShelfNumber.getText().toString().trim();
        String boxName = etBoxName.getText().toString().trim();
        String yearWorkStr = etYearWork.getText().toString().trim();

        int rackNumber = 0;
        int shelfNumber = 0;

        if (!TextUtils.isEmpty(rackStr)) {
            try {
                rackNumber = Integer.parseInt(rackStr);
            } catch (NumberFormatException e) {
                etRackNumber.setError("Введите корректный номер");
                etRackNumber.requestFocus();
                return;
            }
        }

        if (!TextUtils.isEmpty(shelfStr)) {
            try {
                shelfNumber = Integer.parseInt(shelfStr);
            } catch (NumberFormatException e) {
                etShelfNumber.setError("Введите корректный номер");
                etShelfNumber.requestFocus();
                return;
            }
        }

        if (spinnerType.getSelectedItemPosition() == -1 || documentTypes.isEmpty()) {
            Toast.makeText(this, "Выберите тип документов", Toast.LENGTH_SHORT).show();
            return;
        }

        int groupId = -1;
        if (spinnerGroup.getSelectedItemPosition() > 0 && !groups.isEmpty()) {
            groupId = groups.get(spinnerGroup.getSelectedItemPosition() - 1).getGroupId();
        }

        int typeId = documentTypes.get(spinnerType.getSelectedItemPosition()).getTypeId();

        int yearWork = 0;
        if (!cbNoSaveDate.isChecked() && !TextUtils.isEmpty(yearWorkStr)) {
            try {
                yearWork = Integer.parseInt(yearWorkStr);
            } catch (NumberFormatException e) {
                etYearWork.setError("Введите корректный год");
                etYearWork.requestFocus();
                return;
            }
        }

        Box box = new Box(boxName, rackNumber, shelfNumber, groupId, typeId, yearWork);

        if (boxId == -1) {
            long id = dbHelper.insertBox(box);
            if (id != -1) {
                Toast.makeText(this, "Коробка добавлена", Toast.LENGTH_SHORT).show();
                setResult(RESULT_OK);
                finish();
            } else {
                Toast.makeText(this, "Ошибка при добавлении", Toast.LENGTH_LONG).show();
            }
        } else {
            box.setBoxId(boxId);
            int rows = dbHelper.updateBox(box);
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