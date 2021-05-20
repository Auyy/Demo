using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Models;
using Demo.Repositories;

namespace Demo.Services
{
    public class BroadingServices
    {
        private BroadingRepository broadingRepository;

        public BroadingServices()
        {
            broadingRepository = new BroadingRepository();
        }
        public IEnumerable<Broading> GetAll()
        {
            return broadingRepository.GetAll().OrderBy(i => i.Id).ToList();
        }
        public Broading GetById(int id)
        {
            return broadingRepository.GetById(id);
        }

        public bool Add(Broading broading)
        {
            return broadingRepository.Add(broading) > 0;
        }

        public int Update(Broading broading, int id)
        {
            return broadingRepository.Update(broading, id);
        }

        public Broading Delete(int id)
        {
            return broadingRepository.Delete(id);
        }
    }
}
