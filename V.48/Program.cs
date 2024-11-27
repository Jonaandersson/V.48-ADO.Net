namespace V._48
{

    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;


    class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            var dbHelper = new DatabaseHelper(connectionString);

            Console.Write("Ange skådespelarens namn (Personlig favvis är Elvis Marx): ");
            string actorName = Console.ReadLine();

            
            List<Film> films = dbHelper.GetFilmsByActor(actorName);

            if (films.Count > 0)
            {
                Console.WriteLine("\nFilmer där skådespelaren är delaktig:");
                foreach (var film in films)
                {
                    Console.WriteLine($"- {film.Title}");
                }
            }
            else
            {
                Console.WriteLine("Inga filmer hittades för den skådespelaren.");
            }
        }
    }

}
