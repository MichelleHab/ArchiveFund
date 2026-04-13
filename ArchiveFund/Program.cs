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
                string[] lines = File.ReadAllLines("config.ini");
                Dictionary<string, string> config = [];
                foreach (var line in lines)
                {
                    if (line.IndexOf('=') == -1)
                        continue;
                    config.Add(line.Split('=')[0].Trim(), line.Split('=')[1].Trim());
                }
                if (!config["user"].Any(c => !char.IsLetterOrDigit(c)) && !string.IsNullOrEmpty(config["user"]) && Convert.ToBoolean(Sql.QueryOneReturn("SELECT @user IN " +
                    "(SELECT DISTINCT CONCAT(`USER`, '@', `HOST`) " +
                    "FROM `mysql`.`user`) AS 'does such a user exist'", [new("@user", config["user"])])))
                {
                    Sql.QueryNonReturns($"create user '{config["user"]}'@'%'");
                    Sql.QueryNonReturns($"grant all privileges on 'ArchiveFund' to '{config["user"]}'@'%'");
                }
                if (!config["user"].Any(c => !char.IsLetterOrDigit(c)) && !string.IsNullOrEmpty(config["user"]) && Convert.ToBoolean(Sql.QueryOneReturn("SELECT @user IN " +
                    "(SELECT DISTINCT CONCAT(`USER`, '@', `HOST`) " +
                    "FROM `mysql`.`user`) AS 'does such a user exist'", [new("@user", config["user"])])))
                {
                    Sql.QueryNonReturns($"create user '{config["user"]}'@'%'");
                    Sql.QueryNonReturns($"grant all privileges on 'ArchiveFund' to '{config["user"]}'@'%'");
                }

            }
            else
            {
                Sql.ConnectionStringBuilding.ConnectionTimeout = 1;
                Sql.ConnectionStringBuilding.Database = "ArchiveFund";
            }

            
            //File.Exists();
                /*string[] lines = File.ReadAllLines("config.ini");
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;
                    int separatorIndex = line.IndexOf('=');
                    if (separatorIndex == -1)
                        continue;
                    string key = line.Substring(0, separatorIndex).Trim();
                    string value = line.Substring(separatorIndex + 1).Trim();

                    // Заполняем соответствующие поля в SqlConnectionStringBuilder
                    switch (key)
                    {
                        case "database":
                        if (Sql.Query(""))
                            connectionBuilder.InitialCatalog = value;
                            break;
                        case "user":
                            connectionBuilder.UserID = value;
                            break;
                        case "password":
                            connectionBuilder.Password = value;
                            break;
                        case "port":
                            // Преобразуем порт в число и формируем DataSource
                            if (int.TryParse(value, out int port))
                            {
                                connectionBuilder.DataSource = $"{connectionBuilder.DataSource.Split(',')[0]},{port}";
                            }
                            break;
                        case "server":
                            // Если уже есть порт, сохраняем его
                            string currentDataSource = connectionBuilder.DataSource;
                            string portPart = string.Empty;

                            if (!string.IsNullOrEmpty(currentDataSource) && currentDataSource.Contains(","))
                            {
                                portPart = currentDataSource.Substring(currentDataSource.IndexOf(','));
                            }

                            connectionBuilder.DataSource = value + portPart;
                            break;
                    }
                }*/
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