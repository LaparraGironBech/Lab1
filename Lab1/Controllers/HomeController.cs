using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab1.Models.Data;
namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View ();
        }
    public IActionResult check(string num)
        {
            
            Singleton.Instance.L= Convert.ToInt32(num);

            if(Singleton.Instance.L==0)
            {
                return Redirect("../Jugadores/Index1");
            }
            else
            {
                return Redirect("../Jugadores/Index");
            }
            
        }

    }
}
