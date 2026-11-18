class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _battery = 100;
    private int _distance = 0;
    public RemoteControlCar(int speed,int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _battery < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _distance;
    }

    public void Drive()
    {
       if (BatteryDrained())
        {
            _battery = 0;
            return;
        }

        _distance += _speed;
        _battery -= _batteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
         return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int _distance;
    public RaceTrack(int distane)
    {
        _distance = distane;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();

            if (car.DistanceDriven() >= _distance)
            {
                return true;
            }
        }

        return car.DistanceDriven() >= _distance;

    }
}
