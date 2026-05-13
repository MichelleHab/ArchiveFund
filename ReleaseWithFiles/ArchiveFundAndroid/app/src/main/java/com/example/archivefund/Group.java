package com.example.archivefund;

public class Group {
    private int groupId;
    private String groupName;
    private int formationYear;
    private String specialization;

    public Group() {}

    public Group(String groupName, int formationYear, String specialization) {
        this.groupName = groupName;
        this.formationYear = formationYear;
        this.specialization = specialization;
    }

    public int getGroupId() { return groupId; }
    public void setGroupId(int groupId) { this.groupId = groupId; }
    public String getGroupName() { return groupName; }
    public void setGroupName(String groupName) { this.groupName = groupName; }
    public int getFormationYear() { return formationYear; }
    public void setFormationYear(int formationYear) { this.formationYear = formationYear; }
    public String getSpecialization() { return specialization; }
    public void setSpecialization(String specialization) { this.specialization = specialization; }

    @Override
    public String toString() {
        return groupName;
    }
}
