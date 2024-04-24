using DemoGenerateursEtValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoGenerateursEtValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAutoRep collectionAutos;

        public HomeController(IAutoRep collectionAutos)
        {
            this.collectionAutos = collectionAutos; // Initialiser la liste d'auto
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 10;
            return View(await PaginatedList<Auto>.CreateAsync((IQueryable<Auto>)this.collectionAutos.MesAuto, pageNumber ?? 1, pageSize));
        }

        public IActionResult Create()
        {
            return View("Ajouter"); //Afficher le formulaire
        }

        public IActionResult Ajouter(Auto auto)
        {
            if (ModelState.IsValid) // Si le modèle est valide, on affiche l'auto
            {
                this.collectionAutos.AddAuto(auto);
                return View("Liste", this.collectionAutos.MesAuto);
                //return View("Auto", auto);
            }
            return View("Ajouter", auto); // Sinon on réaffiche le formulaire

        }

        public IActionResult Details(int id)
        {
            Auto auto = this.collectionAutos.GetAuto(id);
            return View("Auto", auto);
        }

        public IActionResult Delete(int id)
        {
            this.collectionAutos.SupprimerAuto(id);
            return View("Liste", this.collectionAutos.MesAuto);
        }

        public IActionResult Edit(Auto auto)
        {
            return View("Modifier", auto);
        }

        public IActionResult Modifier(Auto auto)
        {
            this.collectionAutos.ModifierAuto(auto);
            return View("Liste", this.collectionAutos.MesAuto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}