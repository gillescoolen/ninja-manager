using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaManager.Domain.Models
{
    [Table("ninja")]
    public class Ninja
    {
        public int Id { get; set; }
        
        [Required] 
        [MaxLength(100)] 
        [Column(TypeName = "varchar(100)")] 
        public string Name { get; set; } 
        
        [Required] [DefaultValue(1000)]
        public int Gold { get; set; }
        
        public ICollection<NinjaGear> Gear { get; } = new List<NinjaGear>();
    }
}