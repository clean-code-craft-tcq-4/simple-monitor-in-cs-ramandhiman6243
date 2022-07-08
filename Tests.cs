using System;
using System.Diagnostics;

public class Tests
{
    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }

    public static void PerformTests()
    {
        //test valid values
        ExpectTrue(BatteryChecker.batteryIsOk(25, 70, 0.7f, Console.WriteLine));

        //test temperature out of range
        ExpectFalse(BatteryChecker.batteryIsOk(50, 70, 0.0f, Console.WriteLine));

        //test soc out of range
        ExpectFalse(BatteryChecker.batteryIsOk(25, 85, 0.0f, Console.WriteLine));

        //test chargeRate out of range
        ExpectFalse(BatteryChecker.batteryIsOk(25, 70, 0.9f, Console.WriteLine));

        Console.WriteLine("All ok");
    }
}