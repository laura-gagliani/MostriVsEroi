using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Repository.MockRepositories
{
    public class MockRepositoryMostri : IRepositoryMostri
    {
        public bool Add(Mostro item)
        {
            int maxId = GetAll().Select(m => m.IdMostro).Max();
            item.IdMostro = maxId++;

            int countIniziale = InMemoryStorage.Mostri.Count;
            InMemoryStorage.Mostri.Add(item);

            if (InMemoryStorage.Mostri.Count == countIniziale++)
                return true;
            else
                return false;
        }

        public bool Delete(Mostro item)
        {
            int countIniziale = InMemoryStorage.Mostri.Count;
            InMemoryStorage.Mostri.Remove(item);

            if (InMemoryStorage.Mostri.Count == countIniziale--)
                return true;
            else
                return false;
        }

        public List<Mostro> GetAll(Func<Mostro, bool> filter = null)
        {
            if (filter == null)
                return InMemoryStorage.Mostri;
            else
                return InMemoryStorage.Mostri.Where(filter).ToList();
        }

        public bool Update(Mostro item)
        {
            throw new NotImplementedException();
        }
    }
}
