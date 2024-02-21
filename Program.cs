using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using DBPopulation;
using DBCrud;

namespace mysqlefcore
{
    class Program
    {
        static void Main(string[] args)
        {
            ToolService toolService = new ToolService();

            //Populate database if not already populated
            if (!dbHasData())
            {
                PopulateDatabase();
            }
            else
            {
                Console.WriteLine("Database already populated");
                Console.WriteLine("-----------------------");
            }
        }

        //Checks if database is populated 
        private static bool dbHasData()
        {
            using (var context = new HardwareStoreContext())
            {
                //Creates the database if it doesn’t exist
                context.Database.EnsureCreated();

                //Check if database has data
                var numberOfTools = (from tools in context.Tool
                                     select tools).Count();

                //If the data count > 0 then database is populated
                if (numberOfTools > 0)
                {
                    return true;
                }
                return false;
            }
        }

        //Calls the population method
        private static void PopulateDatabase()
        {
            Population pop = new Population();
            pop.PopulateDatabase();
            Console.WriteLine("Database created successfully!");
            Console.WriteLine("-----------------------");
        }

        //Prints all ID, Name & Price of passed tools
        private static void PrintTools(string message, IQueryable<Tool> pTools)
        {
            var data = new StringBuilder();
            data.AppendLine(message);
            foreach (var tool in pTools)
            {
                data.AppendLine($"ID: {tool.ID}");
                data.AppendLine($"Name: {tool.Name}");
                data.AppendLine($"Price: {tool.Price}");
            }
            data.AppendLine("-----------------------");
            Console.WriteLine(data.ToString());
        }
    }
}
