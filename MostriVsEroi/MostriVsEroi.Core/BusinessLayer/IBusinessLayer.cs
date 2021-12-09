using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MostriVsEroi.Core.Entities.Arma;

namespace MostriVsEroi.Core.BusinessLayer
{
    public interface IBusinessLayer
    {

        User GetUserByNicknameAndPassword(string nickname, string password);
        bool AddNewUser(string nickname, string password);

        Eroe GetEroeById(int id);
        Mostro GetRandomMostro(int livello);


        int CalcolaEsitoPartita(Eroe e, Mostro m);
         
        Eroe AggiornaEroe(int idEroe, int punteggioPartita);

        bool AddNewEroe(Eroe nuovoEroe);
        bool DeleteEroe(Eroe eroe);
        bool AddNewMostro(Mostro nuovoMostro);

        List<Arma> GetArmiByCategoria(CategoriaPersonaggi categoria);
        List<Eroe> GetClassifica();
        List<Eroe> GetEroeByIdUser(int idUser);
        List<User> GetUtenti();
        bool AggiornaUtente(int IdUtenteDaAggiornare);


    }
}
