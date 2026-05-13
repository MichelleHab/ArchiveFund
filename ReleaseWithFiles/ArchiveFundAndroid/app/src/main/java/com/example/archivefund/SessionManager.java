package com.example.archivefund;
import android.content.Context;
import android.content.SharedPreferences;
import com.example.archivefund.User;
public class SessionManager {
    private static final String PREF_NAME = "ArchiveFundPrefs";
    private static final String KEY_IS_LOGGED_IN = "isLoggedIn";
    private static final String KEY_USER_ID = "userId";
    private static final String KEY_USER_FIO = "userFio";
    private static final String KEY_USER_LOGIN = "userLogin";
    private static final String KEY_USER_ROLE = "userRole";

    private SharedPreferences pref;
    private SharedPreferences.Editor editor;
    private Context context;

    public SessionManager(Context context) {
        this.context = context;
        pref = context.getSharedPreferences(PREF_NAME, Context.MODE_PRIVATE);
        editor = pref.edit();
    }

    public void createSession(User user) {
        editor.putBoolean(KEY_IS_LOGGED_IN, true);
        editor.putInt(KEY_USER_ID, user.getUserId());
        editor.putString(KEY_USER_FIO, user.getFio());
        editor.putString(KEY_USER_LOGIN, user.getLogin());
        editor.putString(KEY_USER_ROLE, user.getRole());
        editor.apply();
    }

    public boolean isLoggedIn() {
        return pref.getBoolean(KEY_IS_LOGGED_IN, false);
    }

    public void logout() {
        editor.clear();
        editor.apply();
    }

    public int getUserId() {
        return pref.getInt(KEY_USER_ID, -1);
    }

    public String getUserFio() {
        return pref.getString(KEY_USER_FIO, "");
    }

    public String getUserLogin() {
        return pref.getString(KEY_USER_LOGIN, "");
    }

    public String getUserRole() {
        return pref.getString(KEY_USER_ROLE, "");
    }

    public boolean isAdmin() {
        return "Admin".equals(getUserRole());
    }
}
