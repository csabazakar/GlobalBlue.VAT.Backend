namespace GlobalBlue.VAT.Service.Tests;

public class VatCalculationServiceTest
{
    [Theory]
    [InlineData(20, 120, 100, 20)]
    public void TestCalculateByGrossAmount(decimal vatRate, decimal grossAmount,
        decimal expectedNetAmount, decimal expectedVatAmount)
    {
        // Arrange
        var vatCalculationService = new VatCalculationService();

        // Act
        var actual = vatCalculationService.CalculateByGrossAmount(vatRate, grossAmount);

        // Assert
        Assert.Equal(expectedNetAmount, actual.NetAmount);
        Assert.Equal(expectedVatAmount, actual.VatAmount);
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(10, 0)]
    [InlineData(-10, 10)]
    [InlineData(10, -10)]
    public void CalculateByGrossAmountThrowsArgumentException(decimal vatRate, decimal grossAmount)
    {
        // Arrange
        var vatCalculationService = new VatCalculationService();

        // Assert
        Assert.Throws<ArgumentException>(
            () => vatCalculationService.CalculateByGrossAmount(vatRate, grossAmount));
    }
}