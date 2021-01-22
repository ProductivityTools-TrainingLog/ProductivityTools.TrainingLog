using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TrainingLog.Application;
using ProductivityTools.TrainingLog.Contract;

namespace ProductivityTools.TrainingLog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : Controller
    {
        private readonly ITrainingApplication Application;

        public TrainingController(ITrainingApplication application)
        {
            this.Application = application;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Date")]
        public string Date()
        {
            return DateTime.Now.ToString();
        }

        [HttpPost]
        [Route("Add")]
        public void Add(Training training)
        {
            Application.AddRaw(training);
        }

    }
}