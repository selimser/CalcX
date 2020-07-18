using CSharpMath.SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Calcx.Service.FormulaService
{
    public class FormulaService : IFormulaService
    {
        public async Task<string> GenerateFormulaAsBase64(string latexExpression, float painterCanvasWidth = 1024, float fontSize = 14)
        {
            if (string.IsNullOrWhiteSpace(latexExpression))
            {
                return string.Empty;
            }

            var painter = new MathPainter()
            {
                LaTeX = latexExpression,
                FontSize = fontSize
            };

            using (var memoryStream = new MemoryStream())
            {
                var imageStream = painter.DrawAsStream
                (
                    format: SkiaSharp.SKEncodedImageFormat.Png,
                    textPainterCanvasWidth: painterCanvasWidth
                );

                await imageStream.CopyToAsync(memoryStream);

                var base64String = Convert.ToBase64String(memoryStream.ToArray());

                return base64String;
            }
        }

        public async Task<Dictionary<string, string>> GenerateMultipleFormulaAsBase64(Dictionary<string, string> formulaCollection, float painterCanvasWidth = 1024, float fontSize = 14)
        {
            var painter = new MathPainter()
            {
                FontSize = fontSize
            };

            Dictionary<string, string> returnCollection = null;
            if (formulaCollection.Keys.Any())
            {
                returnCollection = new Dictionary<string, string>();

                foreach (var formula in formulaCollection)
                {
                    if (string.IsNullOrWhiteSpace(formula.Value))
                    {
                        continue;
                    }

                    painter.LaTeX = formula.Value;

                    using (var memoryStream = new MemoryStream())
                    {
                        var imageStream = painter.DrawAsStream
                        (
                            format: SkiaSharp.SKEncodedImageFormat.Png,
                            textPainterCanvasWidth: painterCanvasWidth
                        );

                        await imageStream.CopyToAsync(memoryStream);

                        var base64String = Convert.ToBase64String(memoryStream.ToArray());

                        returnCollection.Add(formula.Key, base64String);
                    }
                }
            }

            return returnCollection;
        }
    }
}
