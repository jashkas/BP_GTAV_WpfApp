using System;
using System.Data.SQLite;
using System.IO;

namespace BP_GTAV_WpfApp
{
    internal class DatabaseManager
    {
        private const string DatabaseFile = "BpData.db";
        private const string ConnectionString = "Data Source=" + DatabaseFile + ";Version=3;";

        public DatabaseManager()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(DatabaseFile))
            {
                SQLiteConnection.CreateFile(DatabaseFile);

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Создание таблицы для действий (BpDoing)
                    string createBpDoingTable = @"
                        CREATE TABLE IF NOT EXISTS BpDoing (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Mine INTEGER,
                            Construction INTEGER,
                            Port INTEGER,
                            Postman INTEGER,
                            Gym INTEGER,
                            Farm INTEGER,
                            FireFighter INTEGER,
                            Lottery INTEGER,
                            MovieStudio INTEGER,
                            MovieTheater INTEGER,
                            ZerosCasinoDone INTEGER,
                            ZerosCasinoAttempt INTEGER,
                            TreasureDone INTEGER,
                            TreasureAttempt INTEGER,
                            ShootingRange INTEGER
                        );";

                    // Создание таблицы для общей информации (BpData)
                    string createBpDataTable = @"
                        CREATE TABLE IF NOT EXISTS BpData (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Bp INTEGER,
                            Date TEXT,
                            BpDoingId INTEGER,
                            FOREIGN KEY(BpDoingId) REFERENCES BpDoing(Id)
                        );";

                    using (var command = new SQLiteCommand(createBpDoingTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(createBpDataTable, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public int InsertBpDoing(BpDoing bpDoing)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO BpDoing (Mine, Construction, Port, Postman, Gym, Farm, FireFighter, Lottery, MovieStudio, MovieTheater, ZerosCasinoDone, ZerosCasinoAttempt, TreasureDone, TreasureAttempt, ShootingRange)
                    VALUES (@Mine, @Construction, @Port, @Postman, @Gym, @Farm, @FireFighter, @Lottery, @MovieStudio, @MovieTheater, @ZerosCasinoDone, @ZerosCasinoAttempt, @TreasureDone, @TreasureAttempt, @ShootingRange);
                    SELECT last_insert_rowid();";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Mine", bpDoing.Mine);
                    command.Parameters.AddWithValue("@Construction", bpDoing.Construction);
                    command.Parameters.AddWithValue("@Port", bpDoing.Port);
                    command.Parameters.AddWithValue("@Postman", bpDoing.Postman);
                    command.Parameters.AddWithValue("@Gym", bpDoing.Gym);
                    command.Parameters.AddWithValue("@Farm", bpDoing.Farm);
                    command.Parameters.AddWithValue("@FireFighter", bpDoing.FireFighter);
                    command.Parameters.AddWithValue("@Lottery", bpDoing.Lottery);
                    command.Parameters.AddWithValue("@MovieStudio", bpDoing.MovieStudio ? 1 : 0);
                    command.Parameters.AddWithValue("@MovieTheater", bpDoing.MovieTheater ? 1 : 0);
                    command.Parameters.AddWithValue("@ZerosCasinoDone", bpDoing.ZerosCasinoDone ? 1 : 0);
                    command.Parameters.AddWithValue("@ZerosCasinoAttempt", bpDoing.ZerosCasinoAttempt);
                    command.Parameters.AddWithValue("@TreasureDone", bpDoing.TreasureDone);
                    command.Parameters.AddWithValue("@TreasureAttempt", bpDoing.TreasureAttempt);
                    command.Parameters.AddWithValue("@ShootingRange", bpDoing.ShootingRange);

                    return Convert.ToInt32(command.ExecuteScalar()); // Возвращается ID добавленной записи
                }
            }
        }

        public void InsertBpData(BpData bpData)
        {
            int bpDoingId = InsertBpDoing(bpData.BpDoing);

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO BpData (Bp, Date, BpDoingId)
                    VALUES (@Bp, @Date, @BpDoingId);";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Bp", bpData.Bp);
                    command.Parameters.AddWithValue("@Date", bpData.Date);
                    command.Parameters.AddWithValue("@BpDoingId", bpDoingId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public BpData GetLatestBpData()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string query = @"
                    SELECT Bp, Date, Mine, Construction, Port, Postman, Gym, Farm, FireFighter, Lottery, MovieStudio, MovieTheater, ZerosCasinoDone, ZerosCasinoAttempt, TreasureDone, TreasureAttempt, ShootingRange
                    FROM BpData
                    JOIN BpDoing ON BpData.BpDoingId = BpDoing.Id
                    ORDER BY BpData.Id DESC
                    LIMIT 1;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var bpDoing = new BpDoing
                            {
                                Mine = Convert.ToByte(reader["Mine"]),
                                Construction = Convert.ToByte(reader["Construction"]),
                                Port = Convert.ToByte(reader["Port"]),
                                Postman = Convert.ToByte(reader["Postman"]),
                                Gym = Convert.ToByte(reader["Gym"]),
                                Farm = Convert.ToByte(reader["Farm"]),
                                FireFighter = Convert.ToByte(reader["FireFighter"]),
                                Lottery = Convert.ToByte(reader["Lottery"]),
                                MovieStudio = Convert.ToBoolean(reader["MovieStudio"]),
                                MovieTheater = Convert.ToBoolean(reader["MovieTheater"]),
                                ZerosCasinoDone = Convert.ToBoolean(reader["ZerosCasinoDone"]),
                                ZerosCasinoAttempt = Convert.ToByte(reader["ZerosCasinoAttempt"]),
                                TreasureDone = Convert.ToByte(reader["TreasureDone"]),
                                TreasureAttempt = Convert.ToByte(reader["TreasureAttempt"]),
                                ShootingRange = Convert.ToByte(reader["ShootingRange"])
                            };

                            return new BpData
                            {
                                Bp = Convert.ToInt32(reader["Bp"]),
                                Date = reader["Date"].ToString(),
                                BpDoing = bpDoing
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
