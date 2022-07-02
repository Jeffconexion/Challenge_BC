namespace WebApi.PostalCode.ViewModel
{
  public class PostalCodeViewModel
  {
    public string PostalCode { get; set; }

    public PostalCodeViewModel()
    {
    }

    public PostalCodeViewModel(string postalCode)
    {
      PostalCode = postalCode;
    }
  }
}
