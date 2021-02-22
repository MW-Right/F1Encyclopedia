using F1Encyclopedia.Data;
using F1Encyclopedia.Data.Models.Drivers;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace F1Encyclopedia.Core.Queries
{
    public class GetDriversSnapshot
    {
        private F1EncyclopediaContext _dbContext;
        private ILogger<GetDriversSnapshot> _logger;
        public List<Driver> Drivers;
        public GetDriversSnapshot(F1EncyclopediaContext context, ILogger<GetDriversSnapshot> logger)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void GetDriversSnapshotQuery(CancellationToken cancellationToken = default, int ? constructorId = null)
        {
            //var timer = new Stopwatch();

            //timer.Start();
            //if (constructorId != null)
            //{
            //    return _dbContext.Drivers
            //        .Where(x => x.Teams.Contains(c => c.Id == constructorId));
            //}
                
            //timer.Stop();
            //_logger.LogInformation($"Requested driver snapshot. ({timer.ElapsedMilliseconds}ms)");
        }
    }
}
