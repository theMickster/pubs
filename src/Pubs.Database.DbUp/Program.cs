using DbUp;
using DbUp.Helpers;
using DbUp.ScriptProviders;
using Microsoft.Extensions.Configuration;
using Pubs.Database.DbUp.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pubs.Database.DbUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var noWait = args.Length == 1 && args[0] == "--nowait";

            try
            {
                
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var settings = new AppSettings();
                configuration.GetSection("App").Bind(settings);

                var connectionString = configuration.GetConnectionString("Default");

                WriteToConsole($"Pubs Database Migration: " + $"Version={typeof(Program).Assembly.GetName().Version}");

                WriteToConsole("\nImportant Note: Please ensure your scripts are Embedded in the executable.");

                if (!noWait)
                {
                    Console.Write("\nPress return to execute database code deployment...");
                    Console.ReadLine();
                }

                // See how to use variables in your scripts: 
                // https://dbup.readthedocs.io/en/latest/more-info/variable-substitution/
                var databaseVariables = new Dictionary<string, string>();

                // Execute Migration Scripts 
                var migrationsResult = DeployMigrations(connectionString, databaseVariables);

                if (migrationsResult)
                {
                    // Execute Programmable Objects 
                    DeployProgrammableObjects(connectionString, databaseVariables);
                }
                else
                {
                    WriteToConsole($"Migrations deployment failed. Programmable objects deployed was not attempted.",
                        ConsoleColor.Red);
                }

            }
            catch(Exception ex)
            {
                WriteToConsole(ex.Message, ConsoleColor.Red);
            }

            if (!noWait)
            {
                Console.Write("Press return key to exit...");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        private static bool DeployMigrations(string connectionString, Dictionary<string, string> variables)
        {
            WriteToConsole("Start execution of migrations...");

            var folderPath = Path.Combine(Environment.CurrentDirectory, "Scripts");
            var migrationsPath = Path.Combine(folderPath, "Migrations");

            if (!Directory.Exists(migrationsPath))
            {
                WriteToConsole($"Migrations not found at {migrationsPath}.", ConsoleColor.Red);
                return false;
            }

            var builder = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithTransaction()
                .WithVariables(variables)
                .WithScriptsFromFileSystem
                (
                    migrationsPath,
                    new FileSystemScriptOptions { IncludeSubDirectories = true }
                )
                .JournalToSqlTable("dbo", "__DatabaseMigrations")
                .LogToConsole();

            var result = builder.Build().PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception(result.Error.ToString());
            }

            WriteToConsole("Successfully deployed migrations.");
            WriteToConsole("End execution of migrations...");
            return true;
        }

        private static bool DeployProgrammableObjects(string connectionString, Dictionary<string, string> variables)
        {
            WriteToConsole("Start execution of programmable objects...");

            var folderPath = Path.Combine(Environment.CurrentDirectory, "Scripts");
            var programmableObjectsPath = Path.Combine(folderPath, "Programmability");

            if (!Directory.Exists(programmableObjectsPath))
            {
                WriteToConsole($"Programmable Objects not found at {programmableObjectsPath}.", ConsoleColor.Red);
                return false;
            }

            var builder = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithTransaction()
                .WithVariables(variables)
                .WithScriptsFromFileSystem
                (
                    programmableObjectsPath,
                    new FileSystemScriptOptions { IncludeSubDirectories = true }
                )
                .JournalTo(new NullJournal())
                .LogToConsole();

            var result = builder.Build().PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception(result.Error.ToString());
            }

            WriteToConsole("Successfully deployed programmable objects.");
            WriteToConsole("End execution of programmable objects.");

            return true;
        }


        private static void WriteToConsole(string msg, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

    }
}
