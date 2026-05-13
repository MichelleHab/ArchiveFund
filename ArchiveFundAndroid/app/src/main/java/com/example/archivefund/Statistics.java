package com.example.archivefund;

public class Statistics {
    private int totalStudents;
    private int totalGroups;
    private int totalDocuments;
    private int totalBoxes;
    private int activeDocuments;
    private int deletedDocuments;
    private int currentYearDocuments;

    public Statistics() {}

    public int getTotalStudents() { return totalStudents; }
    public void setTotalStudents(int totalStudents) { this.totalStudents = totalStudents; }
    public int getTotalGroups() { return totalGroups; }
    public void setTotalGroups(int totalGroups) { this.totalGroups = totalGroups; }
    public int getTotalDocuments() { return totalDocuments; }
    public void setTotalDocuments(int totalDocuments) { this.totalDocuments = totalDocuments; }
    public int getTotalBoxes() { return totalBoxes; }
    public void setTotalBoxes(int totalBoxes) { this.totalBoxes = totalBoxes; }
    public int getActiveDocuments() { return activeDocuments; }
    public void setActiveDocuments(int activeDocuments) { this.activeDocuments = activeDocuments; }
    public int getDeletedDocuments() { return deletedDocuments; }
    public void setDeletedDocuments(int deletedDocuments) { this.deletedDocuments = deletedDocuments; }
    public int getCurrentYearDocuments() { return currentYearDocuments; }
    public void setCurrentYearDocuments(int currentYearDocuments) { this.currentYearDocuments = currentYearDocuments; }
}
