using System;

public static class Utils_Maths
{
    // SnapAngle method snaps an angle to the nearest multiple of stepSize, with an optional startOffset
    public static int SnapAngle(int angle, int startOffset, int stepSize)
    {
        int positiveInt = Math.Abs(angle);

        int quotient = (positiveInt + startOffset) / stepSize;
        int remainder = (positiveInt + startOffset) % stepSize;

        if (remainder >= stepSize / 2f)
            quotient++;

        return Math.Sign(angle) * (quotient * stepSize - startOffset);
    }

    // PowerOfTwo method calculates the value of 2 raised to the power of the input power
    public static int PowerOfTwo(int power)
    {
        // Bitshift to the left = multiply by 2
        return 1 << power;
    }
}
