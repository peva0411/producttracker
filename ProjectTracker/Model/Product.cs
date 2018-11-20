using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Model
{
  public class Product
  {
    public int ProductId { get; set; }
    public string Asin { get; set; }
    public string UpcSku { get; set; }
    public string Title { get; set; }
    public decimal? Msrp { get; set; }
    public decimal? LastPrice { get; set; }
    public decimal? Cost { get; set; }
    public DateTime? LastScrapped { get; set; }
  }
}
