using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainerapp.Models.TrainerAppModels
{
    public class ClientPackageSubscriptions
    {
        public int ClientPackageSubscriptionsId { get; set; }
        public int PersonalTrainerId { get; set; }
        public int ClientId { get; set; }
        public int TrainingPackageId { get; set; }

    }
}
