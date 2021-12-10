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
            maxId = maxId + 1;
            item.UserId = maxId;

            int countIniziale = InMemoryStorage.Utenti.Count;
            InMemoryStorage.Utenti.Add(item);
            int countFinale = InMemoryStorage.Utenti.Count;

            if (countFinale == countIniziale)
            {
                return false;
            }

            else
                return true;
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
            //mi starà passando lo user diventato admin (già con Admin == true)
            int index = -1;

            User oldItem = GetAll(e => e.UserId == item.UserId).SingleOrDefault();
            index = InMemoryStorage.Utenti.IndexOf(oldItem);

            if (index != -1)
            {
                InMemoryStorage.Utenti[index] = item;
                return true;
            }

            return false;
        }
    }
}
