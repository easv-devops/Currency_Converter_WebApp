using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using service;

namespace api.Controllers;

public class ConversionController : ControllerBase
{
    private readonly ILogger<ConversionController> _logger;
    private readonly ConverterService _converterService;
    private readonly HistoryService _historyService;

    public ConversionController(ILogger<ConversionController> logger,
        ConverterService converterService,
        HistoryService historyService)
    {
        _logger = logger;
        _converterService = converterService;
        _historyService = historyService;
    }
    


    [HttpGet]
    [Route("/conversion/money")]
    public IActionResult ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
    {
        try
        {
         
            decimal result = _converterService.ConvertCurrency(amount, fromCurrency, toCurrency);

           
            ConversionHistory history = new ConversionHistory
            {
                SourceCurrency = fromCurrency,
                TargetCurrency = toCurrency,
                Amount = amount,
                ConvertedAmount = result,
                Timestamp = DateTime.UtcNow 
            };
            _historyService.AddConversion(history);

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while converting currency and saving conversion history.");
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}



    