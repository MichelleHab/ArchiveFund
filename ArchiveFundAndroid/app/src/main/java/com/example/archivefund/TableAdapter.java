package com.example.archivefund;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;
public class TableAdapter
        extends RecyclerView.Adapter<TableAdapter.ViewHolder>
{
    private List<Object> data = new ArrayList<>();
    private int selectedPosition = -1;
    private OnItemClickListener listener;

    public interface OnItemClickListener {
        void onItemClick(int position, int id);
    }

    public TableAdapter(OnItemClickListener listener) {
        this.listener = listener;
    }

    public void setData(List<?> newData) {
        data.clear();
        if (newData != null) {
            data.addAll(newData);
        }
        selectedPosition = -1;
        notifyDataSetChanged();
    }

    public int getSelectedId() {
        if (selectedPosition == -1 || selectedPosition >= data.size()) return -1;
        Object item = data.get(selectedPosition);
        return getIdFromItem(item);
    }

    public int getSelectedItemPosition() {
        return selectedPosition;
    }
    public void setSelectedById(int id) {
        if (id == -1) {
            clearSelection();
            return;
        }

        for (int i = 0; i < data.size(); i++) {
            int itemId = getIdFromItem(data.get(i));
            if (itemId == id) {
                setSelectedPosition(i);
                return;
            }
        }
        clearSelection();
    }
    public void setSelectedPosition(int position) {
        int oldPosition = selectedPosition;
        selectedPosition = position;
        if (oldPosition != -1) notifyItemChanged(oldPosition);
        if (selectedPosition != -1) notifyItemChanged(selectedPosition);
    }

    public void clearSelection() {
        if (selectedPosition != -1) {
            int oldPosition = selectedPosition;
            selectedPosition = -1;
            notifyItemChanged(oldPosition);
        }
    }

    private int getIdFromItem(Object item) {
        if (item instanceof User) return ((User) item).getUserId();
        if (item instanceof Student) return ((Student) item).getStudentId();
        if (item instanceof Group) return ((Group) item).getGroupId();
        if (item instanceof Document) return ((Document) item).getDocId();
        if (item instanceof DocumentType) return ((DocumentType) item).getTypeId();
        if (item instanceof Box) return ((Box) item).getBoxId();
        if (item instanceof PersonalFile) return ((PersonalFile) item).getPersFileId();
        return -1;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.item_table_row, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Object item = data.get(position);

        if (selectedPosition == position) {
            holder.cardView.setCardBackgroundColor(0xFF90EE90);
        } else {
            holder.cardView.setCardBackgroundColor(0xFFFFFFFF);
        }

        if (item instanceof User) {
            User user = (User) item;
            holder.tvTitle.setText(user.getFio());
            holder.tvSubtitle.setText(user.getLogin() + " | " + user.getRole());
        } else if (item instanceof Student) {
            Student student = (Student) item;
            holder.tvTitle.setText(student.getFullName());
            holder.tvSubtitle.setText(student.getGroupName() != null ? student.getGroupName() : "Нет группы");
        } else if (item instanceof Group) {
            Group group = (Group) item;
            holder.tvTitle.setText(group.getGroupName());
            holder.tvSubtitle.setText(group.getSpecialization());
        } else if (item instanceof PersonalFile) {
            PersonalFile pf = (PersonalFile) item;
            String title = pf.getStudentName() != null ? pf.getStudentName() : "Студент ID: " + pf.getStudentId();
            holder.tvTitle.setText(title);
            String subtitle = "Поступление: " + pf.getAdmissionYear();
            if (pf.getDeductionYear() > 0) {
                subtitle += " | Отчисление: " + pf.getDeductionYear();
            }
            if (pf.getReason() != null && !pf.getReason().isEmpty()) {
                subtitle += " | " + pf.getReason();
            }
            holder.tvSubtitle.setText(subtitle);
        } else if (item instanceof Document) {
            Document doc = (Document) item;
            holder.tvTitle.setText(doc.getDocumentSubject());
            holder.tvSubtitle.setText(doc.getTypeName() + " | " + doc.getStudentName());
        } else if (item instanceof DocumentType) {
            DocumentType type = (DocumentType) item;
            holder.tvTitle.setText(type.getTypeName());
            holder.tvSubtitle.setText("");
        } else if (item instanceof Box) {
            Box box = (Box) item;
            String name = box.getBoxName() != null ? box.getBoxName() : "Коробка " + box.getBoxId();
            holder.tvTitle.setText(name);
            holder.tvSubtitle.setText("Стеллаж: " + box.getRackNumber() + ", Полка: " + box.getShelfNumber());
        }

        holder.itemView.setOnClickListener(v -> {
            if (listener != null) {
                int id = getIdFromItem(item);  // Используем item из позиции, а не selectedPosition
                listener.onItemClick(position, id);
            }
        });
    }

    @Override
    public int getItemCount() {
        return data.size();
    }

    static class ViewHolder extends RecyclerView.ViewHolder {
        CardView cardView;
        TextView tvTitle, tvSubtitle;

        ViewHolder(View itemView) {
            super(itemView);
            cardView = itemView.findViewById(R.id.cardView);
            tvTitle = itemView.findViewById(R.id.tvTitle);
            tvSubtitle = itemView.findViewById(R.id.tvSubtitle);
        }
    }
}
