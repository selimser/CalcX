using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Calcx.Service.Test
{
    public partial class FormulaServiceTests
    {
        [Fact(DisplayName = "Single LaTeX formula matches with Base64 representation")]
        public async Task FormulaService_SingleFormula_Base64Matches()
        {
            const string latexFormula = @"F(x) &= \int^a_b \frac{1}{3}x^3";
            const string expectedBase64Response = "iVBORw0KGgoAAAANSUhEUgAAAHEAAAAtCAYAAACZMoRcAAAABHNCSVQICAgIfAhkiAAABM5JREFUeJztnL2S3EQQgD9jEiIrdIZ4AouM7PQADkTmUG+AeAKUAREbklmPsGTOvM4Il8wZIjMJdVdFAJEJepqZ0Y1Wu/rfO31Vqjvtzkqj7ume7p7ZfcLGpeTO/y+Ab5fqyMZpIqACCnMoOVA65/WZ1yu7m2yMTYUorAA+ArF5/RZRMEBm2rWRAz8Be3ONjRmJEWUBpIgSIiABjk67HaKoiDCq+JRNibOzQxTXJAYO5v8I+N28lnVcb3IlPpny4ldKjShyF3jPDWoixGKP+BbaJAXessl6NhLEatIRrzm5JX4y5cWvEHWNh5OtVsamRJ8UeLd0Jy5lU6LPDafnt1WyKdGi8+C5Cfxq+HTpDqwIVeLaLVHn7Qjpc3Gi7UUktCe9pxgzChzKVJWVzFy3j3yaxEh+qhyAopm7REhR9xw0AEgQZYTyqi407zpVvpqLW3PEXQ3PJDfXct10jTzrEJedYYsRRwJyVxPVUVmYcz1KRPvuiB2qgILxBNcXzQ9DlZq1UtBhOHtOjxZ92JLhLlFXDJYkR5R4LasNKWKROyBqi05TTie8R6zVDk2M1Y0lA68zhGsJapQDtjC/CykxAZ5xXzmuy6vxffNQ9owYZfVAB9DalZgBr53zGohDKYaOSleJGWIt6mIr836b4CNs0BIhbqrArsc1fbmOrKV4AdyxbI7oygxERk2ZRcBvTpsYOIYq63ukcuHmIyXwZaOdu0DapMTOLwfTNsculIbuezT3VEFmnB8pgzxcn4GgqwzvWC7lUQXq4HZlVgDfYWWWY6PoCCjbLPFgPhQjruYu0O5ZS4cK7gcqtbnxAfi65XPasbrxmXPpa0VrmA9z2mW2x+/bvSCwqUSdD/f47vSSqK3CF36CHWFda28ucwlV5/qx7ncDvOxo8xfwvXPelNkNVuadMmsqMTQfXpoCNBUYCpLWxNhBzXvg7442/zbOXZmFdHCSkBL/wHdNmgL0IUXmqqZizxFYiYzIc/mFflUjnXfHUuKf5uhLaDnsolTulvOtru2hd9jRvccXrFZ+2u49N7rqvnRqUeF7BFdmOR05tOaJKfAN4vo+IhbQVQrTaNIlwe4AS/EjWA2SQiPKDWjmRIWzpLtPEDmqzGp8mcV0DLKn2B1bnyFmfAd8gZ8XhtCE/43z2gdkTvjHdOQH8/pzc582K8+AX7s6OwGvgK+AH5F+T0GEPH+bp/lgDh3wpfkbITL7eaJ+/c+YFZsxlmouRYv5UxTgE0QhmTmOLFuVaiXFrzL0vcZSD9flbYZQ489luq44ekFh6PaMA9Zv9yHCVuPnJkZigClceAR8jp9fu7vKV0lBP3eo/n8JNDKdygs0dzuoJQ71XBsOJRO5txb2LL9u+uComP6LLjFSvH7L9Sw4XxVH5ssPtXT5muWmjwfJ3NsxYnPPJYK4B4kGNVPNhxHhuu8t23cVR0NXzEGiyJpxFbojHIluShyRPX61aeyEv8Dm0EqEKHCLUEdCtz6A/w3gsdBAxrXuCrtLcFQey7dX3VUS/cEEFWaOXa/T7RBjobvAI0SBmxX2RHd3a2Wmwo9KK+e9jJUWqR87uh4XI5bRtDR3PnR3nF0Nj+H7ibruqXOgu5CtP56gaKS6cUU0f9ZkksBjY3oqRJnu3qCr4j+u4iRGmb0FAwAAAABJRU5ErkJggg==";

            var result = await _formulaService.GenerateFormulaAsBase64(latexFormula);

            Assert.Equal(expectedBase64Response, result);
        }

        [Fact(DisplayName = "Empty LaTeX formula returns empty string")]
        public async Task FormulaService_EmptyFormula_MatchesEmptyBase64()
        {
            var result = await _formulaService.GenerateFormulaAsBase64(string.Empty);
            Assert.Equal(string.Empty, result);
        }

        [Fact(DisplayName = "Null LaTeX formula returns empty string")]
        public async Task FormulaService_NullFormula_MatchesEmptyBase64()
        {
            var result = await _formulaService.GenerateFormulaAsBase64(null);
            Assert.Equal(string.Empty, result);
        }

        [Fact(DisplayName = "Multiple formulae with matching Base64 contents and formula ordering")]
        public async Task FormulaService_MultipleValidFormulas_MatchesExpectedBase64()
        {
            #region Mock Data

            var formulaCollection = new Dictionary<string, string>()
            {
                { "Formula1", @"f(x) &= x^2" },
                { "Formula2", @"F(x) &= \int^a_b \frac{ 1} { 3} x ^ 3" },
                { "Formula3", @"g(x) &= \frac{1}{x}" },
            };

            var multipleFormulaeExpectedValues = new Dictionary<string, string>()
            {
                {
                    "Formula1", "iVBORw0KGgoAAAANSUhEUgAAAEUAAAAUCAYAAADbX/B7AAAABHNCSVQICAgIfAhkiAAAAmJJREFUWIXtmK+C1DAQxn8LCByVOCpxhCeg55DF4a4SR+8Nyhv0DVjcOVaeu8Uhuw7H4k4u7lCHmOSStknb7Z9jBZ9p2jTpzJdvJpOu+I8ISIEYUMB66mTxiHFqykcXQIn4AuLPoW9AAhRA1ngeAflIIxSyMqeCirp/d10vJ3qAAn7qe4NJEkMIPTXFgCilk5QNohKl20ZiKW3ljMFmhjnmRkmPbwf8Mt/OZEDWZ8AD496eR4EXYuAZEj4uFLCfyYgtp5NbTCivAZ54XiiAF7p9rq+f9DWnW/YZNoOXzv2edh7a6z7TvwRSJOwVdpdJ9HWDzZnn+v4NkIRIKYBvWDIMurasHHHcEHINXCAOX+trM/QO1EmJsQsyBL9pq9kg1fNvECK+Al+0bcaHCvE1Al6bgT5SQNjzfSz03OxULmEr7Epc4M9FFe1aZxWw6Vgk1MsGBZzpdoFV7uAQ3uNPgqHtqumYWYE+GFUugchp54QV1YIv0UaIhAdPQj0nRMAr5tulxsJVbcIR9vjCx2RiHyk7+hOjKfJcI0JjmmeNDJvch2DHsMo6oa78o5N7l9S21Ctbg8x5XtImJFSPhOabCgV8dNp31MOpM2R94RNKpiCZ3Feef8aeMiPHgIh6UmsiZpkwK4B3up0Cv6hX5J3V9OPAhJf4ibkBPuh+FzvgOZaEG+At4nQJ3HrmUsBT4KrLwJH4oeeOkQW5RMh4CXzX/UehKbUm1j39Q1Ey7tfD4jBKqZCVvQX+0FaCiwp4jzA+FqbKPMVD4T222BJ+iApSph3984Hf+adwzwRDMVb+xchxD4a/a1iDqygqkJgAAAAASUVORK5CYII="
                },
                {
                    "Formula2", "iVBORw0KGgoAAAANSUhEUgAAAHEAAAAtCAYAAACZMoRcAAAABHNCSVQICAgIfAhkiAAABM5JREFUeJztnL2S3EQQgD9jEiIrdIZ4AouM7PQADkTmUG+AeAKUAREbklmPsGTOvM4Il8wZIjMJdVdFAJEJepqZ0Y1Wu/rfO31Vqjvtzkqj7ume7p7ZfcLGpeTO/y+Ab5fqyMZpIqACCnMoOVA65/WZ1yu7m2yMTYUorAA+ArF5/RZRMEBm2rWRAz8Be3ONjRmJEWUBpIgSIiABjk67HaKoiDCq+JRNibOzQxTXJAYO5v8I+N28lnVcb3IlPpny4ldKjShyF3jPDWoixGKP+BbaJAXessl6NhLEatIRrzm5JX4y5cWvEHWNh5OtVsamRJ8UeLd0Jy5lU6LPDafnt1WyKdGi8+C5Cfxq+HTpDqwIVeLaLVHn7Qjpc3Gi7UUktCe9pxgzChzKVJWVzFy3j3yaxEh+qhyAopm7REhR9xw0AEgQZYTyqi407zpVvpqLW3PEXQ3PJDfXct10jTzrEJedYYsRRwJyVxPVUVmYcz1KRPvuiB2qgILxBNcXzQ9DlZq1UtBhOHtOjxZ92JLhLlFXDJYkR5R4LasNKWKROyBqi05TTie8R6zVDk2M1Y0lA68zhGsJapQDtjC/CykxAZ5xXzmuy6vxffNQ9owYZfVAB9DalZgBr53zGohDKYaOSleJGWIt6mIr836b4CNs0BIhbqrArsc1fbmOrKV4AdyxbI7oygxERk2ZRcBvTpsYOIYq63ukcuHmIyXwZaOdu0DapMTOLwfTNsculIbuezT3VEFmnB8pgzxcn4GgqwzvWC7lUQXq4HZlVgDfYWWWY6PoCCjbLPFgPhQjruYu0O5ZS4cK7gcqtbnxAfi65XPasbrxmXPpa0VrmA9z2mW2x+/bvSCwqUSdD/f47vSSqK3CF36CHWFda28ucwlV5/qx7ncDvOxo8xfwvXPelNkNVuadMmsqMTQfXpoCNBUYCpLWxNhBzXvg7442/zbOXZmFdHCSkBL/wHdNmgL0IUXmqqZizxFYiYzIc/mFflUjnXfHUuKf5uhLaDnsolTulvOtru2hd9jRvccXrFZ+2u49N7rqvnRqUeF7BFdmOR05tOaJKfAN4vo+IhbQVQrTaNIlwe4AS/EjWA2SQiPKDWjmRIWzpLtPEDmqzGp8mcV0DLKn2B1bnyFmfAd8gZ8XhtCE/43z2gdkTvjHdOQH8/pzc582K8+AX7s6OwGvgK+AH5F+T0GEPH+bp/lgDh3wpfkbITL7eaJ+/c+YFZsxlmouRYv5UxTgE0QhmTmOLFuVaiXFrzL0vcZSD9flbYZQ489luq44ekFh6PaMA9Zv9yHCVuPnJkZigClceAR8jp9fu7vKV0lBP3eo/n8JNDKdygs0dzuoJQ71XBsOJRO5txb2LL9u+uComP6LLjFSvH7L9Sw4XxVH5ssPtXT5muWmjwfJ3NsxYnPPJYK4B4kGNVPNhxHhuu8t23cVR0NXzEGiyJpxFbojHIluShyRPX61aeyEv8Dm0EqEKHCLUEdCtz6A/w3gsdBAxrXuCrtLcFQey7dX3VUS/cEEFWaOXa/T7RBjobvAI0SBmxX2RHd3a2Wmwo9KK+e9jJUWqR87uh4XI5bRtDR3PnR3nF0Nj+H7ibruqXOgu5CtP56gaKS6cUU0f9ZkksBjY3oqRJnu3qCr4j+u4iRGmb0FAwAAAABJRU5ErkJggg=="
                },
                {
                    "Formula3", "iVBORw0KGgoAAAANSUhEUgAAAD8AAAAmCAYAAABzhkOMAAAABHNCSVQICAgIfAhkiAAAAnNJREFUaIHtmTGy0zAQQF+AgqH5KijoMB0d5gQRNQUpKOjwDcgRcoQcwdQ0PkKOEE5AfkeH6eigkPQlK7KjLxLLP8mb0UycaNe7Wmm1UuD8EcAXYOP/8GR8W0ajAJb6swTajLZkZUMg8o8yGDIZrs5fKlfnL5Wr85fK1flEViPLpSCBOfBSt7luAMwSla6ABtgmyJbAgnEGoe8dye+WQJUqrKm0ngdHMzE9ydx3zUtgd6R375ho9AvUOdin5rDB5YFng9T6suEnPIk6A9eoAYDuubglPCigkpjQfZa6mXP0Z+BdQGZI38lxLzMkah0W2IP/lrhpbqJrIrkE1tjovoq0Zw28iewL8JUjzZ4d+1vAlu5tyN6FgMbP/m3guxAbjr/unwHPY5qJfIUqAtxRFKgo9Dns4soVwE2k3Cl4D3yM6WicL4BbulNcAr+xhUzsHZgM6BrC1VugghDL94Bd33Q7iHFesG+sP823OKXhAL5coVtoJszpVokSm2hjmPXovReVp6QEfmHXuyEU/UL3dbO9mzsqwhnd9M2GiXyNctgYbbYgf1RrlJN+dXYL/EU5ukAN2hx4q3WEnMy+z/dRETa4RG1HPoJu1vafQ6zpL4BGQwSMqOmPSs3/FyZiQP+oNHSjbKqyvsTjVnypLAf0j8Zj4CfwB3iBcvw18El/H6LVfUI7RAwSeEq+OuAoLEaWS0GgEm/pPH9gArnm1JTYErvRn1eo5faDMx4AQbfWWGG37xK1XLPnnFNR0nVuzQRujnLhnk4vCoGqPs92jfsI7LRfsF+thqrUs2GHXeMN3Zri7to89U+LqVOjtrMZdptrdbsbmH9pX3vuFX9oCgAAAABJRU5ErkJggg=="
                }
            };

            #endregion

            var result = await _formulaService.GenerateMultipleFormulaAsBase64(formulaCollection);

            Assert.Equal(multipleFormulaeExpectedValues, result);
        }
    }
}
