using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class RecordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Create([FromBody] Record record)
        {
            try
            {
                var db = new MyAppContext();
                if (record != null)
                {
                    db.Records.Add(record);
                }

                db.SaveChanges();
            }
            catch (Exception e)
            {
               
            }              
        }
    }
}
