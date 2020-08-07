namespace PizzaStore.Domain.Models
{
    public class SizeModel : AModel
    {
        public string Name{get;set;}
        public int Diameter {get;set;}
        public string Description{get;set;}
        public override string ToString(){
            return $"{Name} / {Diameter}\" {Description}";
        }
    }
}