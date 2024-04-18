using infrastructure;
using NUnit.Framework;

namespace test;

public class UtilitiesTest
{
    [SetUp]
    public void Setup()
    {
        Environment.SetEnvironmentVariable("pgconn", "postgres://user:password@localhost:5432/database");
    }

    [Test]
    public void ProperlyFormattedConnectionString_IsGeneratedCorrectly()
    {
        // Arrange
        Environment.SetEnvironmentVariable("pgconn", "postgres://user:password@localhost:5432/database");

        // Act
        var connectionString = Utilities.ProperlyFormattedConnectionString;

        // Assert
        Assert.That(connectionString, Is.Not.Null.Or.Empty);
        Assert.That(connectionString,
            Is.EqualTo(
                "Server=localhost;DataBase=database;User Id=user;Password=password;Port=5432;Pooling=true;MaxPoolSize=3"));
    }

  
}