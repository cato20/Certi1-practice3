using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Project3.Controllers
{
    [ApiController]
    [Route("/api/info")]
    public class InfoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public InfoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public String GetInfo()
        {
            string projectTitle = _config.GetSection("ProjectTitle").Value;
            string environmentName = _config.GetSection("EnvironmentName").Value;
            string dbConnection = _config.GetConnectionString("DataSource");
            Console.Out.WriteLine($"We are connecting to db: {dbConnection}");
            return $"The title is {projectTitle} from env : {environmentName}";
        }
    }
}
