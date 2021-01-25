using ProductivityTools.TrainingLog.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TrainingLog.Application.Etl
{
    public class EndomondoSport : IRule
    {
        public void Process(TrainingRaw trainingRaw, Training training)
        {
            if (trainingRaw.Application == "Endomndo")
            {
                if (trainingRaw.Name == "#Stretching")
                {
                    training.Sport = "Stretching";
                }
                if(trainingRaw.Sport=="PILATES")
                {
                    training.Sport = "Stretching";
                }

                if (trainingRaw.Name == "-bilard")
                {
                    training.Sport = "Bilard";
                }
            }
        }
    }
}
