using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;



namespace V._48
{
    

    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Film> GetFilmsByActor(string actorName)
        {
            var films = new List<Film>();

            string query = @"
            SELECT f.film_id, f.title 
            FROM actor AS a
            JOIN film_actor AS fa ON a.actor_id = fa.actor_id
            JOIN film AS f ON fa.film_id = f.film_id
            WHERE a.first_name + ' ' + a.last_name = @actorName;
        ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@actorName", actorName);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            films.Add(new Film
                            {
                                Id = Convert.ToInt32(reader["film_id"]),
                                Title = reader["title"].ToString()
                            });
                        }
                    }
                }
            }

            return films;
        }
    }

}
