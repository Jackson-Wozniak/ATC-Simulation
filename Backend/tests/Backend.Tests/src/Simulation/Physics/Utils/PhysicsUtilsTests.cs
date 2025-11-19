using Backend.Simulation.Physics.Utils;

namespace Backend.Tests.Simulation.Physics.Utils;

public class PhysicsUtilsTests
{
    [Fact]
    public void ToRadians_AllArcAngles_IsCorrect()
    {
        Assert.Equal(0, PhysicsUtils.ToRadians(0), 10);
        Assert.Equal(Math.PI / 2, PhysicsUtils.ToRadians(90), 10);
        Assert.Equal(Math.PI, PhysicsUtils.ToRadians(180), 10);
        Assert.Equal(3 * Math.PI / 2, PhysicsUtils.ToRadians(270), 10);
        Assert.Equal(2 * Math.PI, PhysicsUtils.ToRadians(360), 10);
    }
    
    [Fact]
    public void ToDegrees_AllArcAngles_IsCorrect()
    {
        Assert.Equal(0, PhysicsUtils.ToDegrees(0), 10);
        Assert.Equal(90, PhysicsUtils.ToDegrees(Math.PI / 2), 10);
        Assert.Equal(180, PhysicsUtils.ToDegrees(Math.PI), 10);
        Assert.Equal(270, PhysicsUtils.ToDegrees(3 * Math.PI / 2), 10);
        Assert.Equal(360, PhysicsUtils.ToDegrees(2 * Math.PI), 10);
    }
    
    [Fact]
    public void KnotsToFeetPerSecond_SmokeTest()
    {
        Assert.Equal(0, PhysicsUtils.KnotsToFeetPerSec(0), 5);

        Assert.Equal(1.68781, PhysicsUtils.KnotsToFeetPerSec(1), 5);

        Assert.Equal(16.8781, PhysicsUtils.KnotsToFeetPerSec(10), 5);

        Assert.Equal(168.781, PhysicsUtils.KnotsToFeetPerSec(100), 5);
    }
}