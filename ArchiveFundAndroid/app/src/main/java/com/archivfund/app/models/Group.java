package com.archivfund.app.models;

/**
 * Модель группы (Group) для системы ArchiveFund
 */
public class Group {
    private int groupId;
    private String groupName;
    private String formationYear;
    private String specialization;

    public Group() {}

    public Group(int groupId, String groupName, String formationYear, String specialization) {
        this.groupId = groupId;
        this.groupName = groupName;
        this.formationYear = formationYear;
        this.specialization = specialization;
    }

    public int getGroupId() { return groupId; }
    public void setGroupId(int groupId) { this.groupId = groupId; }

    public String getGroupName() { return groupName; }
    public void setGroupName(String groupName) { this.groupName = groupName; }

    public String getFormationYear() { return formationYear; }
    public void setFormationYear(String formationYear) { this.formationYear = formationYear; }

    public String getSpecialization() { return specialization; }
    public void setSpecialization(String specialization) { this.specialization = specialization; }
}
