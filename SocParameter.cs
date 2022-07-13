using System;

public class SocParameter : IBatteryParameter
{
    public float limitMin = 20;
    public float limitMax = 80;

    public bool EarlyWarningEnabled { get; set; } = true;
    public float EarlyWarningTolerencePercentage { get; set; } = 5;
    
    public SocParameter(bool enableEarlyWarning, float earlyWarningTolerence)
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

        printCallback("State of Charge is out of range!");
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

            if (MathUtils.IsValueLessThan(value, earlyWarningLimitMin))
            {
                printCallback("Warning: Approaching mininum State of charge!");
            }
            else if (MathUtils.IsValueMoreThan(value, earlyWarningLimitMax))
            {
                printCallback("Warning: Approaching maximum State of charge!");
            }
        }
    }
}
