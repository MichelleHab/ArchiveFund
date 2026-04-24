using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ArchiveFund
{
    internal class StructItem
    {
        private Items item;
        private int id;
        public StructItem(Items item, int id)
        {
            this.item = item;
            this.id = id;
        }
        public enum Items
        {
            None,
            Document,
            DelDocument,
            Student,
            Group
        }
        public void SetItem(ref DocX doc)
        {
            switch (item)
            {
                case Items.Document:
                    doc.InsertParagraph("Документ:").Bold().FontSize(14);
                    doc.InsertParagraph(CreateDocument(MainForm.Table.Documents, this.id)).FontSize(14);
                    break;
                case Items.DelDocument:
                    doc.InsertParagraph("Документ:").Bold().FontSize(14);
                    doc.InsertParagraph(CreateDocument(MainForm.Table.DeletedDocuments, this.id)).FontSize(14);
                    break;
                case Items.Student:
                    doc.InsertParagraph($"Все документы студента \"" +
                        $"{Sql.QueryOneReturn("select full_name from `Student` where student_id = @id",
                        [new("@id", this.id)])?.ToString()}\":").FontSize(16).Bold().Alignment = Alignment.center;
                    foreach (DataRow row in Sql.Query("select doc_id from `Documents` where student_id = @id",
                        [new("@id", this.id)])?.Rows ?? throw new ArgumentNullException())
                        doc.InsertParagraph("\t- " + CreateDocument(MainForm.Table.Documents,
                            int.Parse(row[0].ToString() ?? throw new ArgumentNullException()))).FontSize(14);
                    doc.InsertParagraph($"Удаленные документы:").FontSize(16).Bold().Alignment = Alignment.left;
                    foreach (DataRow row in Sql.Query("select doc_id from `DeletedDocuments` where student_id = @id",
                        [new("@id", this.id)])?.Rows ?? throw new ArgumentNullException())
                        doc.InsertParagraph("\t- " + CreateDocument(MainForm.Table.DeletedDocuments,
                            int.Parse(row[0].ToString() ?? throw new ArgumentNullException()))).FontSize(14);
                    break;
                case Items.Group:
                    doc.InsertParagraph($"Все документы группы \"" +
                        $"{Sql.QueryOneReturn("select group_name from `Group` where group_id = @id",
                        [new("@id", this.id)])?.ToString()}\":").FontSize(16).Bold().Alignment = Alignment.center;
                    foreach (DataRow row in Sql.Query("select doc_id from `Documents` left join " +
                        "`Boxes` on `Documents`.box_id = `Boxes`.box_id where group_id = @id",
                        [new("@id", this.id)])?.Rows ?? throw new ArgumentNullException())
                        doc.InsertParagraph("\t- " + CreateDocument(MainForm.Table.Documents,
                            int.Parse(row[0].ToString() ?? throw new ArgumentNullException()))).FontSize(14);
                    doc.InsertParagraph($"Удаленные документы:").FontSize(16).Bold().Alignment = Alignment.left;
                    foreach (DataRow row in Sql.Query("select doc_id from `DeletedDocuments` left join " +
                        "`Boxes` on `DeletedDocuments`.box_id = `Boxes`.box_id where group_id = @id",
                        [new("@id", this.id)])?.Rows ?? throw new ArgumentNullException())
                        doc.InsertParagraph("\t- " + CreateDocument(MainForm.Table.DeletedDocuments,
                            int.Parse(row[0].ToString() ?? throw new ArgumentNullException()))).FontSize(14);
                    break;
                default: break;
            }
            ;
        }
        private static string? CreateDocument(MainForm.Table table, int id)
        {
            return Sql.QueryOneReturn("select concat('Тема документа: \"', document_subject, " +
                "'\", тип документа: \"', type_name, '\", студент: \"', " +
                "full_name, '\", стеллаж: ', rack_number, ', полка: ', shelf_number, ', название коробки: ', box_name, " +
                $"', дата сохранения документа: ', DATE_FORMAT(start_data, '%d.%m.%Y')) from `{table}` left join " +
                $"`Student` on `{table}`.student_id = `Student`.student_id left join " +
                $"`Boxes` on `{table}`.box_id = `Boxes`.box_id left join " +
                $"`DocumentTypes` on `{table}`.type_id = `DocumentTypes`.type_id " +
                $"where doc_id = @id",
                    [new("@id", id)])?.ToString();
        }
    }
}
