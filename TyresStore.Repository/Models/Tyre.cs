using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyresStore.Repository.Models
{
    public class Tyre
    {
        [Key]
        public int ID { get; set; }
        
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        public string Brand { get; set; }

        public string Season { get; set; }

        public string ArticleCode { get; set; }

        public double Price { get; set; }
    }
}
