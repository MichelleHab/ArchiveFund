package com.archivfund.app.models;

/**
 * Модель коробки (Boxes) для системы ArchiveFund
 */
public class Box {
    private int boxId;
    private String boxName;
    private Integer rackNumber;
    private Integer shelfNumber;
    private int groupId;
    private String groupName;
    private int typeId;
    private String typeName;
    private String yearWork;

    public Box() {}

    public Box(int boxId, String boxName, Integer rackNumber, Integer shelfNumber, 
               int groupId, String groupName, int typeId, String typeName, String yearWork) {
        this.boxId = boxId;
        this.boxName = boxName;
        this.rackNumber = rackNumber;
        this.shelfNumber = shelfNumber;
        this.groupId = groupId;
        this.groupName = groupName;
        this.typeId = typeId;
        this.typeName = typeName;
        this.yearWork = yearWork;
    }

    public int getBoxId() { return boxId; }
    public void setBoxId(int boxId) { this.boxId = boxId; }

    public String getBoxName() { return boxName; }
    public void setBoxName(String boxName) { this.boxName = boxName; }

    public Integer getRackNumber() { return rackNumber; }
    public void setRackNumber(Integer rackNumber) { this.rackNumber = rackNumber; }

    public Integer getShelfNumber() { return shelfNumber; }
    public void setShelfNumber(Integer shelfNumber) { this.shelfNumber = shelfNumber; }

    public int getGroupId() { return groupId; }
    public void setGroupId(int groupId) { this.groupId = groupId; }

    public String getGroupName() { return groupName; }
    public void setGroupName(String groupName) { this.groupName = groupName; }

    public int getTypeId() { return typeId; }
    public void setTypeId(int typeId) { this.typeId = typeId; }

    public String getTypeName() { return typeName; }
    public void setTypeName(String typeName) { this.typeName = typeName; }

    public String getYearWork() { return yearWork; }
    public void setYearWork(String yearWork) { this.yearWork = yearWork; }
}
