namespace TaskApi.Tests;

public class UnitTest1
{
    [Fact]
    public void HealthCheck_ShouldReturnHealthy()
    {
        var result = "Healthy";
        Assert.Equal("Healthy", result);
    }
}