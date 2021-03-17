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

        /// <summary>
        /// Adds new training. If training exists doesn't do anything. It checks if training exist comparing start date, end date and sport. Two sports with the same start date, end date and and with the same type cannot exists
        /// </summary>
        /// <param name="training"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public Training Add(Contract.Training training)
        {
            var r = this.Application.Add(training);
            return r;
        }

        [HttpPost]
        [Route("UpdateExternalTrainingId")]
        public void UpdateExternalId(int trainingId, string externalSystemName, string externalTrainingId)
        {
            this.Application.UpdateExternalId(trainingId, externalSystemName, externalTrainingId);
        }

        [HttpPost]
        [Route("List")]
        public List<Training> List(object account)
        {
            var result=this.Application.List(account.ToString());
            return result;
        }

        [HttpPost]
        [Route("Get")]
        public Training Get(int trainingId)
        {
            var result = this.Application.Get(trainingId);
            return result;
        }
    }
}