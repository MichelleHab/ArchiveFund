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
                    if (string.IsNullOrEmpty(config["database"]))
                        config["database"] = "ArchiveFund";
                    if (config["database"].All(c => !char.IsLetterOrDigit(c) || c == '_') &&
                        !Convert.ToBoolean(Sql.QueryOneReturn("select @database IN (SELECT DISTINCT " +
                        "TABLE_SCHEMA FROM information_schema.TABLES) " +
                        "AS 'does such a database exist'", [new("@database", config["database"])])))
                    {
                        Sql.QueryNonReturns(File.ReadAllText("ArchiveFund.04.clear.sql"));
                    }
                    var tableStruct = "Boxes, DeletedDocuments, DeletedStudentsPersFiles, Documents, DocumentTypes, Group, Student, StudentsPersFiles, User";
                    if (config["database"].Any(c => !char.IsLetterOrDigit(c) || c == '_') &&
                        !Convert.ToBoolean(Sql.QueryOneReturn("select @tableStruct = (select GROUP_CONCAT(DISTINCT `TABLE_NAME` " +
                        "SEPARATOR ', ') FROM information_schema.TABLES WHERE `TABLE_SCHEMA` = @database) " +
                        "AS 'does this table structure exist'; ", [new("@tableStruct", tableStruct), new("@database", config["database"])])))
                    {
                        var backupFilePath = config["database"] + "." + DateTime.Now.ToString("dd.MM.yyyy-HH.mm.ss") + ".sql";
                        MessageBox.Show("Найдена база данных с именем, указанным в файле 'config.ini', " +
                            "не соответствующая табличной структуре. Сохранена в файл \"" + backupFilePath + "\n", "Проверка файла конфигурации 'config.ini'",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sql.ExportToFile(backupFilePath);
                        Sql.QueryNonReturns($"DROP DATABASE IF EXISTS {config["database"]}");
                        Sql.QueryNonReturns(File.ReadAllText("ArchiveFund.04.clear.sql"));
                    }
                    Sql.ConnectionStringBuilding.Database = "mysql";
                    if (!string.IsNullOrEmpty(config["user"]) && config["user"].All(c => char.IsLetterOrDigit(c) || c == '_')
                        && !Convert.ToBoolean(Sql.QueryOneReturn("SELECT concat(@user, '@', @host) IN " +
                        "(SELECT DISTINCT CONCAT(`USER`, '@', `HOST`) " +
                        "FROM `mysql`.`user`) ", [new("@user", config["user"]), new("@host", '%')])))
                    {
                        var pas = string.Empty;
                        if (!string.IsNullOrEmpty(config["password"]) && !config["password"].Any(c => !char.IsLetterOrDigit(c)))
                            pas = "identified by " + config["password"];
                        Sql.QueryNonReturns($"create user '{config["user"]}'@'%' {pas}");
                        Sql.QueryNonReturns($"grant all privileges on `{config["database"]}`.* to '{config["user"]}'@'%'");
                    }
                    if (!string.IsNullOrEmpty(config["server"]) && config["server"].Any(c => !char.IsLetterOrDigit(c)))
                        Sql.ConnectionStringBuilding.Server = config["server"];
                    if (!string.IsNullOrEmpty(config["port"]) && config["port"].Any(c => !char.IsDigit(c)))
                        Sql.ConnectionStringBuilding.Port = Convert.ToUInt32(config["port"]);
                    if (config["password"].Any(c => !char.IsLetterOrDigit(c) || c == '_' || c == '-'))
                        Sql.ConnectionStringBuilding.Password = config["password"];
                    if (!string.IsNullOrEmpty(config["user"]) && config["user"].All(c => char.IsLetterOrDigit(c) || c == '_'))
                        Sql.ConnectionStringBuilding.UserID = config["user"];
                    if (!string.IsNullOrEmpty(config["database"]) && !config["database"].All(c => !char.IsLetterOrDigit(c) || c == '_'))
                        Sql.ConnectionStringBuilding.Database = config["database"];
                }
                catch
                {
                    MessageBox.Show("Возникло исключение при попытке обработать/собрать файл конфигурации 'config.ini'.\n" +
                        "Возможно, сервер закрыт или данные повреждены. Дальнейшая работа в приложении опасна!",
                        "Проверка файла конфигурации 'config.ini'", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}