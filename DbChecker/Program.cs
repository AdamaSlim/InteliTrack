using System;
using Npgsql;

var connStr = "Host=localhost;Port=5432;Database=InteliTrack;Username=postgres;Password=123456";
using var conn = new NpgsqlConnection(connStr);
conn.Open();

using var cmd = new NpgsqlCommand(@"
    SELECT table_name
    FROM information_schema.tables
    WHERE table_schema = 'public'
    ORDER BY table_name;", conn);
using var reader = cmd.ExecuteReader();

Console.WriteLine("Public tables:");
while (reader.Read())
{
    Console.WriteLine(reader.GetString(0));
}

reader.Close();

using var cmd2 = new NpgsqlCommand(@"
    SELECT column_name, data_type, is_nullable
    FROM information_schema.columns
    WHERE table_schema = 'public'
      AND table_name = 'transfers'
    ORDER BY ordinal_position;", conn);
using var reader2 = cmd2.ExecuteReader();

Console.WriteLine("\nTransfers columns:");
while (reader2.Read())
{
    Console.WriteLine($"{reader2.GetString(0)} {reader2.GetString(1)} {reader2.GetString(2)}");
}

reader2.Close();

using var cmd3 = new NpgsqlCommand(@"
    SELECT column_name, data_type, is_nullable
    FROM information_schema.columns
    WHERE table_schema = 'public'
      AND table_name = 'transferitems'
    ORDER BY ordinal_position;", conn);
using var reader3 = cmd3.ExecuteReader();

Console.WriteLine("\nTransferItems columns:");
while (reader3.Read())
{
    Console.WriteLine($"{reader3.GetString(0)} {reader3.GetString(1)} {reader3.GetString(2)}");
}

reader3.Close();

using var cmd4 = new NpgsqlCommand(@"
    SELECT column_name, data_type, is_nullable
    FROM information_schema.columns
    WHERE table_schema = 'public'
      AND table_name = 'stockmovements'
    ORDER BY ordinal_position;", conn);
using var reader4 = cmd4.ExecuteReader();

Console.WriteLine("\nStockMovements columns:");
while (reader4.Read())
{
    Console.WriteLine($"{reader4.GetString(0)} {reader4.GetString(1)} {reader4.GetString(2)}");
}

reader4.Close();

using var cmd5 = new NpgsqlCommand(@"
    SELECT column_name, data_type, is_nullable
    FROM information_schema.columns
    WHERE table_schema = 'public'
      AND table_name = 'stocks'
    ORDER BY ordinal_position;", conn);
using var reader5 = cmd5.ExecuteReader();

Console.WriteLine("\nStocks columns:");
while (reader5.Read())
{
    Console.WriteLine($"{reader5.GetString(0)} {reader5.GetString(1)} {reader5.GetString(2)}");
}

reader5.Close();

using var cmd6 = new NpgsqlCommand(@"
    SELECT column_name, data_type, is_nullable
    FROM information_schema.columns
    WHERE table_schema = 'public'
      AND table_name = 'stores'
    ORDER BY ordinal_position;", conn);
using var reader6 = cmd6.ExecuteReader();

Console.WriteLine("\nStores columns:");
while (reader6.Read())
{
    Console.WriteLine($"{reader6.GetString(0)} {reader6.GetString(1)} {reader6.GetString(2)}");
}

reader6.Close();

using var cmd7 = new NpgsqlCommand(@"
    SELECT column_name, data_type, is_nullable
    FROM information_schema.columns
    WHERE table_schema = 'public'
      AND table_name = 'employees'
    ORDER BY ordinal_position;", conn);
using var reader7 = cmd7.ExecuteReader();

Console.WriteLine("\nEmployees columns:");
while (reader7.Read())
{
    Console.WriteLine($"{reader7.GetString(0)} {reader7.GetString(1)} {reader7.GetString(2)}");
}

reader7.Close();

using var cmd8 = new NpgsqlCommand(@"
    SELECT column_name, data_type, is_nullable
    FROM information_schema.columns
    WHERE table_schema = 'public'
      AND table_name = 'products'
    ORDER BY ordinal_position;", conn);
using var reader8 = cmd8.ExecuteReader();

Console.WriteLine("\nProducts columns:");
while (reader8.Read())
{
    Console.WriteLine($"{reader8.GetString(0)} {reader8.GetString(1)} {reader8.GetString(2)}");
}

reader8.Close();

using var cmd9 = new NpgsqlCommand(@"
    SELECT DISTINCT movementtype FROM stockmovements;", conn);
using var reader9 = cmd9.ExecuteReader();

Console.WriteLine("\nDistinct stockmovements.movementtype values:");
while (reader9.Read())
{
    Console.WriteLine(reader9.GetString(0));
}

reader9.Close();

using var cmd10 = new NpgsqlCommand(@"
    SELECT DISTINCT status FROM transfers;", conn);
using var reader10 = cmd10.ExecuteReader();

Console.WriteLine("\nDistinct transfers.status values:");
while (reader10.Read())
{
    Console.WriteLine(reader10.GetString(0));
}

reader10.Close();

using var alterCmd = new NpgsqlCommand(@"
    ALTER TABLE transfers
    ADD COLUMN IF NOT EXISTS completedat timestamp with time zone NULL;", conn);
var alteredCount = alterCmd.ExecuteNonQuery();
Console.WriteLine($"\nAltered transfers table, rows affected: {alteredCount}");

using var cmd11 = new NpgsqlCommand(@"
    SELECT ""MigrationId"", ""ProductVersion""
    FROM public.""__EFMigrationsHistory""
    ORDER BY ""MigrationId"";", conn);
using var reader11 = cmd11.ExecuteReader();

Console.WriteLine("\nMigration history:");
while (reader11.Read())
{
    Console.WriteLine($"{reader11.GetString(0)} {reader11.GetString(1)}");
}
