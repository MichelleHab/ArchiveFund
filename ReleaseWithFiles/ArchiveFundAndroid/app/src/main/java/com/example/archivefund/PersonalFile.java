package com.example.archivefund;

public class PersonalFile {
    private int persFileId;
    private int admissionYear;
    private int deductionYear;
    private String reason;
    private int studentId;
    private String studentName;
    private boolean isDeleted;

    public PersonalFile() {}

    public PersonalFile(int admissionYear, int deductionYear, String reason) {
        this.admissionYear = admissionYear;
        this.deductionYear = deductionYear;
        this.reason = reason;
    }

    // Getters and Setters
    public int getPersFileId() { return persFileId; }
    public void setPersFileId(int persFileId) { this.persFileId = persFileId; }
    public int getAdmissionYear() { return admissionYear; }
    public void setAdmissionYear(int admissionYear) { this.admissionYear = admissionYear; }
    public int getDeductionYear() { return deductionYear; }
    public void setDeductionYear(int deductionYear) { this.deductionYear = deductionYear; }
    public String getReason() { return reason; }
    public void setReason(String reason) { this.reason = reason; }
    public int getStudentId() { return studentId; }
    public void setStudentId(int studentId) { this.studentId = studentId; }
    public String getStudentName() { return studentName; }
    public void setStudentName(String studentName) { this.studentName = studentName; }
    public boolean isDeleted() { return isDeleted; }
    public void setDeleted(boolean deleted) { isDeleted = deleted; }
}
