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
            throw new NotImplementedException();
        }

        public bool Delete(Eroe item)
        {
            throw new NotImplementedException();
        }

        public List<Eroe> GetAll(Func<Eroe, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Eroe item)
        {
            throw new NotImplementedException();
        }
    }
}
