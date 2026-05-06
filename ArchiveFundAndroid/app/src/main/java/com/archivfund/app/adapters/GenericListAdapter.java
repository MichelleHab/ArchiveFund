package com.archivfund.app.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.archivfund.app.R;

import java.util.List;
import java.util.Map;

/**
 * Универсальный адаптер для отображения данных в RecyclerView
 */
public class GenericListAdapter extends RecyclerView.Adapter<GenericListAdapter.ViewHolder> {
    
    private Context context;
    private List<Map<String, Object>> data;
    
    public GenericListAdapter(Context context, List<Map<String, Object>> data) {
        this.context = context;
        this.data = data;
    }
    
    public void setData(List<Map<String, Object>> data) {
        this.data = data;
    }
    
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_list_row, parent, false);
        return new ViewHolder(view);
    }
    
    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Map<String, Object> item = data.get(position);
        
        if (item != null && !item.isEmpty()) {
            // Берем первое значение для отображения
            StringBuilder sb = new StringBuilder();
            for (Map.Entry<String, Object> entry : item.entrySet()) {
                if (sb.length() > 0) sb.append(" | ");
                sb.append(entry.getKey()).append(": ").append(
                    entry.getValue() != null ? entry.getValue().toString() : "null");
            }
            holder.textView.setText(sb.toString());
        } else {
            holder.textView.setText("");
        }
    }
    
    @Override
    public int getItemCount() {
        return data != null ? data.size() : 0;
    }
    
    static class ViewHolder extends RecyclerView.ViewHolder {
        TextView textView;
        
        ViewHolder(View itemView) {
            super(itemView);
            textView = itemView.findViewById(R.id.textViewItem);
        }
    }
}
