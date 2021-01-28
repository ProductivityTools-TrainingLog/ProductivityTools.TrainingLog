using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper Mapper;

        public TrainingController(ITrainingApplication application, IMapper mapper)
        {
            this.Application = application;
            this.Mapper = mapper;
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
            var r = this.Application.Add(training);
            return r;
        }
    }
}