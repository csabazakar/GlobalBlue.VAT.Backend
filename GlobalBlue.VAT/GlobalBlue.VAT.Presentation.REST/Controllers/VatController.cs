using GlobalBlue.VAT.Domain;
using GlobalBlue.VAT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace GlobalBlue.VAT.Presentation.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class VatController(IVatCalculationService vatCalculationService, IOptions<ApplicationSettings> applicationSettings) : ControllerBase
{
    private readonly IVatCalculationService _vatCalculationService = vatCalculationService;
    private readonly int[] _validVatRates = applicationSettings.Value.ValidVatRates;

    [HttpGet("ByGrossAmount")]
    [ProducesResponseType(typeof(VatCalculationAmounts), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CalculateByGrossAmount(int vatRate,
        [Range(0, double.PositiveInfinity, MinimumIsExclusive = true)] decimal grossAmount)
    {
        if (!_validVatRates.Contains(vatRate))
        {
            return BadRequest();
        }

        return Ok(_vatCalculationService.CalculateByGrossAmount(vatRate, grossAmount));
    }

    [HttpGet("ByNetAmount")]
    [ProducesResponseType(typeof(VatCalculationAmounts), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CalculateByNetAmount(int vatRate,
        [Range(0, double.PositiveInfinity, MinimumIsExclusive = true)] decimal netAmount)
    {
        if (!_validVatRates.Contains(vatRate))
        {
            return BadRequest();
        }

        return Ok(_vatCalculationService.CalculateByNetAmount(vatRate, netAmount));
    }

    [HttpGet("ByVatAmount")]
    [ProducesResponseType(typeof(VatCalculationAmounts), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CalculateVatGrossAmount(int vatRate,
        [Range(0, double.PositiveInfinity, MinimumIsExclusive = true)] decimal vatAmount)
    {
        if (!_validVatRates.Contains(vatRate))
        {
            return BadRequest();
        }

        return Ok(_vatCalculationService.CalculateByVatAmount(vatRate, vatAmount));
    }

    [HttpGet("VatRates")]
    [ProducesResponseType(typeof(int[]), StatusCodes.Status200OK)]
    public IActionResult GetVatRates()
    {
        return Ok(_validVatRates);
    }
}
