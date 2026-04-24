using System.Net;

namespace ArchiveFund
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Sql.ConnectionStringBuilding.ConnectionTimeout = 1;
            if (File.Exists("config.ini"))
            {
                while (true)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines("config.ini");
                        Dictionary<string, string> config = [];
                        foreach (var line in lines)
                        {
                            if (line.IndexOf('=') == -1)
                                continue;
                            config.Add(line.Split('=')[0].Trim(), line.Split('=')[1].Trim());
                        }
                        Sql.ConnectionStringBuilding.Database = "information_schema";
                        if (string.IsNullOrWhiteSpace(config["database"]) || !config["database"].All(c => char.IsLetterOrDigit(c) || c == '_'))
                            config["database"] = "ArchiveFund";
                        if (!Convert.ToBoolean(Sql.QueryOneReturn("select @database IN (SELECT DISTINCT " +
                            "TABLE_SCHEMA FROM information_schema.TABLES) " +
                            "AS 'does such a database exist'", [new("@database", config["database"])]) ?? throw new ArgumentNullException()))
                        {
                            MessageBox.Show("База данных с именем, указанным в файле 'config.ini' не найдена. " +
                                "Загружена пустая версия", "Проверка файла конфигурации 'config.ini'",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Sql.QueryNonReturns(File.ReadAllText("ArchiveFund.06.clear.sql"));
                        }
                        var tableStruct = "Boxes, DeletedDocuments, DeletedStudentsPersFiles, Documents, DocumentTypes, Group, Student, StudentsPersFiles, User";
                        if (!Convert.ToBoolean(Sql.QueryOneReturn("select @tableStruct = (select GROUP_CONCAT(DISTINCT `TABLE_NAME` " +
                            "SEPARATOR ', ') FROM information_schema.TABLES WHERE `TABLE_SCHEMA` = @database) " +
                            "AS 'does this table structure exist'; ", [new("@tableStruct", tableStruct), new("@database", config["database"])]) ?? throw new ArgumentNullException()))
                        {
                            var backupFilePath = config["database"] + "." + DateTime.Now.ToString("dd.MM.yyyy-HH.mm.ss") + ".sql";
                            MessageBox.Show("Найдена база данных с именем, указанным в файле 'config.ini', " +
                                "не соответствующая табличной структуре. Сохранена в файл \"" + backupFilePath + "\n", "Проверка файла конфигурации 'config.ini'",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Sql.ExportToFile(backupFilePath, config["database"]);
                            Sql.QueryNonReturns($"DROP DATABASE IF EXISTS {config["database"]}");
                            Sql.QueryNonReturns(File.ReadAllText("ArchiveFund.06.clear.sql"));
                        }
                        Sql.ConnectionStringBuilding.Database = "mysql";
                        if (!string.IsNullOrEmpty(config["user"]) && config["user"].All(c => char.IsLetterOrDigit(c) || c == '_')
                            && !Convert.ToBoolean(Sql.QueryOneReturn("SELECT concat(@user, '@', @host) IN " +
                            "(SELECT DISTINCT CONCAT(`USER`, '@', `HOST`) " +
                            "FROM `mysql`.`user`) ", [new("@user", config["user"]), new("@host", IsValidServerAddress(config["server"]) ? config["server"] : "%")]) ?? throw new ArgumentNullException()))
                        {
                            var pas = string.Empty;
                            if (!string.IsNullOrWhiteSpace(config["password"]))
                                pas = "identified by '" + config["password"] + "'";
                            Sql.QueryNonReturns($"create user '{config["user"]}'@'{(IsValidServerAddress(config["server"]) ? config["server"] : "%")}' {pas}");
                            Sql.QueryNonReturns($"grant all privileges on `{config["database"]}`.* to '{config["user"]}'@'{(IsValidServerAddress(config["server"]) ? config["server"] : "%")}'");
                        }
                        if (IsValidServerAddress(config["server"]))
                            Sql.ConnectionStringBuilding.Server = config["server"];
                        if (!string.IsNullOrEmpty(config["port"]) && config["port"].All(char.IsDigit))
                            Sql.ConnectionStringBuilding.Port = Convert.ToUInt32(config["port"]);
                        Sql.ConnectionStringBuilding.Password = config["password"];
                        if (!string.IsNullOrEmpty(config["user"]) && config["user"].All(c => char.IsLetterOrDigit(c) || c == '_'))
                            Sql.ConnectionStringBuilding.UserID = config["user"];
                        if (!string.IsNullOrEmpty(config["database"]) && config["database"].All(c => char.IsLetterOrDigit(c) || c == '_'))
                            Sql.ConnectionStringBuilding.Database = config["database"];
                    }
                    catch
                    {
                        switch (MessageBox.Show("Возникло исключение при попытке обработать/собрать файл конфигурации 'config.ini'.\n" +
                            "Возможно, сервер закрыт или данные повреждены. Дальнейшая работа в приложении опасна!",
                            "Проверка файла конфигурации 'config.ini'", MessageBoxButtons.CancelTryContinue, MessageBoxIcon.Information))
                        {
                            case DialogResult.Cancel:
                                return;
                            case DialogResult.TryAgain:
                                continue;
                            default:
                                Sql.ConnectionStringBuilding.ConnectionTimeout = 1;
                                Sql.ConnectionStringBuilding.Database = "ArchiveFund";
                                break;
                        }
                    }
                    break;
                }
            }
            else
            {
                Sql.ConnectionStringBuilding.ConnectionTimeout = 1;
                Sql.ConnectionStringBuilding.Database = "ArchiveFund";
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
#if !DEBUG
            Application.Run(new Authorization());
#else
            Application.Run(new MainForm(MainForm.Role.Admin));
#endif
        }
        public static bool IsValidServerAddress(string server)
        {
            if (string.IsNullOrWhiteSpace(server))
                return false;
            // Разрешённые строковые значения
            if (server == "localhost" || server == "%" || server == "127.0.0.1")
                return true;
            // Проверка на корректный IPv4-адрес
            if (IPAddress.TryParse(server, out var ipAddress))
            {
                // Убедимся, что это IPv4 (а не IPv6)
                return ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
            }
            return false;
        }
    }
}