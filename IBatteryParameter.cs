using System;

public interface IBatteryParameter
{
    bool Validate(float value, Action<string> printCallback);
}
