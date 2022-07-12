using System;

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
        ExpectTrue(BatteryChecker.batteryIsOk(0, 20, 0.0f, Console.WriteLine));
        ExpectTrue(BatteryChecker.batteryIsOk(45, 80, 0.8f, Console.WriteLine));

        //test temperature out of range
        ExpectFalse(BatteryChecker.batteryIsOk(46, 70, 0.0f, Console.WriteLine));
        ExpectFalse(BatteryChecker.batteryIsOk(-1, 70, 0.0f, Console.WriteLine));

        //test soc out of range
        ExpectFalse(BatteryChecker.batteryIsOk(25, 19, 0.0f, Console.WriteLine));
        ExpectFalse(BatteryChecker.batteryIsOk(25, 81, 0.0f, Console.WriteLine));

        //test chargeRate out of range
        ExpectFalse(BatteryChecker.batteryIsOk(25, 70, 0.81f, Console.WriteLine));

        Console.WriteLine("All ok");
    }
}