using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input !");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input !");
        }


        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input !");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (ConvertToDecimal(firstNumber) == 0 || ConvertToDecimal(secondNumber) == 0) 
                {
                    return BadRequest("Cannot divide by zero");
                }

                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input !");
        }

        [HttpGet("aver/{firstNumber}/{secondNumber}/{thirdNumber}")]
        public IActionResult Aver(string firstNumber, string secondNumber, string thirdNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && IsNumeric(thirdNumber))
            {
                var aver = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) + ConvertToDecimal(thirdNumber)) / 3 ;
                return Ok(aver.ToString());
            }
            return BadRequest("Invalid Input !");
        }

        [HttpGet("root/{firstNumber}")]
        public IActionResult Root(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var root = Math.Sqrt(ConvertToDouble(firstNumber));
                return Ok(root.ToString());
            }
            return BadRequest("Invalid Input !");
        }


        private double ConvertToDouble(string strNumber)
        {
            double doubleValue;
            if(double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }

            return 0;

        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

    }
}
