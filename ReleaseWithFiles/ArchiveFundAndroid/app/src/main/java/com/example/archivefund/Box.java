package com.example.archivefund;

public class Box {
    private int boxId;
    private String boxName;
    private int rackNumber;
    private int shelfNumber;
    private int groupId;
    private String groupName;
    private int typeId;
    private String typeName;
    private int yearWork;

    public Box() {}

    public Box(String boxName, int rackNumber, int shelfNumber, int groupId, int typeId, int yearWork) {
        this.boxName = boxName;
        this.rackNumber = rackNumber;
        this.shelfNumber = shelfNumber;
        this.groupId = groupId;
        this.typeId = typeId;
        this.yearWork = yearWork;
    }

    public int getBoxId() { return boxId; }
    public void setBoxId(int boxId) { this.boxId = boxId; }
    public String getBoxName() { return boxName; }
    public void setBoxName(String boxName) { this.boxName = boxName; }
    public int getRackNumber() { return rackNumber; }
    public void setRackNumber(int rackNumber) { this.rackNumber = rackNumber; }
    public int getShelfNumber() { return shelfNumber; }
    public void setShelfNumber(int shelfNumber) { this.shelfNumber = shelfNumber; }
    public int getGroupId() { return groupId; }
    public void setGroupId(int groupId) { this.groupId = groupId; }
    public String getGroupName() { return groupName; }
    public void setGroupName(String groupName) { this.groupName = groupName; }
    public int getTypeId() { return typeId; }
    public void setTypeId(int typeId) { this.typeId = typeId; }
    public String getTypeName() { return typeName; }
    public void setTypeName(String typeName) { this.typeName = typeName; }
    public int getYearWork() { return yearWork; }
    public void setYearWork(int yearWork) { this.yearWork = yearWork; }

    public String getLocation() {
        return "Стеллаж: " + rackNumber + ", Полка: " + shelfNumber;
    }
}
