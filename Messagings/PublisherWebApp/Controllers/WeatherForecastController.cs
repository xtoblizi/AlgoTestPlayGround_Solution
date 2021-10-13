using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PublisherWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IBus bus;

        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBus bus)
        {
            _logger = logger;
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();

            for (long i = 0; i < 100000000 ; i++)
            {
                var message = new BrokerMessagesModel.Lib.Message
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = $" {i} =>  This is the message sent as at the time's millisecond: {DateTime.Now.Millisecond}",
                    DateCreated = DateTime.Now
                };


                await bus.SendReceive.SendAsync($"{nameof(WeatherForecast)}", message).ContinueWith(async k => { await PostPublishAction(k, message); });
            }
           

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
       
 
        private async Task PostPublishAction(Task task,BrokerMessagesModel.Lib.Message message)
        {
            if (task.IsCompleted)
            {
                Console.WriteLine("Task {0} is completed", task.Id.ToString());
            }
            if (task.IsFaulted)
            {
                Console.WriteLine($"Task was flagged as faulted. The task had message details of Id: {message.Id}, Content: {message.Text}, DateTime: {message.DateCreated}");
            }
        }
    }
}
