﻿using AkkaMjrTwo.StatisticsEngine.Attributes;
using AkkaMjrTwo.StatisticsEngine.ReadModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaMjrTwo.StatisticsEngine.Controllers
{
    [Route("api/statistics")]
    [ApiController]
    public class StatisitcsController : ControllerBase
    {

        [RequestLoggingActionFilter]
        [Route("game")]
        [HttpGet]
        public async Task<ActionResult> Create(string gameId)
        {
            using (var db = new GameStatisticsContext())
            {
                var statistics = await db.Statistics.Where(s => s.GameId.Equals(gameId)).ToListAsync();
                return Ok(statistics);
            }
        }

        [RequestLoggingActionFilter]
        [Route("all")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            using (var db = new GameStatisticsContext())
            {
                var statistics = await db.Statistics.ToListAsync();
                return Ok(statistics);
            }
        }
    }
}
