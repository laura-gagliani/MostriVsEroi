using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryEroi repositoryEroi;
        private readonly IRepositoryMostri repositoryMostri;
        private readonly IRepositoryUtenti repositoryUtenti;

        public MainBusinessLayer(IRepositoryEroi repoEroi, IRepositoryMostri repoMostri, IRepositoryUtenti repoUtenti)
        {
            repositoryEroi = repoEroi;
            repositoryMostri = repoMostri;
            repositoryUtenti = repoUtenti;

        }

    }
}
