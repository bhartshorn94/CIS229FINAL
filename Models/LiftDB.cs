using System.Data.Entity;

namespace MountainOperations.Models
{
    public class LiftDB : DbContext
    {
        public LiftDB() : base("name=LiftDB")
        {
        }
        public System.Data.Entity.DbSet<MountainOperations.Models.Lift> Lifts { get; set; }
    }
}