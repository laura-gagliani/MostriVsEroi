using MostriVsEroi.Core.Entities;
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
        private readonly IRepositoryArmi repositoryArmi;

        public MainBusinessLayer(IRepositoryEroi repoEroi, IRepositoryMostri repoMostri, IRepositoryUtenti repoUtenti, IRepositoryArmi repoArmi)
        {
            repositoryEroi = repoEroi;
            repositoryMostri = repoMostri;
            repositoryUtenti = repoUtenti;
            repositoryArmi = repoArmi;

        }

        public bool AddNewEroe(Eroe nuovoEroe)
        {
            throw new NotImplementedException();
        }

        public bool AddNewMostro(Mostro nuovoMostro)
        {
            throw new NotImplementedException();
        }

        public bool AddNewUser(string nickname, string password)
        {
            throw new NotImplementedException();
        }

        public Eroe AggiornaEroe(int idEroe, int punteggioPartita)
        {
            throw new NotImplementedException();
        }

        public int CalcolaEsitoPartita(Eroe e, Mostro m)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEroe(Eroe eroe)
        {
            throw new NotImplementedException();
        }

        public List<Arma> GetArmiByCategoria(Arma.CategoriaPersonaggi categoria)
        {
            throw new NotImplementedException();
        }

        public List<Eroe> GetClassifica()
        {
            throw new NotImplementedException();
        }

        public Eroe GetEroeById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Eroe> GetEroeByIdUser(int idUser)
        {
            throw new NotImplementedException();
        }

        public Mostro GetRandomMostro()
        {
            throw new NotImplementedException();
        }

        public User GetUserByNicknameAndPassword(string nickname, string password)
        {
            throw new NotImplementedException();
        }
    }
}
