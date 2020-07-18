using Calcx.Service.FormulaService;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calcx.Service.Test
{
    public partial class FormulaServiceTests
    {
        private readonly IFormulaService _formulaService;


        public FormulaServiceTests()
        {
            _formulaService = new FormulaService.FormulaService();

            PrepareMocks();
        }

        private void PrepareMocks()
        {
            
        }
    }
}
