using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Models;
using Demo.Repositories;

namespace Demo.Services
{
    public class TheaterServices
    {
        private TheaterRepository theaterRepository;

        public TheaterServices()
        {
            theaterRepository = new TheaterRepository();
        }

        public IEnumerable<Theater> GetAll()
        {
            return theaterRepository.GetAll().OrderBy(t => t.Room).ToList();
        }

        public Theater GetById(int id)
        {
            return theaterRepository.GetById(id);
        }

        public bool Add(Theater theater)
        {
            return theaterRepository.Add(theater) > 0;
        }

        public int Update(Theater theater, int id)
        {
            return theaterRepository.Update(theater, id);
        }

        public Theater Delete(int id)
        {
            return theaterRepository.Delete(id);
        }
    }
}
