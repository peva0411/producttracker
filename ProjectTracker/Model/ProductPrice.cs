using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Model
{
  public class ProductPrice
  {
    public int ProductPriceId { get; set; }
    public string Asin { get; set; }
    public decimal? Price { get; set; }
    public decimal? OneTimePrice { get; set; }
    public decimal? SnsPrice { get; set; }
    public DateTime Date { get; set; }
    public string BuyBoxOwner { get; set; }
    public bool IsAvailable { get; set; }
  }
}
