using System;

public static class Events
{
   
    public static Action OnEnterCar;
    public static Action OnExitCar;

    public static Action<Car> OnCarBuyed;
}
