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
            if (trainingRaw.Application == "Endomondo")
            {
                training.Sport = GetSport(trainingRaw.Sport);

                if (trainingRaw.Name == "#Stretching")
                {
                    training.Sport= TrainingType.Stretching;
                }
                if(trainingRaw.Sport=="PILATES")
                {
                    training.Sport = TrainingType.Stretching;
                }

                if (trainingRaw.Name == "-bilard")
                {
                    training.Sport = TrainingType.Bilard;
                    training.Name = null;
                }

                if (trainingRaw.Name == "Sanki")
                {
                    training.Sport = TrainingType.Sleed;
                    training.Name = null;
                }

                if (trainingRaw.Name == "Zumba")
                {
                    training.Sport = TrainingType.Zumba;
                    training.Name = null;
                }

                if (trainingRaw.Name == "HulaHop")
                {
                    training.Sport = TrainingType.HulaHop;
                    training.Name = null;
                }

                List<string> plaskiBrzuchName = new List<string> { "#Plaski Brzuch", "Plaski Brzuch", "plaski brzuch", "brzuch" };
                if (plaskiBrzuchName.Contains(trainingRaw.Name))
                {
                    training.Name = "Plaski brzuch";
                }

                if (trainingRaw.Name?.Trim()== "-")
                {
                    training.Name = null;
                }
            }
        }

        private TrainingType GetSport(string sport)
        {
            Dictionary<string, TrainingType> mapper = new Dictionary<string, TrainingType>();
            mapper.Add("ROWING_INDOOR",TrainingType.Rowing);
            mapper.Add("BADMINTON", TrainingType.Badminton);
            mapper.Add("ROLLER_SKIING", TrainingType.RollerSkating);
            mapper.Add("CYCLING_SPORT", TrainingType.Cycling);
            mapper.Add("STAIR_CLIMBING", TrainingType.StairClimbing);
            mapper.Add("MOUNTAIN_BIKING", TrainingType.MountainBiking);
            mapper.Add("ICE_SKATING", TrainingType.IceSkating);
            mapper.Add("YOGA", TrainingType.Yoga);
            mapper.Add("KAYAKING", TrainingType.Kayaking);
            mapper.Add("OTHER", TrainingType.NotKnown);
            mapper.Add("WALKING", TrainingType.Walking);
            mapper.Add("FITNESS_WALKING", TrainingType.NordicWalking);
            mapper.Add("ROLLER_SKATING", TrainingType.RollerSkating);
            mapper.Add("DANCING", TrainingType.Dancing);
            mapper.Add("GYMNASTICS", TrainingType.Fitness);
            mapper.Add("ORIENTEERING", TrainingType.Orienteering);
            mapper.Add("SQUASH", TrainingType.Squash);
            mapper.Add("HIKING", TrainingType.Hiking);
            mapper.Add("TABLE_TENNIS", TrainingType.TableTennis);
            mapper.Add("SKIING_CROSS_COUNTRY", TrainingType.CrossCountrySkiing);
            mapper.Add("MARTIAL_ARTS", TrainingType.MuayThai);
            mapper.Add("SWIMMING", TrainingType.Swimming);
            mapper.Add("SOCCER", TrainingType.Soccer);
            mapper.Add("ROWING", TrainingType.Rowing);
            mapper.Add("SKIING_DOWNHILL", TrainingType.SkiingDownhill);
            mapper.Add("CROSS_TRAINING", TrainingType.CrossTraining);
            mapper.Add("RIDING", TrainingType.Riding);
            mapper.Add("RUNNING", TrainingType.Running);
            mapper.Add("CLIMBING", TrainingType.Climbing);
            mapper.Add("CYCLING_TRANSPORTATION", TrainingType.Cycling);
            mapper.Add("WEIGHT_TRAINING", TrainingType.WeightTraining);
            mapper.Add("SKATEBOARDING", TrainingType.Skateboarding); 
            mapper.Add("TENNIS", TrainingType.Tennis);
            mapper.Add("AEROBICS", TrainingType.Fitness);
            mapper.Add("ROPE_JUMPING", TrainingType.RopeJumping);
            mapper.Add("RUNNING_TRAIL", TrainingType.TrailRunning);
            mapper.Add("TREADMILL_RUNNING", TrainingType.TradmillRunning);
            mapper.Add("PILATES", TrainingType.Pilates);

            var r = mapper[sport];
            return r;


        }
    }
}
