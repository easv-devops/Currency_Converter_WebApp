using api.Helper;
using api.TransferModels;
using Microsoft.AspNetCore.Mvc;
using service;



namespace api.Controllers;

public class HistoryController : ControllerBase
{
    private readonly HistoryService _historyService;
    private readonly ResponseHelper _responseHelper;
    private readonly ILogger<HistoryController> _logger;
   

    public HistoryController(HistoryService historyService, ResponseHelper responseHelper,ILogger<HistoryController> logger)
    {
        _historyService = historyService;
        _responseHelper = responseHelper;
        _logger = logger;

    }

    [HttpGet]
    [Route("/conversion/history")]

    public ResponseDto GetAllHistory()
    {
        return _responseHelper.Success(HttpContext, 200, "Conversion history fetched successfully",
            _historyService.GetAllHistories());
    }

    
}

