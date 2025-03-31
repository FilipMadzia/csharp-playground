using NUnit.Framework;

namespace cars_intersection;

[TestFixture]
public class IntersectionTests
{
    private Intersection _intersection;
    
    [SetUp]
    public void Setup()
    {
        _intersection = new Intersection();
    }
    
    [Test]
    public void TestLights()
    {
        _intersection.SetNsLights(true);
        var expected = true;
        var actual = _intersection.NsLights;
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test1Iteration()
    {
        _intersection.RunManualIteration(new Car(Direction.W) { ToDirection = Direction.S }, true);
        var expected = 1;
        var actual = _intersection.W.Count();
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Test2Iterations()
    {
        _intersection.RunManualIteration(new Car(Direction.W) { ToDirection = Direction.S }, false);
        _intersection.RunManualIteration(new Car(Direction.S) { ToDirection = Direction.E }, true);
        
        var expected = 0;
        var actual = _intersection.CarsCount;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Test5Iterations()
    {
        _intersection.RunManualIteration(new Car(Direction.W) { ToDirection = Direction.S }, true);
        _intersection.RunManualIteration(new Car(Direction.S) { ToDirection = Direction.E }, true);
        _intersection.RunManualIteration(new Car(Direction.E) { ToDirection = Direction.W }, false);
        _intersection.RunManualIteration(new Car(Direction.W) { ToDirection = Direction.N }, true);
        _intersection.RunManualIteration(new Car(Direction.N) { ToDirection = Direction.S }, false);
        
        var expected = 2;
        var actual = _intersection.CarsCount;
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}