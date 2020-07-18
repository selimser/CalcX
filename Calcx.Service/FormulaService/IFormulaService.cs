using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Calcx.Service.FormulaService
{
    public interface IFormulaService
    {
        Task<string> GenerateFormulaAsBase64(string latexExpression, float painterCanvasWidth = 1024, float fontSize = 14);
        Task<Dictionary<string, string>> GenerateMultipleFormulaAsBase64(Dictionary<string, string> formulaCollection, float painterCanvasWidth = 1024, float fontSize = 14);
    }
}
