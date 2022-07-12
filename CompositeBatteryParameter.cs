using System;

public class CompositeBatteryParameter : IBatteryParameter
{
    float[] values = new float[3];

    public CompositeBatteryParameter(float temperature, float soc, float chargeRate)
    {
        values[0] = temperature;
        values[1] = soc;
        values[2] = chargeRate;
    }

    IBatteryParameter[] parameters = new IBatteryParameter[]
    {
        new TemperatureParameter(),
        new SocParameter(),
        new ChargeRateParameter()
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
}