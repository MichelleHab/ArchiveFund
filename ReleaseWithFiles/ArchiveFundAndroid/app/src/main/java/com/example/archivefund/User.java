package com.example.archivefund;
public class User {
    private int userId;
    private String fio;
    private String role;
    private String login;
    private String password;

    public User() {}

    public User(String fio, String role, String login, String password) {
        this.fio = fio;
        this.role = role;
        this.login = login;
        this.password = password;
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

    public boolean isAdmin() { return "Admin".equals(role); }
    public boolean isManager() { return "Manager".equals(role); }
}
