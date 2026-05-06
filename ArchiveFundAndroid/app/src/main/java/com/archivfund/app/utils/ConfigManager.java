package com.archivfund.app.utils;

import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;

/**
 * Менеджер конфигурации приложения
 * Адаптирован из C# Program.cs для работы с config.ini
 */
public class ConfigManager {
    private static final String TAG = "ConfigManager";
    private static final String PREF_NAME = "ArchiveFundConfig";
    
    private SharedPreferences prefs;
    
    // Значения по умолчанию
    private static final String DEFAULT_SERVER = "localhost";
    private static final int DEFAULT_PORT = 3306;
    private static final String DEFAULT_DATABASE = "ArchiveFund";
    private static final String DEFAULT_USER = "root";
    private static final String DEFAULT_PASSWORD = "";
    
    public ConfigManager(Context context) {
        prefs = context.getSharedPreferences(PREF_NAME, Context.MODE_PRIVATE);
    }
    
    public String getServer() {
        return prefs.getString("server", DEFAULT_SERVER);
    }
    
    public void setServer(String server) {
        prefs.edit().putString("server", server).apply();
    }
    
    public int getPort() {
        return prefs.getInt("port", DEFAULT_PORT);
    }
    
    public void setPort(int port) {
        prefs.edit().putInt("port", port).apply();
    }
    
    public String getDatabase() {
        return prefs.getString("database", DEFAULT_DATABASE);
    }
    
    public void setDatabase(String database) {
        prefs.edit().putString("database", database).apply();
    }
    
    public String getUser() {
        return prefs.getString("user", DEFAULT_USER);
    }
    
    public void setUser(String user) {
        prefs.edit().putString("user", user).apply();
    }
    
    public String getPassword() {
        return prefs.getString("password", DEFAULT_PASSWORD);
    }
    
    public void setPassword(String password) {
        prefs.edit().putString("password", password).apply();
    }
    
    /**
     * Проверяет валидность адреса сервера
     */
    public static boolean isValidServerAddress(String server) {
        if (server == null || server.trim().isEmpty()) {
            return false;
        }
        
        // Разрешённые строковые значения
        if ("localhost".equals(server) || "%".equals(server) || "127.0.0.1".equals(server)) {
            return true;
        }
        
        // Проверка на корректный IPv4-адрес
        try {
            String[] parts = server.split("\\.");
            if (parts.length != 4) {
                return false;
            }
            for (String part : parts) {
                int num = Integer.parseInt(part);
                if (num < 0 || num > 255) {
                    return false;
                }
            }
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }
    
    /**
     * Сохраняет конфигурацию
     */
    public void saveConfig(String server, int port, String database, String user, String password) {
        SharedPreferences.Editor editor = prefs.edit();
        editor.putString("server", server);
        editor.putInt("port", port);
        editor.putString("database", database);
        editor.putString("user", user);
        editor.putString("password", password);
        editor.apply();
        Log.d(TAG, "Configuration saved");
    }
    
    /**
     * Очищает конфигурацию
     */
    public void clearConfig() {
        prefs.edit().clear().apply();
        Log.d(TAG, "Configuration cleared");
    }
}
