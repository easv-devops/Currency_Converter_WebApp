using Dapper;
using infrastructure.Models;
using Npgsql;

namespace infrastructure.Repository;

public class ConvRepository
{
    private readonly NpgsqlDataSource _dataSource;

    public ConvRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }


    public List<ConversionHistory> GetAllHistories()
    {
        string sql = $@"
                SELECT
                    id AS {nameof(ConversionHistory.Id)},
                    sourcecurrency AS {nameof(ConversionHistory.SourceCurrency)},
                    targetcurrency AS {nameof(ConversionHistory.TargetCurrency)},
                    amount AS {nameof(ConversionHistory.Amount)},
                    convertedamount AS {nameof(ConversionHistory.ConvertedAmount)},
                    timestamp AS {nameof(ConversionHistory.Timestamp)}
                FROM conversionhistory;
            ";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<ConversionHistory>(sql).AsList();
        }
    }
    
    
    public void AddConversion(ConversionHistory history)
    {
        try
        {
            using var conn = _dataSource.OpenConnection();
            using var cmd = new NpgsqlCommand("INSERT INTO conversionhistory (SourceCurrency, TargetCurrency, Amount, ConvertedAmount, Timestamp) VALUES (@SourceCurrency, @TargetCurrency, @Amount, @ConvertedAmount, @Timestamp)", conn);
            cmd.Parameters.AddWithValue("@SourceCurrency", history.SourceCurrency);
            cmd.Parameters.AddWithValue("@TargetCurrency", history.TargetCurrency);
            cmd.Parameters.AddWithValue("@Amount", history.Amount);
            cmd.Parameters.AddWithValue("@ConvertedAmount", history.ConvertedAmount);
            cmd.Parameters.AddWithValue("@Timestamp", history.Timestamp);
                
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            throw ex;
        }
    }


}
