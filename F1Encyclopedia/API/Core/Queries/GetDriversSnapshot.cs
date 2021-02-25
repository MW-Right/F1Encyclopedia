using F1Encyclopedia.API.Models;
using F1Encyclopedia.Data;
using F1Encyclopedia.Data.Models.Drivers;
using F1Encyclopedia.Data.Models.Results;
using F1Encyclopedia.Validators.Drivers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace F1Encyclopedia.Core.Queries
{
    public class GetDriversSnapshot
    {
        private F1EncyclopediaContext _dbContext;
        private readonly ILogger<GetDriversSnapshot> _logger;
        public List<DriverSnapshot> DriverSnapshots { get; set; }
        public GetDriversSnapshot(F1EncyclopediaContext context, ILogger<GetDriversSnapshot> logger)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<DriverSnapshot>> Handler(CancellationToken cancellationToken, int? constructorId = null)
        {
            var timer = new Stopwatch();
            timer.Start();

            try
            {
                if (constructorId != null)
                {
                    var sumPoints = await (from rr in _dbContext.RaceResults
                                       where rr.ConstructorId == constructorId
                                       group rr by rr.DriverId into g
                                       orderby g.Sum(x => x.Points)
                                       select new { g.Key, Points = g.Sum(x => x.Points) })
                                       .ToListAsync();

                    DriverSnapshots = sumPoints.Select(x => new DriverSnapshot(_dbContext.Drivers.Find(x.Key), x.Points)).ToList();
                }
                else
                {
                    var sumPoints = await (from rr in _dbContext.RaceResults
                            join driver in _dbContext.Drivers
                                on rr.DriverId equals driver.Id
                            group rr by rr.DriverId into g
                            orderby g.Sum(x => x.Points)
                            select new { g.Key, Points = g.Sum(x => x.Points) })
                        .ToListAsync();
                    
                    DriverSnapshots = sumPoints.Select(x => new DriverSnapshot(_dbContext.Drivers.Find(x.Key), x.Points)).ToList();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Unable to retrieve driver snapshot " +
                    $"for constructor: {_dbContext.Constructors.Find(constructorId).Name ?? "null"}");
            }

            timer.Stop();
            _logger.LogInformation($"Completed driver snapshot. ({timer.ElapsedMilliseconds}ms)");

            return DriverSnapshots
                .OrderByDescending(x => x.Points)
                .Take(10).ToList();
        }
    }
}
