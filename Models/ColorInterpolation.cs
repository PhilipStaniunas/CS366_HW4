using System.Collections.Generic;
using System.Drawing;

public class ColorInterpolation
{
    public string StartColor { get; set; }
    public string EndColor { get; set; }
    public int Steps { get; set; }
    public List<string> InterpolatedColors { get; set; } = new List<string>();

    public void Interpolate()
    {
        Color start = ColorTranslator.FromHtml(StartColor);
        Color end = ColorTranslator.FromHtml(EndColor);

        for (int i = 0; i <= Steps; i++)
        {
            double ratio = (double)i / Steps;
            int r = (int)(start.R + (end.R - start.R) * ratio);
            int g = (int)(start.G + (end.G - start.G) * ratio);
            int b = (int)(start.B + (end.B - start.B) * ratio);
            InterpolatedColors.Add(ColorTranslator.ToHtml(Color.FromArgb(r, g, b)));
        }
    }
}