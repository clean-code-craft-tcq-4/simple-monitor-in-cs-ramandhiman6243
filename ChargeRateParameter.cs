using System;

public class ChargeRateParameter : IBatteryParameter
{
    public float limitMax = 0.8f;

    public bool EarlyWarningEnabled { get; set; } = true;
    public float EarlyWarningTolerencePercentage { get; set; } = 5;

    public ChargeRateParameter(bool enableEarlyWarning, float earlyWarningTolerence)
    {
        EarlyWarningEnabled = enableEarlyWarning;
        EarlyWarningTolerencePercentage = earlyWarningTolerence;
    }

    public bool Validate(float value, Action<string> printCallback)
    {
        if (!MathUtils.IsValueMoreThan(value, limitMax))
        {
            CheckEarlyWarning(value, printCallback);
            return true;
        }

        printCallback("Charge rate is out of range!");
        return false;
    }

    public void CheckEarlyWarning(float value, Action<string> printCallback)
    {
        if (EarlyWarningEnabled)
        {
            float earlyWarningLimitMax = limitMax - MathUtils.GetPercentageAmount(limitMax, EarlyWarningTolerencePercentage);

            if (MathUtils.IsValueMoreThan(value, earlyWarningLimitMax))
            {
                printCallback("Warning: Approaching maximum Charge rate!");
            }
        }
    }
}
