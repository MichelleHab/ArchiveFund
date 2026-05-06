package com.archivfund.app.models;

/**
 * Модель документа (Document) для системы ArchiveFund
 */
public class Document {
    private int docId;
    private String documentSubject;
    private String startDate;
    private int typeId;
    private String typeName;
    private String supervisorFullName;
    private int studentId;
    private String studentFullName;
    private int boxId;
    private String boxName;

    public Document() {}

    public Document(int docId, String documentSubject, String startDate, int typeId, 
                    String typeName, String supervisorFullName, int studentId, 
                    String studentFullName, int boxId, String boxName) {
        this.docId = docId;
        this.documentSubject = documentSubject;
        this.startDate = startDate;
        this.typeId = typeId;
        this.typeName = typeName;
        this.supervisorFullName = supervisorFullName;
        this.studentId = studentId;
        this.studentFullName = studentFullName;
        this.boxId = boxId;
        this.boxName = boxName;
    }

    public int getDocId() { return docId; }
    public void setDocId(int docId) { this.docId = docId; }

    public String getDocumentSubject() { return documentSubject; }
    public void setDocumentSubject(String documentSubject) { this.documentSubject = documentSubject; }

    public String getStartDate() { return startDate; }
    public void setStartDate(String startDate) { this.startDate = startDate; }

    public int getTypeId() { return typeId; }
    public void setTypeId(int typeId) { this.typeId = typeId; }

    public String getTypeName() { return typeName; }
    public void setTypeName(String typeName) { this.typeName = typeName; }

    public String getSupervisorFullName() { return supervisorFullName; }
    public void setSupervisorFullName(String supervisorFullName) { this.supervisorFullName = supervisorFullName; }

    public int getStudentId() { return studentId; }
    public void setStudentId(int studentId) { this.studentId = studentId; }

    public String getStudentFullName() { return studentFullName; }
    public void setStudentFullName(String studentFullName) { this.studentFullName = studentFullName; }

    public int getBoxId() { return boxId; }
    public void setBoxId(int boxId) { this.boxId = boxId; }

    public String getBoxName() { return boxName; }
    public void setBoxName(String boxName) { this.boxName = boxName; }
}
