package com.example.archivefund;

public class Document {
    private int docId;
    private String documentSubject;
    private int startData;
    private int typeId;
    private String typeName;
    private String supervisorFullName;
    private int studentId;
    private String studentName;
    private int boxId;
    private String boxName;
    private boolean isDeleted;

    // Конструкторы
    public Document() {}

    public Document(String documentSubject, int startData, int typeId,
                    String supervisorFullName, int studentId, int boxId) {
        this.documentSubject = documentSubject;
        this.startData = startData;
        this.typeId = typeId;
        this.supervisorFullName = supervisorFullName;
        this.studentId = studentId;
        this.boxId = boxId;
    }

    // Getters and Setters
    public int getDocId() { return docId; }
    public void setDocId(int docId) { this.docId = docId; }
    public String getDocumentSubject() { return documentSubject; }
    public void setDocumentSubject(String documentSubject) { this.documentSubject = documentSubject; }
    public int getStartData() { return startData; }
    public void setStartData(int startData) { this.startData = startData; }
    public int getTypeId() { return typeId; }
    public void setTypeId(int typeId) { this.typeId = typeId; }
    public String getTypeName() { return typeName; }
    public void setTypeName(String typeName) { this.typeName = typeName; }
    public String getSupervisorFullName() { return supervisorFullName; }
    public void setSupervisorFullName(String supervisorFullName) { this.supervisorFullName = supervisorFullName; }
    public int getStudentId() { return studentId; }
    public void setStudentId(int studentId) { this.studentId = studentId; }
    public String getStudentName() { return studentName; }
    public void setStudentName(String studentName) { this.studentName = studentName; }
    public int getBoxId() { return boxId; }
    public void setBoxId(int boxId) { this.boxId = boxId; }
    public String getBoxName() { return boxName; }
    public void setBoxName(String boxName) { this.boxName = boxName; }
    public boolean isDeleted() { return isDeleted; }
    public void setDeleted(boolean deleted) { isDeleted = deleted; }
}