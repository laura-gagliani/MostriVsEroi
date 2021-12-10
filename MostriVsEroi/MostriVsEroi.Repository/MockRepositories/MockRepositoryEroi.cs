using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Repository.MockRepositories
{
    public class MockRepositoryEroi : IRepositoryEroi
    {
        public bool Add(Eroe item)
        {
            int maxId = GetAll().Select(e => e.IdEroe).Max();
            maxId = maxId + 1;
            item.IdEroe = maxId;

            int countIniziale = InMemoryStorage.Eroi.Count;
            InMemoryStorage.Eroi.Add(item);
            int countFinale = InMemoryStorage.Eroi.Count;

            if (countFinale == countIniziale)
            {
                return false;
            }
                
            else
                return true;
        }

        

        public bool Delete(Eroe item)
        {
            int countIniziale = InMemoryStorage.Eroi.Count;
            InMemoryStorage.Eroi.Remove(item);

            if (InMemoryStorage.Eroi.Count == countIniziale--)
                return true;
            else
                return false;
        }

        public List<Eroe> GetAll(Func<Eroe, bool> filter = null)
        {
            if (filter == null)
                return InMemoryStorage.Eroi;
            else 
                return InMemoryStorage.Eroi.Where(filter).ToList(); 
        }

        public bool Update(Eroe item)
        {
            //mi sta passando l'eroe già modificato -> item
            int index = -1;

            Eroe oldItem = GetAll(e => e.IdEroe == item.IdEroe).SingleOrDefault();
            index = InMemoryStorage.Eroi.IndexOf(oldItem);

            if (index != -1)
            {
                InMemoryStorage.Eroi[index] = item;
                return true;
            }

            return false;
        }
    }
}
