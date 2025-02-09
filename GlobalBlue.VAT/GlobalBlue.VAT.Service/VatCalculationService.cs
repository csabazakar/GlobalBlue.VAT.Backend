using GlobalBlue.VAT.Domain;

namespace GlobalBlue.VAT.Service;

public class VatCalculationService : IVatCalculationService
{
    public VatCalculationAmounts CalculateByGrossAmount(decimal vatRate, decimal grossAmount)
    {
        if (grossAmount <= 0)
        {
            throw new ArgumentException("Gross amount must be greater than 0", nameof(grossAmount));
        }

        if (vatRate <= 0)
        {
            throw new ArgumentException("VAT rata must be greater than 0", nameof(vatRate));
        }

        var netAmount = grossAmount / (1 + vatRate / 100);

        return new VatCalculationAmounts
        {
            GrossAmount = grossAmount,
            NetAmount = netAmount,
            VatAmount = grossAmount - netAmount
        };
    }

    public VatCalculationAmounts CalculateByNetAmount(decimal vatRate, decimal netAmount)
    {
        if (netAmount <= 0)
        {
            throw new ArgumentException("Net amount must be greater than 0", nameof(netAmount));
        }

        if (vatRate <= 0)
        {
            throw new ArgumentException("VAT rata must be greater than 0", nameof(vatRate));
        }

        var vatAmount = netAmount * vatRate / 100;

        return new VatCalculationAmounts
        {
            GrossAmount = vatAmount + netAmount,
            NetAmount = netAmount,
            VatAmount = vatAmount
        };
    }

    public VatCalculationAmounts CalculateByVatAmount(decimal vatRate, decimal vatAmount)
    {
        if (vatAmount <= 0)
        {
            throw new ArgumentException("VAT amount must be greater than 0", nameof(vatAmount));
        }

        if (vatRate <= 0)
        {
            throw new ArgumentException("VAT rata must be greater than 0", nameof(vatRate));
        }

        var netAmount = vatAmount * vatRate / 100;

        return new VatCalculationAmounts
        {
            GrossAmount = netAmount + vatAmount,
            NetAmount = netAmount,
            VatAmount = vatAmount
        };
    }
}
