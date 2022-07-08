using System;

public class BatteryChecker
{
    public const float TemperatureLimitMin = 0;
    public const float TemperatureLimitMax = 45;

    public const float SocLimitMin = 20;
    public const float SocLimitMax = 80;

    public const float chargeLimitMax = 0.8f;

    public static bool batteryIsOk(float temperature, float soc, float chargeRate, Action<string> printCallback)
    {
        return temperatureIsOk(temperature, printCallback) && socIsOk(soc, printCallback) && chargeRateIsOk(chargeRate, printCallback);
    }

    public static bool temperatureIsOk(float temperature, Action<string> printCallback)
    {
        if (!IsValueInLimit(temperature, TemperatureLimitMin, TemperatureLimitMax)
        {
            printCallback("Temperature is out of range!");
            return false;
        }
        return true;
    }

    public static bool socIsOk(float soc, Action<string> printCallback)
    {
        if (!IsValueInLimit(soc, SocLimitMin, SocLimitMax))
        {
            printCallback("State of Charge is out of range!");
            return false;
        }
        return true;
    }

    public static bool chargeRateIsOk(float chargeRate, Action<string> printCallback)
    {
        if (IsValueMoreThan(chargeRate, chargeLimitMax))
        {
            printCallback("Charge Rate is out of range!");
            return false;
        }
        return true;
    }

    public static bool IsValueInLimit(float input, float minLimit, float maxLimit)
    {
        if (input < minLimit || input > maxLimit)
        {
            return false;
        }
        return true;
    }

    public static bool IsValueMoreThan(float input, float maxLimit)
    {
        if (input > maxLimit)
        {
            return false;
        }
        return true;
    }
}