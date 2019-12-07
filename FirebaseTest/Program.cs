using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using FirebaseTest.Model;
using FirebaseTest.DatabaseService;
using System.Collections.Generic;

namespace FirebaseTest
{


    public class Program
    {
        public static void Main(string[] args)
        {
            //new Program().Run().Wait();

            FirebaseHelper fHelper = new FirebaseHelper();


            Balance balance = new Balance();
            balance.Amount = 100;
            balance.Date = "10.12.2019";
            balance.Note = "Mert Dereli";
            balance.Type = "standart";


            fHelper.PostBalance(balance).Wait();


            Class classs = new Class();
            classs.Branch = "Koko-Şanel";
            classs.Date = "2020.11.11";
            classs.Name = "Hakan Peker";
            classs.Type = "yoga";
            classs.PaymentType = "standart";
            classs.Teacher = "samet";
            //classs.Participants = new List<string> { "Mert", "Hakan", "Çido" };
            classs.Participants = new Dictionary<string, bool> { { "Diloş",true }, { "Deren",true },{ "Mert",true } };


            fHelper.PostClass(classs).Wait();
            fHelper.GetClass().Wait();

            //fHelper.DeleteBalance("-LussOeULsaM6kiv37MP").Wait();
            //fHelper.GetBalance().Wait();

            //fHelper.SearchBalance().Wait();



            fHelper.SearchClass("2000.00.00","3000.00.00").Wait();



            var getBalanceTask = fHelper.GetBalance("-LuslVr3yDpLgjux34Rk");


            Balance balances = getBalanceTask.Result;


        }
    }
}