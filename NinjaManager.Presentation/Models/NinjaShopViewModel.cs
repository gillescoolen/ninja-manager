#nullable enable

using System.Collections.Generic;
using NinjaManager.Domain.Models;

namespace PROG5_NinjaManager.Models
{
  public class NinjaShopViewModel
  {
    public ICollection<Gear> gear { get; set; }
    public Ninja? ninja { get; set; }
  }
}