using infrastructure.Models;
using infrastructure.Repository;

namespace service;

public class HistoryService
{
    private readonly ConvRepository _convRepository;

    public HistoryService(ConvRepository convRepository)
    {
        _convRepository = convRepository;
    }

    public List<ConversionHistory> GetAllHistories()
    {
        return _convRepository.GetAllHistories();
    }

    public void AddConversion(ConversionHistory history)
    {
        _convRepository.AddConversion(history);
    }

}


