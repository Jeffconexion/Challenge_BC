using System.Text.RegularExpressions;
using FluentAssertions;
using WebApi.RegisterCustomer.Validations;
using Xunit;


namespace WebApi.UnitTest.Validators
{
  public class CustomerValidatorTests
  {
    [Fact(DisplayName = "Validate cpf.")]
    [Trait("CustomerValidator", "Return true")]
    public void CustomerValidator_Cpf_ReturnTrue()
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation("557.611.520-10");

      //Assert
      customerResult.Should().BeTrue().And.Be(true);
    }

    [Fact(DisplayName = "Validate cpf.")]
    [Trait("CustomerValidator", "Return false")]
    public void CustomerValidator_Cpf_ReturnFalse()
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation("557.611.520-11");

      //Assert
      customerResult.Should().BeFalse().And.Be(false);
    }

    [Theory(DisplayName = "Teoria - Validate many cpf.")]
    [Trait("CustomerValidator", "Return true")]
    [InlineData("388.455.970-24")]
    [InlineData("68889204028")]
    [InlineData("09833886019")]
    [InlineData("974.928.090-34")]
    [InlineData("07612635003")]
    [InlineData("088.702.870-50")]
    public void CustomerValidator_TheoryCpf_ReturnTrue(string cpf)
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation(cpf);

      //Assert
      customerResult.Should().BeTrue().And.Be(true).And.NotBe(false);
    }

    [Theory(DisplayName = "Teoria - Validate many cpf.")]
    [Trait("CustomerValidator", "Return true")]
    [InlineData("388.465.970-24")]
    [InlineData("68189204028")]
    [InlineData("09833887019")]
    [InlineData("964.928.090-34")]
    [InlineData("07612635103")]
    [InlineData("088.709.870-50")]
    public void CustomerValidator_TheoryCpf_ReturnFalse(string cpf)
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation(cpf);

      //Assert
      customerResult.Should().BeFalse().And.Be(false).And.NotBe(true);
    }

    [Fact(DisplayName = "Validate cnpj.")]
    [Trait("CustomerValidator", "Return true")]
    public void CustomerValidator_Cnpj_ReturnTrue()
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation("63.111.399/0001-06");

      //Assert
      customerResult.Should().BeTrue().And.Be(true);
    }

    [Fact(DisplayName = "Validate cnpj.")]
    [Trait("CustomerValidator", "Return false")]
    public void CustomerValidator_Cnpj_ReturnFalse()
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation("53.111.399/0001-06");

      //Assert
      customerResult.Should().BeFalse().And.Be(false);
    }

    [Theory(DisplayName = "Teoria - Validate many cnpj.")]
    [Trait("CustomerValidator", "Return true")]
    [InlineData("57.118.182/0001-17")]
    [InlineData("79.218.363/0001-58")]
    [InlineData("29.364.310/0001-77")]
    [InlineData("22543378000174")]
    [InlineData("11141208000147")]
    [InlineData("78324752000103")]
    public void CustomerValidator_TheoryCnpj_ReturnTrue(string cnpj)
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation(cnpj);

      //Assert
      customerResult.Should().BeTrue().And.Be(true).And.NotBe(false);
    }

    [Theory(DisplayName = "Teoria - Validate many cnpj.")]
    [Trait("CustomerValidator", "Return true")]
    [InlineData("17.118.182/0001-17")]
    [InlineData("29.218.363/0001-58")]
    [InlineData("39.364.310/0001-77")]
    [InlineData("42543378000174")]
    [InlineData("51141208000147")]
    [InlineData("68324752000103")]
    public void CustomerValidator_TheoryCnpj_ReturnFalse(string cnpj)
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = customer.DocumentValidation(cnpj);

      //Assert
      customerResult.Should().BeFalse().And.Be(false).And.NotBe(true);
    }

    [Fact(DisplayName = "Validate Number Extraction.")]
    [Trait("CustomerValidator", "Return true")]
    public void CustomerValidator_NumberExtraction_ReturnTrue()
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = CustomerValidator.ExtractNumber("557.611.520-11");

      //Assert
      Regex.IsMatch(customerResult, @"^[0-9]*$").Should().BeTrue().And.NotBe(false);
    }

    [Theory(DisplayName = "Teoria - Validate many number Extraction.")]
    [Trait("CustomerValidator", "Return true")]
    [InlineData("388.455.970-24", "38845597024")]
    [InlineData("340.841.420-34", "34084142034")]
    [InlineData("367.503.660-07", "36750366007")]
    [InlineData("168.132.950-63", "16813295063")]
    [InlineData("3892.617.640-10", "389261764010")]
    public void CustomerValidator_ManyNumberExtraction_ReturnTrue(string CpfToClean, string CpfClean)
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = CustomerValidator.ExtractNumber(CpfToClean);

      //Assert
      customerResult.Should().NotBeEmpty().And.BeEquivalentTo(CpfClean).And.NotBeEquivalentTo(CpfToClean);
    }

    [Fact(DisplayName = "Validate Password.")]
    [Trait("CustomerValidator", "Return true")]
    public void CustomerValidator_Password_ReturnTrue()
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = CustomerValidator.ValidPassword("12345678Ac%");

      //Assert
      customerResult.Should().BeTrue().And.Be(true);
    }

    [Fact(DisplayName = "Validate Password.")]
    [Trait("CustomerValidator", "Return false")]
    public void CustomerValidator_Password_ReturnFalse()
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = CustomerValidator.ValidPassword("1234567891");

      //Assert
      customerResult.Should().BeFalse().And.Be(false);
    }

    [Theory(DisplayName = "Teoria - Validate many password.")]
    [Trait("CustomerValidator", "Return true")]
    [InlineData("3&8Dt36!")]
    [InlineData("3l%894Iv")]
    [InlineData("iISKT5&31^^@")]
    [InlineData("l0ldHg661&AZ")]
    [InlineData("hzYh1i8Y5D8z758uF4!&k7")]
    [InlineData("hzYh1i8Y5D8z758uFfdsfdsf4!&k7")]
    [InlineData("W5IH0XL!zEmeUWQ$m5$lUe4m72e^qj")]
    public void CustomerValidator_ManyPassword_ReturnTrue(string password)
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = CustomerValidator.ValidPassword(password);

      //Assert
      customerResult.Should().BeTrue().And.Be(true).And.NotBe(false);
    }

    [Theory(DisplayName = "Teoria - Validate many password.")]
    [Trait("CustomerValidator", "Return false")]
    [InlineData("3&8Dt1*")]
    [InlineData("v3%0R")]
    [InlineData("&X8h72G")]
    [InlineData("3670014457")]
    [InlineData("f4l88i586b")]
    [InlineData("#!*01&25!61%95653")]
    [InlineData("AMangwZ$rqJmxgcwohptC")]
    public void CustomerValidator_ManyPassword_ReturnFase(string password)
    {
      //Arrange
      CustomerValidator customer = new CustomerValidator();

      //Act
      var customerResult = CustomerValidator.ValidPassword(password);

      //Assert
      customerResult.Should().BeFalse().And.Be(false).And.NotBe(true);
    }

  }
}


