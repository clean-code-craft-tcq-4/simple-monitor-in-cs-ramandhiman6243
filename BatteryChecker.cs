using System;

public class BatteryChecker
{
    public static bool batteryIsOk(IBatteryParameter compositeParameter, Action<string> printCallback)
    {
        return compositeParameter.Validate(0, printCallback);
    }

    //public static bool batteryIsOk(IBatteryParameter batteryParameter, float temperature, float soc, float chargeRate, Action<string> printCallback)
    //{
    //    return temperatureIsOk(temperature, printCallback) && socIsOk(soc, printCallback) && chargeRateIsOk(chargeRate, printCallback);
    //}
}
