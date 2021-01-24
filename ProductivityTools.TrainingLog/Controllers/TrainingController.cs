using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TrainingLog.Application;
using ProductivityTools.TrainingLog.Contract;
using ProductivityTools.TrainingLog.Objects;

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
        public string Add(Contract.Training training)
        {
            TrainingRaw trainingRaw = new TrainingRaw();
            var r = Application.AddRaw(trainingRaw);
            return r;
        }

    }
}