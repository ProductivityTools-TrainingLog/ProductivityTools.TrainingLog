using ProductivityTools.TrainingLog.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TrainingLog.Application.Etl
{
    public class EndomondoSport : IRule
    {
        public void Process(Training trainingRaw, Training training)
        {
           // if (trainingRaw.Application == "Endomondo")
           // {
               // training.Sport = GetSport(training.Sport);

                //if (trainingRaw.Name == "#Stretching")
                //{
                //    training.Sport = TrainingType.Stretching;
                //}
                //if (trainingRaw.Sport == "PILATES")
                //{
                //    training.Sport = TrainingType.Stretching;
                //}

                //if (trainingRaw.Name == "-bilard")
                //{
                //    training.Sport = TrainingType.Bilard;
                //    training.Name = null;
                //}

                //if (trainingRaw.Name == "Sanki")
                //{
                //    training.Sport = TrainingType.Sleed;
                //    training.Name = null;
                //}

                //if (trainingRaw.Name?.Trim() == "#Stretching" || trainingRaw.Name?.Trim()== "Stretching")
                //{
                //    training.Sport = TrainingType.Stretching;
                //    training.Name = null;
                //}

                //if (trainingRaw.Name == "Zumba")
                //{
                //    training.Sport = TrainingType.Zumba;
                //    training.Name = null;
                //}

                //if (trainingRaw.Name == "HulaHop")
                //{
                //    training.Sport = TrainingType.HulaHop;
                //    training.Name = null;
                //}

                //List<string> plaskiBrzuchName = new List<string> { "#Plaski Brzuch", "#Plaski Brzuch", "Plaski Brzuch", "plaski brzuch", "brzuch" };
                //if (plaskiBrzuchName.Contains(trainingRaw.Name?.Trim()))
                //{
                //    training.Name = "Plaski brzuch";
                //}

                //if (trainingRaw.Name?.Trim()== "-")
                //{
                //    training.Name = null;
                //}

                //if (trainingRaw.Name?.Trim() == "r"
                //    || trainingRaw.Name?.Trim() == "test"
                //    || trainingRaw.Name?.Trim() == "krzaki"
                //    || trainingRaw.Name?.Trim() == "Biegowki1")
                //{
                //    training.Name = null;
                //}

           // }
        }

       
    }
}
