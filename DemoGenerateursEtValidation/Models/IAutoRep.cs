namespace DemoGenerateursEtValidation.Models
{
    public interface IAutoRep
    {
        //Collection d'autos
        public List<Auto> MesAuto { get; }

        //Méthodes CURD
        public Auto GetAuto(int? id);

        public void AddAuto(Auto auto);

        public void SupprimerAuto(int? id);

        public void ModifierAuto(Auto auto);
    }
}
