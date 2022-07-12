using System;

public class ChargeRateParameter : IBatteryParameter
{
    public float limitMax = 0.8f;

    public bool Validate(float value, Action<string> printCallback)
    {
        if (!MathUtils.IsValueMoreThan(value, limitMax))
        {
            return true;
        }

        printCallback("Charge rate is out of range!");
        return false;
    }
}
