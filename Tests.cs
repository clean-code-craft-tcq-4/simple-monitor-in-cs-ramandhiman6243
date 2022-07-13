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
        CompositeBatteryParameter compositeParam = new CompositeBatteryParameter(25, 70, 0.7f);
        ExpectTrue(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        compositeParam = new CompositeBatteryParameter(0, 20, 0.0f);
        ExpectTrue(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        compositeParam = new CompositeBatteryParameter(45, 80, 0.8f);
        ExpectTrue(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        //test temperature out of range
        compositeParam = new CompositeBatteryParameter(46, 70, 0.0f);
        ExpectFalse(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        compositeParam = new CompositeBatteryParameter(-1, 70, 0.0f);
        ExpectFalse(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        //test soc out of range
        compositeParam = new CompositeBatteryParameter(25, 19, 0.0f);
        ExpectFalse(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        compositeParam = new CompositeBatteryParameter(25, 81, 0.0f);
        ExpectFalse(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        //test chargeRate out of range
        compositeParam = new CompositeBatteryParameter(25, 70, 0.81f);
        ExpectFalse(BatteryChecker.batteryIsOk(compositeParam, Console.WriteLine));

        Console.WriteLine(Localization.GetInSelectedLanguage(Localization.Phrases.AllOk));
    }
}