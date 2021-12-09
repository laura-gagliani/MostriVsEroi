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
            return repositoryEroi.Add(nuovoEroe); 
            
        }

        public bool AddNewMostro(Mostro nuovoMostro)
        {
            return repositoryMostri.Add(nuovoMostro);
            
        }

        public bool AddNewUser(string nickname, string password)
        {
            User nuovoUser= new User();
            bool aggiunta = false;
            nuovoUser.Nickname=nickname;
            nuovoUser.Password=password;
            if (repositoryUtenti.Add(nuovoUser) == true)
            {
                aggiunta = true;

            }
            return aggiunta;

        }

        public Eroe AggiornaEroe(int idEroe, int punteggioPartita)
        {
            throw new NotImplementedException();
        }

        public bool AggiornaUtente(int IdUtenteDaAggiornare)
        {
            throw new NotImplementedException();
        }

        public int CalcolaEsitoPartita(Eroe e, Mostro m)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEroe(Eroe eroe)
        {
            return repositoryEroi.Delete(eroe);
            
        }

        public List<Arma> GetArmiByCategoria(Arma.CategoriaPersonaggi categoria)
        {
            List<Arma> armi = repositoryArmi.GetAll();
            List<Arma> armiByCategoria= armi.Where(a=> a.Equals(categoria)).ToList();
            return armiByCategoria;
        }

        public List<Eroe> GetClassifica()
        {
            List<Eroe> eroiTotali = repositoryEroi.GetAll();
            List<Eroe> classificaEroi= eroiTotali.OrderBy(e=>e.Livello).OrderBy(e=>e.PuntiEsperienza).ToList();
            return classificaEroi;
        }

        public Eroe GetEroeById(int id)
        {
            List<Eroe> eroi = repositoryEroi.GetAll();

            Eroe eroeScelto=eroi.Where(e=> e.IdEroe== id).FirstOrDefault();
            return eroeScelto;
        }

        public List<Eroe> GetEroeByIdUser(int idUser)
        {
            List<Eroe> eroiTot=repositoryEroi.GetAll();
            List<Eroe> eroiByIdUser=eroiTot.Where(e=>e.IdUser== idUser).ToList();
            return eroiByIdUser;
        }

        public Mostro GetRandomMostro(int livello) //va corretto
        {
            List<int> codiciMostri = new List<int>();
            List<Mostro> mostriTot = repositoryMostri.GetAll();
           foreach (Mostro m in mostriTot)
            {
                if (m.Livello <= livello)
                {
                    codiciMostri.Add(m.IdMostro);
                }
            }
            Random randomChoice = new Random();
            int idMostroScelto=randomChoice.Next(codiciMostri.Min(),(codiciMostri.Max()+1));
            Mostro mostroEstratto = mostriTot.Where(m => m.IdMostro == idMostroScelto).FirstOrDefault();
            return mostroEstratto;

        }

        public User GetUserByNicknameAndPassword(string nickname, string password)
        {
            List<User> utenti = repositoryUtenti.GetAll();
            User utenteSelez = utenti.Where((u => u.Nickname == nickname && u.Password == password)).FirstOrDefault();
            return utenteSelez;
        
        }

        public List<User> GetUtenti()
        {
            return repositoryUtenti.GetAll();
        }
    }
}
