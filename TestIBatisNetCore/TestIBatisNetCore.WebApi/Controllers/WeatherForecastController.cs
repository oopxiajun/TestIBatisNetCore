using Microsoft.AspNetCore.Mvc;

namespace TestIBatisNetCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("GetPerson")]
        public Object GetPerson(string name)
        {
            Business.Person person = new Business.Person(new BP.Business.BusinessRuleContext("11"));
            var list = person.GetAllPersonList(new Domain.Criteriaes.PersonCriteria() { Name = name });
            return list;
        }

        [HttpGet("GetPersonPage")]
        public Object GetPersonPaage(string name)
        {
            Business.Person person = new Business.Person(new BP.Business.BusinessRuleContext("11"));
            var criteria = new Domain.Criteriaes.PersonCriteria();
            criteria.InitFrom(1, 10);
            var list = person.QueryPaging(criteria);
            return list;
        }
    }
}