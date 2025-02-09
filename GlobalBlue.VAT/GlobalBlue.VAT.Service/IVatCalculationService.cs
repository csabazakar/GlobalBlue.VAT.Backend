using GlobalBlue.VAT.Domain;

namespace GlobalBlue.VAT.Service; 

public interface IVatCalculationService
{
    VatCalculationAmounts CalculateByGrossAmount(decimal vatRate, decimal grossAmount);

    VatCalculationAmounts CalculateByNetAmount(decimal vatRate, decimal netAmount);

    VatCalculationAmounts CalculateByVatAmount(decimal vatRate, decimal vatAmount);
}
