using System.Collections.Generic;
using System.Drawing;

public class ColorInterpolation
{
    public string? StartColor { get; set; }
    public string? EndColor { get; set; }
    public int Steps { get; set; }
    public List<string> InterpolatedColors { get; set; } = new List<string>();

    public void Interpolate()
    {
        if (string.IsNullOrWhiteSpace(StartColor) || string.IsNullOrWhiteSpace(EndColor))
            return;  

        Color start = ColorTranslator.FromHtml(FixColor(StartColor));
        Color end = ColorTranslator.FromHtml(FixColor(EndColor));


        for (int i = 0; i <= Steps; i++)
        {
            double ratio = (double)i / Steps;
            int r = (int)(start.R + (end.R - start.R) * ratio);
            int g = (int)(start.G + (end.G - start.G) * ratio);
            int b = (int)(start.B + (end.B - start.B) * ratio);
            InterpolatedColors.Add(ColorTranslator.ToHtml(Color.FromArgb(r, g, b)));
        }
    }
    private string FixColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Color cannot be null or empty.");

        // Remove extra '#' if present
        color = color.Trim();
        while (color.StartsWith("#"))
            color = color.Substring(1);

        // Check if the remaining string is exactly 6 characters and valid hex
        if (color.Length != 6 || !System.Text.RegularExpressions.Regex.IsMatch(color, "^[0-9A-Fa-f]{6}$"))
            throw new ArgumentException($"Invalid hex color format: #{color}");

        return "#" + color; // Return with single '#'
    }


}