using System;

public class ChargeRateParameter : IBatteryParameter
{
    public float limitMax = 0.8f;

    public bool EarlyWarningEnabled { get; set; } = true;
    public float EarlyWarningTolerencePercentage { get; set; } = 5;

    float earlyWarningLimitMax;

    public ChargeRateParameter(bool enableEarlyWarning, float earlyWarningTolerence)
    {
        EarlyWarningEnabled = enableEarlyWarning;
        EarlyWarningTolerencePercentage = earlyWarningTolerence;

        earlyWarningLimitMax = limitMax - MathUtils.GetPercentageAmount(limitMax, EarlyWarningTolerencePercentage);
    }

    public bool Validate(float value, Action<string> printCallback)
    {
        if (!MathUtils.IsValueMoreThan(value, limitMax))
        {
            CheckEarlyWarning(value, printCallback);
            return true;
        }

        printCallback(Localization.GetInSelectedLanguage(Localization.Phrases.ChargeRate_OutOfRange));
        return false;
    }

    public void CheckEarlyWarning(float value, Action<string> printCallback)
    {
        if (EarlyWarningEnabled)
        {
            if (MathUtils.IsValueMoreThan(value, earlyWarningLimitMax))
            {
                printCallback(Localization.GetInSelectedLanguage(Localization.Phrases.ChargeRate_ApproachingMaximum));
            }
        }
    }
}
