using System.Text.RegularExpressions;
using FluentValidation;
using WebApi.RegisterCustomer.ViewModel;

namespace WebApi.RegisterCustomer.Validations
{
  public class CustomerValidator : AbstractValidator<CustomerDtos>
  {
    public CustomerValidator()
    {
      RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(60)
                .WithMessage("Name is required!");

      RuleFor(c => c.TaxId)
                .NotEmpty()
                .NotNull()
                .Must(DocumentValidation)
                .WithMessage("The document provided is not valid.");

      RuleFor(c => c.Password)
                .NotEmpty()
                .NotNull()
                .Must(ValidPassword)
                .WithMessage("Password must contain at least 8 characters, a number, an uppercase letter, a lowercase letter, and a special character.");

      RuleFor(c => c.PhoneNumber);

      RuleFor(c => c.PostalCode);
    }

    public bool DocumentValidation(string value)
    {
      string number = ExtractNumber(value);

      if (number.Length == 11)
      {
        return ValidateCpf(number);
      }


      if (number.Length == 14)
      {
        return ValidateCnpj(number);
      }

      return false;
    }

    public bool ValidateCpf(string value)
    {

      if (value.Length != 11)
        return false;

      string number = value.Substring(0, 9);
      string dv = value.Substring(9, 2);
      int sum = 0;

      for (int i = 0; i < 9; i++)
        sum += int.Parse(number.Substring(i, 1)) * (10 - i);

      if (sum == 0)
        return false;

      sum = 11 - (sum % 11);

      if (sum > 9)
        sum = 0;

      if (int.Parse(dv.Substring(0, 1)) != sum)
        return false;

      sum *= 2;
      for (int i = 0; i < 9; i++)
        sum += int.Parse(number.Substring(i, 1)) * (11 - i);

      sum = 11 - (sum % 11);
      if (sum > 9)
        sum = 0;
      if (int.Parse(dv.Substring(1, 1)) != sum)
        return false;

      return true;
    }

    public static bool ValidateCnpj(string value)
    {

      if (value.Length != 14)
        return false;

      string number = value.Substring(0, 12);
      string dv = value.Substring(12, 2);
      int sum = 0;

      for (int i = 0; i < 12; i++)
        sum += int.Parse(number.Substring(11 - i, 1)) * (2 + (i % 8));

      if (sum == 0)
        return false;

      sum = 11 - (sum % 11);
      if (sum > 9)
        sum = 0;

      if (int.Parse(dv.Substring(0, 1)) != sum)
        return false;

      sum *= 2;
      for (int i = 0; i < 12; i++)
        sum += int.Parse(number.Substring(11 - i, 1)) * (2 + ((i + 1) % 8));

      sum = 11 - (sum % 11);
      if (sum > 9)
        sum = 0;

      if (int.Parse(dv.Substring(1, 1)) != sum)
        return false;

      return true;
    }

    private static string ExtractNumber(string valor)
    {
      return (new Regex(@"\D", RegexOptions.IgnoreCase).Replace(valor, string.Empty));
    }

    public bool ValidPassword(string password)
    {
      var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

      return regex.IsMatch(password);
    }

  }
}
