using System;

namespace WebApi.Core.Entities.Views
{
  public partial class VW_FULLDATA_CUSTUMER
  {
    public string name { get; set; }
    public string tax_id { get; set; }
    public string phone_number { get; set; }
    public DateTime? created_at { get; set; }
    public string code { get; set; }
    public string address { get; set; }
    public string district { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string status { get; set; }
  }
}
