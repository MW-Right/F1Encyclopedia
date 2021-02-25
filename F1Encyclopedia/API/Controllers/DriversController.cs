using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using F1Encyclopedia.Data;
using System.Threading.Tasks;
using F1Encyclopedia.Data.Models.Drivers;
using F1Encyclopedia.Data.Models.ConstructorTeams;
using F1Encyclopedia.API.Models;
using System.Collections.Generic;
using F1Encyclopedia.Core.Queries;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace F1Encyclopedia.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriversController : Controller
    {
        private readonly ILogger<DriversController> _logger;
        private F1EncyclopediaContext _dbContext;
        private LoggerFactory loggerFactory;

        public DriversController(ILogger<DriversController> logger, F1EncyclopediaContext dbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            loggerFactory = new LoggerFactory();
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Finds and returns top 10 drivers.
        /// </summary>
        /// <param name="constructorId">
        ///     The constructor identifier to filter for.
        /// </param>
        /// <param name="cancellationToken">
        ///     A <see cref="CancellationToken"/> to listen to.
        /// </param>"
        [HttpGet]
        [Route("snapshot")]
        public async Task<List<DriverSnapshot>> GetDriversSnapshot([FromQuery] int? constructorId = null, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"GetDriversSnapshot with constructor {constructorId}");
            var query = new GetDriversSnapshot(_dbContext, loggerFactory.CreateLogger<GetDriversSnapshot>());
            return await query.Handler(cancellationToken, constructorId);
        }
    }
}
