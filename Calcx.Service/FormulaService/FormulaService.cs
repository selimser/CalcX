using CSharpMath.SkiaSharp;
using System;
using System.Drawing;
using System.IO;

namespace Calcx.Service.FormulaService
{
    public class FormulaService : IFormulaService
    {
        public string TestMethod()
        {
            var painter = new MathPainter()
            {
                LaTeX = @"F(x) &= \int^a_b \frac{1}{3}x^3"
            };

            var imageStream = painter.DrawAsStream(format: SkiaSharp.SKEncodedImageFormat.Png, textPainterCanvasWidth: 250 );

            byte[] arrayData;
            using (var memoryStream = new MemoryStream())
            {
                imageStream.CopyTo(memoryStream);
                arrayData = memoryStream.ToArray();
            }

            var base64String = Convert.ToBase64String(arrayData);

            return base64String;
        }
    }
}
