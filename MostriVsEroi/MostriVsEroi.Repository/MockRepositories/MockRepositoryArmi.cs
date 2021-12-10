using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Repository.MockRepositories
{
    public class MockRepositoryArmi : IRepositoryArmi
    {
        public bool Add(Arma item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Arma item)
        {
            throw new NotImplementedException();
        }

        public List<Arma> GetAll(Func<Arma, bool> filter = null)
        {

            if (filter == null)
                return InMemoryStorage.Armi;
            else
                return InMemoryStorage.Armi.Where(filter).ToList();

        }

        public bool Update(Arma item)
        {
            throw new NotImplementedException();
        }
    }
}
