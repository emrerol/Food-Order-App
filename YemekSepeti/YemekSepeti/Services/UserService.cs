using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.Model;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;

namespace YemekSepeti.Services
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://yemeksepeti-4f8d7-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<bool> IsUserExists(string uName)
        {
            var user = (await client.Child("Users")
                       .OnceAsync<User>()).Where(u => u.Object.Username == uName).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username = uname,
                    Password = passwd,
                });
                return true;
            }

            else
            {
                return false;
            }
        }

            public async Task<bool> LoginUser(string uname, string passwd)
            {
                var user = (await client.Child("Users")
                    .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                  .Where(u => u.Object.Password == passwd).FirstOrDefault();

                return (user != null);
            }
    
    }
}
