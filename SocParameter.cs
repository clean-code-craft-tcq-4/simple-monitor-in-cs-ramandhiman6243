using System;

public class SocParameter : IBatteryParameter
{
    public float limitMin = 20;
    public float limitMax = 80;

    public bool EarlyWarningEnabled { get; set; } = true;
    public float EarlyWarningTolerencePercentage { get; set; } = 5;

    float earlyWarningLimitMin;
    float earlyWarningLimitMax;

    public SocParameter(bool enableEarlyWarning, float earlyWarningTolerence)
    {
        EarlyWarningEnabled = enableEarlyWarning;
        EarlyWarningTolerencePercentage = earlyWarningTolerence;

        float valueRange = limitMax - limitMin;
        float tolerenceValue = MathUtils.GetPercentageAmount(valueRange, EarlyWarningTolerencePercentage);

        earlyWarningLimitMin = limitMin + tolerenceValue;
        earlyWarningLimitMax = limitMax - tolerenceValue;
    }

    public bool Validate(float value, Action<string> printCallback)
    {
        if (MathUtils.IsValueInRange(value, limitMin, limitMax))
        {
            CheckEarlyWarning(value, printCallback);
            return true;
        }

        printCallback(Localization.GetInSelectedLanguage(Localization.Phrases.Soc_OutOfRange));
        return false;
    }

    public void CheckEarlyWarning(float value, Action<string> printCallback)
    {
        if (EarlyWarningEnabled)
        {
            CheckEarlyWarningMin(value, earlyWarningLimitMin, printCallback);
            CheckEarlyWarningMax(value, earlyWarningLimitMax, printCallback);
        }
    }

    public void CheckEarlyWarningMin(float value, float earlyWarningLimitMin, Action<string> printCallback)
    {
        if (MathUtils.IsValueLessThan(value, earlyWarningLimitMin))
        {
            printCallback(Localization.GetInSelectedLanguage(Localization.Phrases.Soc_ApproachingMinimum));
        }
    }

    public void CheckEarlyWarningMax(float value, float earlyWarningLimitMax, Action<string> printCallback)
    {
        if (MathUtils.IsValueMoreThan(value, earlyWarningLimitMax))
        {
            printCallback(Localization.GetInSelectedLanguage(Localization.Phrases.Soc_ApproachingMaximum));
        }
    }
}
