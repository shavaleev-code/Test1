using Newtonsoft.Json;
using System;

namespace ConsoleApp1
{
    class Program
    {
        public class User
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }

            public string UserName { get; set; }

            public string Gender { get; set; }

            public string Email { get; set; }
        }

        static void Main(string[] args)
        {
            var user = new User()
            {
                Id = "404",
                Email = "chernikov@gmail.com",
                UserName = "rollinx",
                Name = "Andrey",
                FirstName = "Andrey",
                MiddleName = "Alexandrovich",
                LastName = "Chernikov",
                Gender = "M"
            };

            var jsonUser = JsonConvert.SerializeObject(user);
            System.Console.Write("df");

            System.Console.ReadLine();
        }
    }
}
