using System;

public class CompositeBatteryParameter : IBatteryParameter
{
    float[] values = new float[3];

    public bool EarlyWarningEnabled { get; set; } = false;
    public float EarlyWarningTolerencePercentage { get; set; } = 0;

    public const float TemperatureEarlyWarningTolerence = 5;
    public const float SocEarlyWarningTolerence = 5;
    public const float ChargingRateEarlyWarningTolerence = 5;

    public CompositeBatteryParameter(float temperature, float soc, float chargeRate)
    {
        values[0] = temperature;
        values[1] = soc;
        values[2] = chargeRate;
    }

    IBatteryParameter[] parameters = new IBatteryParameter[]
    {
        new TemperatureParameter(true, TemperatureEarlyWarningTolerence),
        new SocParameter(true, SocEarlyWarningTolerence),
        new ChargeRateParameter(true, ChargingRateEarlyWarningTolerence)
    };

    public bool Validate(float value, Action<string> printCallback)
    {
        bool valid = true;

        for (int i = 0; i < parameters.Length; i++)
        {
            if (!parameters[i].Validate(values[i], printCallback))
            {
                valid = false;
            }
        }

        return valid;
    }

    public void CheckEarlyWarning(float value, Action<string> printCallback) { }
}