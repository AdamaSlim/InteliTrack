using System;
using System.Data;
using Npgsql;

class Program
{
    static void Main()
    {
        var connStr = "Host=localhost;Port=5432;Database=InteliTrack;Username=postgres;Password=123456";
        using var conn = new NpgsqlConnection(connStr);
        conn.Open();
        
        using var cmd = new NpgsqlCommand("SELECT column_name, data_type FROM information_schema.columns WHERE table_name = 'stores';", conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader["column_name"]} - {reader["data_type"]}");
        }
    }
}
