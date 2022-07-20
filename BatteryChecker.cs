using System;

public class BatteryChecker
{
    public static bool batteryIsOk(IBatteryParameter compositeParameter, Action<string> printCallback)
    {
        return compositeParameter.Validate(0, printCallback);
    }
}
