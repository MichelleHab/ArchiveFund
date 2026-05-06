package com.archivfund.app.network;

import android.util.Log;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.HashMap;

/**
 * Класс для работы с базой данных MySQL
 * Адаптирован из C# Sql.cs для Android Java
 */
public class DatabaseHelper {
    private static final String TAG = "DatabaseHelper";
    
    private String server;
    private int port;
    private String database;
    private String username;
    private String password;
    
    public interface QueryCallback<T> {
        void onSuccess(List<T> result);
        void onError(Exception e);
    }
    
    public DatabaseHelper(String server, int port, String database, String username, String password) {
        this.server = server;
        this.port = port;
        this.database = database;
        this.username = username;
        this.password = password;
    }
    
    private Connection getConnection() throws SQLException {
        String url = "jdbc:mysql://" + server + ":" + port + "/" + database + 
                     "?useSSL=false&allowPublicKeyRetrieval=true&serverTimezone=UTC";
        return DriverManager.getConnection(url, username, password);
    }
    
    /**
     * Выполняет SELECT запрос и возвращает результаты
     */
    public List<Map<String, Object>> query(String sql, Object[] params) {
        List<Map<String, Object>> results = new ArrayList<>();
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = getConnection();
            stmt = conn.prepareStatement(sql);
            
            if (params != null) {
                for (int i = 0; i < params.length; i++) {
                    stmt.setObject(i + 1, params[i]);
                }
            }
            
            rs = stmt.executeQuery();
            int columnCount = rs.getMetaData().getColumnCount();
            
            while (rs.next()) {
                Map<String, Object> row = new HashMap<>();
                for (int i = 1; i <= columnCount; i++) {
                    String columnName = rs.getMetaData().getColumnName(i);
                    Object value = rs.getObject(i);
                    row.put(columnName, value);
                }
                results.add(row);
            }
            
            Log.d(TAG, "Query executed successfully, rows: " + results.size());
            
        } catch (SQLException e) {
            Log.e(TAG, "Database query error: " + e.getMessage());
            handleSqlError(e);
        } finally {
            closeResources(conn, stmt, rs);
        }
        
        return results;
    }
    
    /**
     * Выполняет запрос и возвращает одно значение
     */
    public Object querySingleValue(String sql, Object[] params) {
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = getConnection();
            stmt = conn.prepareStatement(sql);
            
            if (params != null) {
                for (int i = 0; i < params.length; i++) {
                    stmt.setObject(i + 1, params[i]);
                }
            }
            
            rs = stmt.executeQuery();
            if (rs.next()) {
                return rs.getObject(1);
            }
            
        } catch (SQLException e) {
            Log.e(TAG, "Database query single value error: " + e.getMessage());
            handleSqlError(e);
        } finally {
            closeResources(conn, stmt, rs);
        }
        
        return null;
    }
    
    /**
     * Выполняет INSERT, UPDATE, DELETE запросы
     * @return true если успешно, false иначе
     */
    public boolean executeNonQuery(String sql, Object[] params) {
        Connection conn = null;
        PreparedStatement stmt = null;
        
        try {
            conn = getConnection();
            stmt = conn.prepareStatement(sql);
            
            if (params != null) {
                for (int i = 0; i < params.length; i++) {
                    stmt.setObject(i + 1, params[i]);
                }
            }
            
            int rowsAffected = stmt.executeUpdate();
            Log.d(TAG, "Non-query executed, rows affected: " + rowsAffected);
            return true;
            
        } catch (SQLException e) {
            Log.e(TAG, "Database non-query error: " + e.getMessage());
            handleSqlError(e);
            return false;
        } finally {
            closeResources(conn, stmt, null);
        }
    }
    
    /**
     * Проверяет существование пользователя и возвращает данные для авторизации
     */
    public Map<String, Object> authenticateUser(String login, String password) {
        Map<String, Object> userData = new HashMap<>();
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = getConnection();
            
            // Сначала получаем пользователя по логину
            String selectSql = "SELECT * FROM user WHERE login = ?";
            stmt = conn.prepareStatement(selectSql);
            stmt.setString(1, login.trim());
            rs = stmt.executeQuery();
            
            if (rs.next()) {
                String storedPassword = rs.getString("password");
                String hashedInputPassword = hashPassword(password);
                
                if (storedPassword != null && storedPassword.equals(hashedInputPassword)) {
                    userData.put("success", true);
                    userData.put("user_id", rs.getInt("user_id"));
                    userData.put("login", rs.getString("login"));
                    userData.put("fio", rs.getString("FIO"));
                    userData.put("role", rs.getString("role"));
                    Log.d(TAG, "User authenticated successfully: " + login);
                } else {
                    userData.put("success", false);
                    userData.put("error", "Неверный логин или пароль");
                }
            } else {
                userData.put("success", false);
                userData.put("error", "Пользователь не найден");
            }
            
        } catch (SQLException e) {
            Log.e(TAG, "Authentication error: " + e.getMessage());
            userData.put("success", false);
            userData.put("error", e.getMessage());
        } finally {
            closeResources(conn, stmt, rs);
        }
        
        return userData;
    }
    
    /**
     * Хэширует пароль используя SHA2-512 (аналогично C# версии)
     */
    private String hashPassword(String password) {
        // В Android нужно использовать MessageDigest для SHA-512
        try {
            java.security.MessageDigest md = java.security.MessageDigest.getInstance("SHA-512");
            byte[] hashBytes = md.digest(password.getBytes(java.nio.charset.StandardCharsets.UTF_8));
            StringBuilder sb = new StringBuilder();
            for (byte b : hashBytes) {
                sb.append(String.format("%02x", b));
            }
            return sb.toString();
        } catch (java.security.NoSuchAlgorithmException e) {
            Log.e(TAG, "SHA-512 not available", e);
            return password; // Fallback
        }
    }
    
    private void handleSqlError(SQLException e) {
        Log.e(TAG, "SQL Error: " + e.getMessage() + ", SQLState: " + e.getSQLState() + 
              ", ErrorCode: " + e.getErrorCode());
    }
    
    private void closeResources(Connection conn, Statement stmt, ResultSet rs) {
        try {
            if (rs != null) rs.close();
            if (stmt != null) stmt.close();
            if (conn != null) conn.close();
        } catch (SQLException e) {
            Log.e(TAG, "Error closing resources", e);
        }
    }
}
