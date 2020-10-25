using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NinjaManager.Domain.Models
{
  [Table("ninja_gear")]
  public class NinjaGear
  {
    public int GearId { get; set; }

    public Gear Gear { get; set; }

    public int NinjaId { get; set; }

    public Ninja Ninja { get; set; }

    [Required]
    public int Price { get; set; }
  }
}