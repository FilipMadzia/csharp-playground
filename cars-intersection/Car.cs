namespace cars_intersection;

public class Car
{
    public Direction FromDirection { get; set; }
    public Direction ToDirection { get; set; }

    public Car(Direction fromDirection)
    {
        FromDirection = fromDirection;
        
        var random = new Random();
        
        do
        {
            ToDirection = (Direction)random.Next(3);
        } while (FromDirection == ToDirection);
    }
}