using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using F1Encyclopedia.Data;
using System.Threading.Tasks;
using F1Encyclopedia.Data.Models.Drivers;
using F1Encyclopedia.Data.Models.ConstructorTeams;

namespace F1Encyclopedia.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriversController : Controller
    {
        private readonly ILogger<DriversController> logger;
        private F1EncyclopediaContext dbContext;

        public DriversController(ILogger<DriversController> _logger, F1EncyclopediaContext _dbContext)
        {
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
            dbContext = _dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Finds and returns top 5 drivers.
        /// </summary>
        [HttpGet]
        [Route("/snapshot")]
        public Driver GetDriversSnapshot([FromQuery] int? constructorId = null)
        {
            if (constructorId == null)
            {
                //return dbContext.Drivers.
            }
            return new Driver();
            //var constructor = Constructor.FindByIdAsync()
            //logger.LogInformation(constructorId != null ? "Fetching drivers snapshot for constructor: ")
        }
    }
}
