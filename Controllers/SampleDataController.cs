//  =============================================================================
//  <copyright file="SampleDataController.cs" company="Help Us!">
//      Copyright (c) Help Us! Chavornay SWITZERLAND.
//  </copyright>
//  ============================================================================
//  
//  Workfile: SampleDataController.cs
//  
//  PROJECT  : VueJsTest
//  CREATION : 13.01.2018
//  AUTHOR   : Grégoire Wulliamoz - grego
// 
//  ----------------------------------------------------------------------------

namespace VueJsTest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
        }
    }
}