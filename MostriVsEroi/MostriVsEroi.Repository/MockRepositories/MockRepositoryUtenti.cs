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
            throw new NotImplementedException();
        }

        public bool Delete(User item)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
