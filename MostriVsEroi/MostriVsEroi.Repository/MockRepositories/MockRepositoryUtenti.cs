using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Repository.MockRepositories
{
    public class MockRepositoryUtenti : IRepositoryUtenti
    {
        public bool Add(User item)
        {
            int maxId = GetAll().Select(u => u.UserId).Max();
            item.UserId = maxId++;

            int countIniziale = InMemoryStorage.Utenti.Count;
            InMemoryStorage.Utenti.Add(item);

            if (InMemoryStorage.Utenti.Count == countIniziale++)
                return true;
            else
                return false;
        }

        public bool Delete(User item)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(Func<User, bool> filter = null)
        {
            if (filter == null)
                return InMemoryStorage.Utenti;
            else
                return InMemoryStorage.Utenti.Where(filter).ToList();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
