using FizzBuzzCore;
using FizzBuzzCore.Exceptions;
using FizzBuzzService.Interfaces;
using FizzBuzzWeb.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace FizzBuzzWeb.Controllers
{
    public class FizzBuzzController : ApiController
    {
        private IFizzBuzzService fizzBuzzService;
        private ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        private string errorBaseMsg = "Something went wrong inside Get action: {0}";

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            this.fizzBuzzService = fizzBuzzService;
        }

        [Route("Get")]
        public async Task<IHttpActionResult> GetAsync(int start)
        {
            try
            {
                var limit = new FizzBuzzConfigurationManager().Limite;
                var fizzBuzzParams = new Dictionary<int, string>() {
                    {3, "Fizz"},
                    {5, "Buzz"}
                };

                var fizzBuzzResult = await fizzBuzzService.DoFizzBuzzAsync(start, fizzBuzzParams, limit);
                if (fizzBuzzResult.Count != 0)
                {
                    await FileGenerator.PersistToFile(fizzBuzzResult);
                }

                return Ok(fizzBuzzResult);
            }
            catch (InvalidKeyException ex)
            {
                var errorMsg = string.Format(errorBaseMsg, ex.Message);
                logger.Error(errorMsg);
                return BadRequest(errorMsg);
            }
            catch (InvalidRangeException ex)
            {
                var errorMsg = string.Format(errorBaseMsg, ex.Message);
                logger.Error(errorMsg);
                return BadRequest(errorMsg);
            }
            catch (Exception ex)
            {
                var errorMsg = string.Format(errorBaseMsg, ex.Message);
                logger.Error(errorMsg);
                return InternalServerError(new Exception(errorMsg));
            }
        }
    }
}
