using Microsoft.AspNetCore.Mvc;
using MvcNetCoreAWSPostgresEC2.Models;
using MvcNetCoreAWSPostgresEC2.Repositories;
using System.Threading.Tasks;

namespace MvcNetCoreAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryHospitales repo;
        public DepartamentosController(RepositoryHospitales repo)
        {
            this.repo=repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> dept = await this.repo.GetDepartamentosAsync();
            return View(dept);
        }
        public async Task<IActionResult>Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamento(id);
            return View(dept);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int idDepartamento, string nombre, string localidad)
        {
            await this.repo.InsertDepartamento(idDepartamento, nombre, localidad);
            return RedirectToAction("Index");
        }
    }
}
