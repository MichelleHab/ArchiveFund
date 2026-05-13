package com.example.archivefund;

public class Student {
    private int studentId;
    private String fullName;
    private int groupId;
    private String groupName;
    private PersonalFile personalFile;

    public Student() {}

    public Student(String fullName, int groupId) {
        this.fullName = fullName;
        this.groupId = groupId;
    }

    public int getStudentId() { return studentId; }
    public void setStudentId(int studentId) { this.studentId = studentId; }
    public String getFullName() { return fullName; }
    public void setFullName(String fullName) { this.fullName = fullName; }
    public int getGroupId() { return groupId; }
    public void setGroupId(int groupId) { this.groupId = groupId; }
    public String getGroupName() { return groupName; }
    public void setGroupName(String groupName) { this.groupName = groupName; }
    public PersonalFile getPersonalFile() { return personalFile; }
    public void setPersonalFile(PersonalFile personalFile) { this.personalFile = personalFile; }
}
