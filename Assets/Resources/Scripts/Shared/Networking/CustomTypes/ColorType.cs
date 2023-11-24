using UnityEngine;

public class ColorType
{
    public byte r;
    public byte g;
    public byte b;
    public byte a;

    public static object Deserialize(byte[] data)
    {
        var result = new ColorType();
        result.r = data[0];
        result.g = data[1];
        result.b = data[2];
        result.a = data[3];
        return result;
    }

    public static byte[] Serialize(object customType)
    {
        var color = (Color)customType;
        return new byte[] { (byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255), (byte)(color.a * 255) };
    }

    public Color ToColor()
    {
        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }
}