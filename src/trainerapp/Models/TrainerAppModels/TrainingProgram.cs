using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainerapp.Models.TrainerAppModels
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public string  TrainingProgramName { get; set; }
        public List<Exercise> Exercises { get; set; }
                
    }
}
