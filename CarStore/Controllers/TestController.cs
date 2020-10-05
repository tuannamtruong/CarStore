using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarStore.Controllers
{
    public class TestController : Controller
    {
        IConfiguration Configuration;

        public TestController(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ChangeIt()
        {
            Configuration["Data:CarStoreRepo:ConnectionString"] = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarStoreBackup;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return View("Index");
        }
    }
}
