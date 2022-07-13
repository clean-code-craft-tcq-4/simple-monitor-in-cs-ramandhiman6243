using System;

public class TemperatureParameter : IBatteryParameter
{
    public float limitMin = 0;
    public float limitMax = 45;

    public bool EarlyWarningEnabled { get; set; } = true;
    public float EarlyWarningTolerencePercentage { get; set; } = 5;

    public TemperatureParameter(bool enableEarlyWarning, float earlyWarningTolerence)
    {
        EarlyWarningEnabled = enableEarlyWarning;
        EarlyWarningTolerencePercentage = earlyWarningTolerence;
    }

    public bool Validate(float value, Action<string> printCallback)
    {
        if (MathUtils.IsValueInRange(value, limitMin, limitMax))
        {
            CheckEarlyWarning(value, printCallback);
            return true;
        }

        printCallback("Temperature is out of range!");
        return false;
    }

    public void CheckEarlyWarning(float value, Action<string> printCallback)
    {
        if (EarlyWarningEnabled)
        {
            float valueRange = limitMax - limitMin;
            float tolerenceValue = MathUtils.GetPercentageAmount(valueRange, EarlyWarningTolerencePercentage);

            float earlyWarningLimitMin = limitMin + tolerenceValue;
            float earlyWarningLimitMax = limitMax - tolerenceValue;

            CheckEarlyWarningMin(value, earlyWarningLimitMin, printCallback);
            CheckEarlyWarningMax(value, earlyWarningLimitMax, printCallback);
        }
    }

    public void CheckEarlyWarningMin(float value, float earlyWarningLimitMin, Action<string> printCallback)
    {
        if (MathUtils.IsValueLessThan(value, earlyWarningLimitMin))
        {
            printCallback("Warning: Approaching mininum Temperature!");
        }
    }

    public void CheckEarlyWarningMax(float value, float earlyWarningLimitMax, Action<string> printCallback)
    {
        if (MathUtils.IsValueMoreThan(value, earlyWarningLimitMax))
        {
            printCallback("Warning: Approaching maxinum Temperature!");
        }
    }
}
