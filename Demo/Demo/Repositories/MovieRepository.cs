using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Demo.Models;
using MySqlConnector;

namespace Demo.Repositories
{
    public class MovieRepository
    {
        private string connectionString = "Server=localhost;Port=3306;Database=Movies;Uid=root;Pwd=;";


        public MovieRepository()
        {

        }

        public IEnumerable<Movie> GetAll()
        {
            var models = new List<Movie>();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Movie>("SELECT * FROM Movie").ToList();
            }
            return models;
        }

        public Movie GetById(int id)
        {
            var models = new Movie();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Movie>("SELECT * FROM Movie WHERE Id = @Id", new
                {
                    Id = id
                }).FirstOrDefault();
            }
            return models;
        }

        public int Add(Movie movie)
        {
            var response  = 0;
            var sqlCommand = string.Format(@"INSERT INTO [Movie]
                                                       ([Title]
                                                       ,[Link])
                                                 VALUES
                                                       (@Title
                                                       ,@Link)");
            using (var db = new MySqlConnection(connectionString))
            {
                response = db.Execute(sqlCommand, new
                {
                    Title = movie.Title,
                    Link = movie.Link
                });
            }
            return response;
        }
    }
}
