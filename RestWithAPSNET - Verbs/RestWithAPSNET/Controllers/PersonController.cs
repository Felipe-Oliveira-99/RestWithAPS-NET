using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithAPSNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        //get 
        [HttpGet("sum/{firtsNumber}/{secondNumber}")]
        public IActionResult Sum(string firtsNumber, string secondNumber)
        {
            if(IsNumeric(firtsNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtsNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest();
        }

        [HttpGet("subtraction/{firtsNumber}/{secondNumber}")]
        public IActionResult SubTraction(string firtsNumber, string secondNumber)
        {
            if (IsNumeric(firtsNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firtsNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest();
        }

        private decimal ConvertToDecimal(string number)
        {
            if (decimal.TryParse(number, out decimal decimalNumber))
                return decimalNumber;
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            var isNumber =  double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double number);
            return isNumber;


        }
    }
}
