using System;

public interface IBatteryParameter
{
    bool EarlyWarningEnabled { get; set; }
    float EarlyWarningTolerencePercentage { get; set; }
    bool Validate(float value, Action<string> printCallback);
    void CheckEarlyWarning(float value, Action<string> printCallback);
}
