using System;

public class SocParameter : IBatteryParameter
{
    public float limitMin = 20;
    public float limitMax = 80;

    public bool Validate(float value, Action<string> printCallback)
    {
        if (MathUtils.IsValueInRange(value, limitMin, limitMax))
        {
            return true;
        }

        printCallback("State of Charge is out of range!");
        return false;
    }
}
