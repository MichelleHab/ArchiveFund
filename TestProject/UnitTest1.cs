
using ArchiveFund;
using System.Data;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void ConvertYearColumnsToString_ConvertsYearColumnsCorrectly()
        {
            // Arrange — подготовка тестовых данных
            var inputTable = new DataTable();
            inputTable.Columns.Add("Номер_коробки", typeof(int));
            inputTable.Columns.Add("Имя_коробки", typeof(string));
            inputTable.Columns.Add("Год_работы", typeof(DateTime)); // Столбец с «Год» в значении
            inputTable.Columns.Add("Другая_дата", typeof(DateTime)); // Столбец без «Год»

            // Добавляем несколько строк с разными датами
            inputTable.Rows.Add(1, "Коробка 1", new DateTime(2020, 5, 15), new DateTime(2021, 6, 20));
            inputTable.Rows.Add(2, "Коробка 2", new DateTime(2018, 3, 10), new DateTime(2019, 7, 25));
            inputTable.Rows.Add(3, "Коробка 3", DBNull.Value, new DateTime(2022, 8, 1)); // NULL в столбце с годом

            // Act — вызов тестируемого метода
            var resultTable = MainForm.ConvertYearColumnsToString(inputTable);

            // Assert — проверка результатов

            // 1. Проверка типов данных столбцов
            Assert.Equal(typeof(int), resultTable.Columns["Номер_коробки"].DataType);
            Assert.Equal(typeof(string), resultTable.Columns["Имя_коробки"].DataType);
            Assert.Equal(typeof(string), resultTable.Columns["Год_работы"].DataType);
            Assert.Equal(typeof(DateTime), resultTable.Columns["Другая_дата"].DataType);

            // 2. Проверка значений в преобразованном столбце 'year_work'
            Assert.Equal("2020", resultTable.Rows[0]["Год_работы"]);
            Assert.Equal("2018", resultTable.Rows[1]["Год_работы"]);
            Assert.True(resultTable.Rows[2]["Год_работы"] is DBNull,
                "NULL значение должно остаться NULL после преобразования");

            // 3. Проверка, что значения в других столбцах не изменились
            Assert.Equal(1, resultTable.Rows[0]["Номер_коробки"]);
            Assert.Equal("Коробка 1", resultTable.Rows[0]["Имя_коробки"]);
            Assert.Equal(new DateTime(2021, 6, 20), resultTable.Rows[0]["Другая_дата"]);
        }
    }
}
