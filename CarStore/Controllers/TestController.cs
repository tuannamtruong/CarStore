using CarStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CarStore.Controllers
{
    public class TestController : Controller
    {
        IConfiguration Configuration;
        ServerHealthViewModel ServerHealth;

        public TestController(IConfiguration configuration)
        {
            this.Configuration = configuration;
            ServerHealth = new ServerHealthViewModel();
            ServerHealth.MainReadiness = "2";
            ServerHealth.MainLiveness = "1";
            ServerHealth.BackupReadiness = "3";
            ServerHealth.BackupLiveness = "Backup";
        }

        public IActionResult Index()
        {
            return View(ServerHealth);
        }
        public IActionResult UseNoServer()
        {
            Configuration["Data:CarStoreRepo:ConnectionString"] = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Dummy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return View("Index", ServerHealth);
        }
        public IActionResult UseMainServer()
        {
            Configuration["Data:CarStoreRepo:ConnectionString"] = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            return View("Index", ServerHealth);
        }
        public IActionResult UseBackupServer()
        {
            Configuration["Data:CarStoreRepo:ConnectionString"] = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarStoreBackup;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return View("Index", ServerHealth);
        }
    }
}
