using ProductivityTools.TrainingLog.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TrainingLog.Application.Etl
{
    interface IRule
    {
        void Process(TrainingRaw trainingRaw, Training training);
    }
}
