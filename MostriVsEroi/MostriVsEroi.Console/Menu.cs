using MostriVsEroi.Core.BusinessLayer;
using MostriVsEroi.Core.Entities;
using MostriVsEroi.Repository.MockRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//commento valentina
namespace MostriVsEroi.ConsoleApp
{
    public class Menu
    {
        private readonly IBusinessLayer bl = new MainBusinessLayer(new MockRepositoryEroi(), new MockRepositoryMostri(), new MockRepositoryUtenti());


        internal static void Start()
        {
            // benvenuto
            Console.WriteLine("Benvenuto!");

            //commento inserito nel branch Laura
            //commento inserito da antonio


            int choice1 = -1;
            do
            {
                Console.WriteLine("[1] Accedi");
                Console.WriteLine("[2] Registrati");
                Console.WriteLine("[0] Esci");

                choice1 = GetMenuChoice();

                User utente = new User();

                switch (choice1)
                {
                    case 0:
                        //chiudi
                        break;
                    case 1:
                        utente = Autenticati();
                        break;
                    case 2:
                        utente = Registrati();
                        break;
                }

                int choice2 = -1;

                do
                {
                    if (utente.Admin)
                    {
                        //mostra menu Admin
                        //output choice2 (corretto per le possibili scelte admin)


                    }
                    else
                    {
                        //mostra schermata base
                        //output choice2 (corretto per le possibili scelte base)

                    }

                    switch (choice2)
                    {
                        //gioca

                        //crea nuovo eroe

                        //elimina eroe

                        //crea mostro

                        //mostra classifica

                        //logout -> choice2 == 0 

                    }
                } while (choice2 != 0);

            } while (choice1 != 0);


        }

        private static int GetMenuChoice()
        {
            throw new NotImplementedException();
        }

        private static User Registrati()
        {
            throw new NotImplementedException();

            //renderà il nuovo utente creato con i dati richiesti in input
        }

        private static User Autenticati()
        {
            //metodo che chiede in input nickname e pssw
            //se trova un utente con quei dati rende quello,
            //altrimenti dice "errore, inserisci dati corretti" e continua a ciclare finché non trova
            //un utente con i dati richiesti. alla fine rende quello
            throw new NotImplementedException();

        }

        private static void StampaMenuBase()
        {
            Console.WriteLine("[1] ...");
            Console.WriteLine("[2] ...");
            Console.WriteLine("[1] ...");
            Console.WriteLine("[1] ...");
        }
    }
}
