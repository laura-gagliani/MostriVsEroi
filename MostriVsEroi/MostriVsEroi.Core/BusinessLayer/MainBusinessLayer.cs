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

            User nuovoUser = new User();
            bool aggiunta = false;
            nuovoUser.Nickname = nickname;
            nuovoUser.Password = password;
            if (repositoryUtenti.Add(nuovoUser) == true)
            {
                aggiunta = true;

            }
            return aggiunta;


        }

        public Eroe AggiornaEroe(Eroe eroe, int punteggioPartita)
        {
            eroe.PuntiEsperienza += punteggioPartita;
            repositoryEroi.Update(eroe);

            return eroe;

        }


        public bool AggiornaUtente(int IdUtenteDaAggiornare)

        {
            throw new NotImplementedException();
        }

        public int CalcolaEsitoPartita(Eroe e, Mostro m)
        {
            int vitaEroe = e.PuntiVita;
            int vitaMostro = m.PuntiVita;

            Arma armaEroe = GetArmaById(e.IdArma);
            Arma armaMostro = GetArmaById(m.IdArma);
            

            char sceltaUtente = '0';
            bool fugaRiuscita = false;
            int esitoPartita = 0;

            do
            {

                Console.WriteLine($"Punti vita Eroe: {vitaEroe} - Punti vita Mostro: {vitaMostro}");
                Console.WriteLine("E' il tuo turno: premi 1 per fuggire, qualsiasi altro tasto per combattere");
                sceltaUtente = Console.ReadKey().KeyChar;

               if (sceltaUtente == '1') 
                {
                    Random randomChoice = new Random();
                    int chanceFuga = randomChoice.Next(1,3);
                    if (chanceFuga == 1)
                    {
                        fugaRiuscita = true;
                        Console.WriteLine("\nFuga riuscita!");
                        Console.WriteLine("Purtroppo questo ti costerà dei punti... ");
                        esitoPartita = -5 * (m.Livello);
                        
                        break;

                    }
                    else
                    {
                        Console.WriteLine("\nFuga fallita! Il mostro ti attacca");
                        vitaEroe -= armaMostro.PuntiDanno;
                    }


                }

               else
                {
                    //eroe attacca mostro
                    Console.WriteLine("\nCombattimento...");
                    vitaMostro -= armaEroe.PuntiDanno;
                    //mostro attacca eroe
                    vitaEroe -= armaMostro.PuntiDanno;
                }


            } while (vitaEroe > 0 && vitaMostro > 0);

            if (!fugaRiuscita)
            {
                if (vitaEroe <= 0)
                {
                    Console.WriteLine($"{e.Nome} è stato sconfitto :(");
                    esitoPartita = 0;
                }
                else
                {
                    Console.WriteLine($"{m.Nome} è stato sconfitto!! :)");
                    esitoPartita = 10 * m.Livello;
                }


            }

            return esitoPartita;
        }

        public bool DeleteEroe(Eroe eroe)
        {

            return repositoryEroi.Delete(eroe);


        }

        public Arma GetArmaById(int id)
        {
            return repositoryArmi.GetAll().Where(a => a.IdArma == id).FirstOrDefault();
        }

        public List<Arma> GetArmiByCategoria(Arma.CategoriaPersonaggi categoria)
        {

            List<Arma> armi = repositoryArmi.GetAll();
            List<Arma> armiByCategoria = armi.Where(a => a.Categoria == categoria).ToList();
            return armiByCategoria;

        }

        public List<Eroe> GetClassifica()
        {

            List<Eroe> eroiTotali = repositoryEroi.GetAll();
            List<Eroe> classificaEroi = eroiTotali.OrderBy(e => e.Livello).OrderBy(e => e.PuntiEsperienza).ToList();
            return classificaEroi;

        }

        public Eroe GetEroeById(int id)
        {

            List<Eroe> eroi = repositoryEroi.GetAll();

            Eroe eroeScelto = eroi.Where(e => e.IdEroe == id).FirstOrDefault();
            return eroeScelto;

        }

        public List<Eroe> GetEroeByIdUser(int idUser)
        {
            List<Eroe> eroiTot = repositoryEroi.GetAll();
            List<Eroe> eroiByIdUser = eroiTot.Where(e => e.IdUser == idUser).ToList();
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
            int idMostroScelto = randomChoice.Next(codiciMostri.Min(), (codiciMostri.Max() + 1));
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
