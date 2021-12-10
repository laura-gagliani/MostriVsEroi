﻿using MostriVsEroi.Core.Entities;
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
        Eroe GetEroeById(int id);

        Mostro GetRandomMostro(int livelloEroe);


        List<Arma> GetArmiByCategoria(CategoriaPersonaggi categoria);
        List<Eroe> GetClassifica();
        List<Eroe> GetEroeByIdUser(int idUser);
        List<User> GetUsers();



        int CalcolaEsitoPartita(Eroe e, Mostro m);
        Eroe AggiornaEroe(int idEroe, int punteggioPartita);


        bool AddNewEroe(Eroe nuovoEroe);
        //Meglio eliminare per id per una questione di migliorare la sintassi
        bool DeleteEroe(Eroe eroeDaEliminare);
        bool AddNewMostro(Mostro nuovoMostro);

        bool AddNewUser(string nickname, string password);
        bool AggiornaUtente(int idUtenteDaAggiornare);


    }
}
