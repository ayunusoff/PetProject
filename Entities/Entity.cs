using PetProject.Interfaces;

namespace PetProject.Entities 
{
    public class Enitity : IEntity<int>
    {
        public int Id { get; set; }
    }
}