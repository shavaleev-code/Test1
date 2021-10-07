using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Server.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger _logger = Log.CreateLogger<LoginController>();

        [HttpGet]
        public string Get(string login, string password)
        {           
            using (var db = new MyAppContext())
            {
                var user = db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();  
                if (user == null)
                {
                    return string.Empty;
                }

                _logger.LogInformation("Аутентификация прошла успешно");
                return JsonConvert.SerializeObject(user);
            }
        }

        [HttpPost]
        public void Create([FromBody] Server.Models.User user)
        {
            try
            {
                var db = new MyAppContext();
                if (user != null)
                {
                    db.Users.Add(user);
                }

                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
    }
}
