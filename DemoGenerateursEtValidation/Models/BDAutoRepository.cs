using DemoGenerateursEtValidation.Models;

namespace DemoGenerateursEtValidation.Models
{
    public class BDAutoRepository : IAutoRep
    {
        private readonly CatalogueAutoDbContext _catalogueAutoDbContext;

        public BDAutoRepository(CatalogueAutoDbContext catalogueAutoDbContext)
        {
            _catalogueAutoDbContext = catalogueAutoDbContext;
        }

        public List<Auto> MesAuto
        {
            get
            {
               return _catalogueAutoDbContext.Autos.OrderBy(x => x.Id).ToList();
            }
        }

        public Auto GetAuto(int? id)
        {
            return _catalogueAutoDbContext.Autos.FirstOrDefault(x => x.Id == id);
        }

        public void AddAuto(Auto auto)
        {
            _catalogueAutoDbContext.Autos.Add(auto);
            _catalogueAutoDbContext.SaveChanges();
        }

        public void ModifierAuto(Auto auto)
        {
            var autoExiste = _catalogueAutoDbContext.Autos.FirstOrDefault(x => x.Id == auto.Id);
            if (autoExiste != null)
            {
                autoExiste = auto;
                _catalogueAutoDbContext.SaveChanges();
            }
        }

        public void SupprimerAuto(int? id)
        {
            var autoAsupprimer = _catalogueAutoDbContext.Autos.FirstOrDefault(x => x.Id == id);
            if(autoAsupprimer != null)
            {
                _catalogueAutoDbContext.Autos.Remove(autoAsupprimer);
                _catalogueAutoDbContext.SaveChanges();
            }
        }
    }
}
