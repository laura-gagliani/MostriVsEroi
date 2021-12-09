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
            throw new NotImplementedException();
        }

        public bool Delete(Mostro item)
        {
            throw new NotImplementedException();
        }

        public List<Mostro> GetAll(Func<Mostro, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Mostro item)
        {
            throw new NotImplementedException();
        }
    }
}
