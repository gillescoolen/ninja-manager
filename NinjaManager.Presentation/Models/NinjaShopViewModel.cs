#nullable enable

using System.Collections.Generic;
using NinjaManager.Domain.Models;

namespace NinjaManager.Models
{
  public class NinjaShopViewModel
  {
    public ICollection<Gear>? gear { get; set; }
    public Ninja? ninja { get; set; }
  }
}