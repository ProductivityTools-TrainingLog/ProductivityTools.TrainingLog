using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TrainingLog.Application;
using ProductivityTools.TrainingLog.Contract;

namespace ProductivityTools.TrainingLog.Controllers
{
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

        public void Add(Training training)
        {

        }

    }
}