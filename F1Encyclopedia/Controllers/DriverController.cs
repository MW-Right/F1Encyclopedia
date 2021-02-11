using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using F1Encyclopedia.Data;

namespace F1Encyclopedia.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriverController : Controller
    {
        private readonly ILogger<DriverController> logger;
        private F1EncyclopediaContext dbContext;

        public DriverController(ILogger<DriverController> _logger, F1EncyclopediaContext _dbContext)
        {
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
            dbContext = _dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
