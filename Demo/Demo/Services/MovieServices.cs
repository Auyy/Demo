using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Models;
using Demo.Repositories;

namespace Demo.Services
{
    public class MovieServices
    {
        private MovieRepository movieRepository;

        public MovieServices()
        {
            movieRepository = new MovieRepository();
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieRepository.GetAll().OrderBy(m => m.Title).ToList();
        }

        public Movie GetById(int id)
        {
            return movieRepository.GetById(id);
        }

        public bool Add(Movie movie)
        {
            return movieRepository.Add(movie) > 0;
        }

        public int Update(Movie movie, int id)
        {
            return movieRepository.Update(movie, id);
        }

        public Movie Delete(int id)
        {
            return movieRepository.Delete(id);
        }
    }
}
