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
        } // run ทุกอย่างออกมา

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
        } // run เลือกดูอย่าง detail 

      
        public int Add(Movie movie)
        {
            var response  = 0;
            var sqlCommand = string.Format(@"INSERT INTO Movie
                                                       (Title
                                                       ,Link)
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
        } // สร้างเพิ่มขึ้นมา


        //public int Update(Movie movie,int id)
        //{
        //    var models = 0;
        //    var sqlCommand = string.Format(@"UPDATE Movie SET Title=@Title ,Link=@Link WHERE Id = @Id)");

        //    using (var db = new MySqlConnection(connectionString))
        //    {
        //        models = db.Execute(sqlCommand, new
        //        {
        //            Title = movie.Title,
        //            Link = movie.Link,
        //            Id = id
        //        });
        //    }
        //    return models;
        //}



        public Movie Delete(int id)
        {
            var models = new Movie();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Movie>("DELETE FROM Movie WHERE Id = @Id", new
                {
                    Id = id
                }).FirstOrDefault();
            }
            return models;
        } // ลบข้อมูล 

    }
    
}
