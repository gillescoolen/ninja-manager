using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

    [Required]
    [DefaultValue(1000)]
    public int Gold { get; set; }

    public ICollection<NinjaGear> Gear { get; } = new List<NinjaGear>();

    public bool HasGear(Gear gear)
    {
      return Gear.ToList().FirstOrDefault(e => e.Gear == gear) != null;
    }

    public Gear GetGearBySlot(GearType type)
    {
      var ninjaGear = Gear.ToList().FirstOrDefault(e => e.Gear.Slot == type);

      return ninjaGear == null ? new Gear { Slot = type } : ninjaGear.Gear;
    }

    public int GetPriceByGear(Gear gear)
    {
      var ninjaGear = Gear.ToList().FirstOrDefault(e => e.Gear == gear);
      return ninjaGear?.Price ?? 0;
    }

    public int? TotalStrength()
    {
      return Gear.ToList().Sum(e => e.Gear.Strength);
    }

    public int? TotalIntelligence()
    {
      return Gear.ToList().Sum(e => e.Gear.Intelligence);
    }
    public int? TotalAgility()
    {
      return Gear.ToList().Sum(e => e.Gear.Agility);
    }
    public int? TotalGearCost()
    {
      return Gear.Sum(e => e.Price);
    }

    public int? TotalGearValue()
    {
      return Gear.ToList().Sum(e => e.Gear.Price);
    }
  }
}