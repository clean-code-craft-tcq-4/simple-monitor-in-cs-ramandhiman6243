public class MathUtils
{
    public static bool IsValueInRange(float input, float minLimit, float maxLimit)
    {
        if (input < minLimit || input > maxLimit)
        {
            return false;
        }
        return true;
    }

    public static bool IsValueMoreThan(float input, float maxLimit)
    {
        if (input > maxLimit)
        {
            return true;
        }
        return false;
    }
}