package com.archivfund.app.models;

/**
 * Модель пользователя для системы ArchiveFund
 */
public class User {
    private int userId;
    private String fio;
    private String role;
    private String login;
    private String password;

    public enum Role {
        NONE,
        ADMIN,
        MANAGER
    }

    public User() {}

    public User(int userId, String fio, String role, String login) {
        this.userId = userId;
        this.fio = fio;
        this.role = role;
        this.login = login;
    }

    public int getUserId() { return userId; }
    public void setUserId(int userId) { this.userId = userId; }

    public String getFio() { return fio; }
    public void setFio(String fio) { this.fio = fio; }

    public String getRole() { return role; }
    public void setRole(String role) { this.role = role; }

    public String getLogin() { return login; }
    public void setLogin(String login) { this.login = login; }

    public String getPassword() { return password; }
    public void setPassword(String password) { this.password = password; }

    public static Role parseRole(String role) {
        if (role == null) return Role.NONE;
        switch (role) {
            case "Admin": return Role.ADMIN;
            case "Manager": return Role.MANAGER;
            default: return Role.NONE;
        }
    }
}
