using System;

public class TemperatureParameter : IBatteryParameter
{
    public float limitMin = 0;
    public float limitMax = 45;

    public bool Validate(float value, Action<string> printCallback)
    {
        if (MathUtils.IsValueInRange(value, limitMin, limitMax))
        {
            return true;
        }

        printCallback("Temperature is out of range!");
        return false;
    }
}
