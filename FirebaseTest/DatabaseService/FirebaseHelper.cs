using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using FirebaseTest.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FirebaseTest.DatabaseService
{
    public class FirebaseHelper
    {
        private string firebaseRepo = "https://atolyeyogaportal.firebaseio.com/";
        //private FirebaseClient firebase;

        public FirebaseHelper()
        {
            //firebase = new FirebaseClient(firebaseRepo);
        }

        #region Balance

        public async Task<string> PostBalance(Balance balance)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            var result = await firebase
              .Child("Root")
                .Child("Balance")
              .PostAsync(balance);

            return result.Key;

        }

        public async Task<Balance> GetBalance(string balanceID)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            var balances = await firebase
              .Child("Root")
                .Child("Balance")
              .OrderByKey()
                .EqualTo(balanceID)
              .OnceAsync<Balance>();

            List<Balance> balanceList = new List<Balance>();

            foreach (var balance in balances)
            {
                balance.Object.ID = balance.Key;
                balanceList.Add(balance.Object);
            }

            return balanceList[0];
        }

        public async Task<List<Balance>> SearchBalance(string startAt, string endAt)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            var balances = await firebase
              .Child("Root")
                .Child("Balance")
              .OrderBy("Date")
                .StartAt(startAt)
                .EndAt(endAt)
              .OnceAsync<Balance>();

            List<Balance> balanceList = new List<Balance>();

            foreach (var balance in balances)
            {
                balance.Object.ID = balance.Key;
                balanceList.Add(balance.Object);
            }

            return balanceList;

        }

        public async Task DeleteBalance(string balanceID)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            await firebase
              .Child("Root")
                .Child("Balance")
                .Child(balanceID)
              .DeleteAsync();

        }

        #endregion

        #region Class

        public async Task<string> PostClass(Class classs)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            var result = await firebase
              .Child("Root")
                .Child("Class")
              .PostAsync(classs);

            return result.Key;

        }

        public async Task<Class> GetClass(string classID)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            var classes = await firebase
              .Child("Root")
                .Child("Class")

                .OrderByKey()
                //.OnceAsync<object>();
            .OnceAsync<Class>();

            List<Class> classesList = new List<Class>();

            foreach (var classs in classes)
            {
                classs.Object.ID = classs.Key;
                classesList.Add(classs.Object);
            }

            return classesList[0];


        }

        public async Task<List<Class>> SearchClass(string startAt, string endAt)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            var classes = await firebase
              .Child("Root")
                .Child("Class")
              .OrderBy("Date")
                .StartAt(startAt)
                .EndAt(endAt)
              .OnceAsync<Class>();

            List<Class> classesList = new List<Class>();

            foreach (var classs in classes)
            {
                classs.Object.ID = classs.Key;
                classesList.Add(classs.Object);
            }

            return classesList;


        }


        public async Task DeleteClass(string classID)
        {
            var firebase = new FirebaseClient(firebaseRepo);

            await firebase
              .Child("Root")
                .Child("Class")
                .Child(classID)
              .DeleteAsync();

        }

#endregion

    }
}
