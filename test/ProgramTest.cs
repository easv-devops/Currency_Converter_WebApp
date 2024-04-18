using System.Reflection;
using api.Helper;
using infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using NUnit.Framework;


namespace test;

public class ProgramTest
{
    [Test]
    public void Run_DoesNotThrowException()
    {
        // Arrange
        var program = new Program();

        // Act & Assert
        Assert.DoesNotThrow(() => program.Run(null));
    }

}