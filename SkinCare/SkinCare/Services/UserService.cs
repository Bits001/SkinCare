using Firebase.Database;
using SkinCare.Model;
using System.Linq; 
using Firebase.Database.Query;
using System.Threading.Tasks;

namespace SkinCare.Services

{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://skincare-1c26a-default-rtdb.firebaseio.com/");

        }

        public async Task<bool> IsUserExists(string username)
        {
            var user = (await client.Child("Users").OnceAsync<User>())
                .Where(u => u.Object.UserName == username).FirstOrDefault();
            return user != null;
        }

        public async Task<bool> RegisterUser(string username, string password)
        {
            if(await IsUserExists(username) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        UserName = username,
                        Password = password
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>())
                .Where(u => u.Object.UserName == username)
                .FirstOrDefault(u => u.Object.Password == password);
            
            return user != null;

        }
    }
}
