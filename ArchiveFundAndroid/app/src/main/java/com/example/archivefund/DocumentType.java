package com.example.archivefund;

public class DocumentType {
    private int typeId;
    private String typeName;

    public DocumentType() {}

    public DocumentType(String typeName) {
        this.typeName = typeName;
    }

    public int getTypeId() { return typeId; }
    public void setTypeId(int typeId) { this.typeId = typeId; }
    public String getTypeName() { return typeName; }
    public void setTypeName(String typeName) { this.typeName = typeName; }

    @Override
    public String toString() {
        return typeName;
    }
}
