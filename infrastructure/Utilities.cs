namespace infrastructure;



public class Utilities
{
    private static readonly string DBPassword = new(Environment.GetEnvironmentVariable("PASSWORD"));
    public static readonly string connectionStringDev = "Server=localhost:5432;Database=postgres;User Id=postgres;Password=" + DBPassword + ";";
    public static readonly string connectionStringProd = "Server=app-database:5432;Database=postgres;User Id=postgres;Password=" + DBPassword + ";";
}
    /*public static class Utilities
    {
        private static readonly string? PgConn = Environment.GetEnvironmentVariable("pgconn");

        private static readonly Uri Uri = !string.IsNullOrEmpty(PgConn) ? new Uri(PgConn) : throw new ArgumentNullException("pgconn", "Environment variable 'pgconn' is not set or is empty.");

        public static readonly string ProperlyFormattedConnectionString = string.Format(
            "Server={0};DataBase={1};User Id={2};Password={3};Port={4};Pooling=true;MaxPoolSize=3",
            Uri.Host,
            Uri.AbsolutePath.Trim('/'),
            Uri.UserInfo.Split(':')[0],
            Uri.UserInfo.Split(':')[1],
            Uri.Port > 0 ? Uri.Port : 5432);
    }*/
