namespace ApiBureau.Sportmonks.Api.Extensions;

public static class NumberExtension
{
    public enum SizeUnits
    {
        Byte, KB, MB, GB, TB, PB, EB, ZB, YB
    }

    public static string ToPrettySize(this long value, SizeUnits unit)
        => (value / (double)Math.Pow(1024, (long)unit)).ToString("0.0000");
}
