using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaManager.Business.Models
{
    [Table("gear")]
    public class Gear
    {
        public int Id { get; set; }
        
        [Required]
        public int Price { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        
        [Required]
        public int Strength { get; set; }
        
        [Required]
        public int Intelligence { get; set; }
        
        [Required]
        public int Agility { get; set; }
        
        [Required]
        public GearType Slot { get; set; }
        
        public ICollection<NinjaGear> Ninjas { get; } = new List<NinjaGear>();

    }
}