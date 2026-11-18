class RemoteControlCar
{
    private int _meters = 0;
    private int _batteries = 100;
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_meters} meters";
    }

    public string BatteryDisplay()
    {
        return _batteries == 0 ? "Battery empty" : $"Battery at {_batteries}%";
    }

    public void Drive()
    {
        if (_batteries > 0)
        {
            _meters += 20;
            _batteries--;
        }
    }
}
