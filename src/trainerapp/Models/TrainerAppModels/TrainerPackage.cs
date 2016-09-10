using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainerapp.Models.TrainerAppModels
{
    public class TrainerPackage
    {
        public int TrainerPackageId { get; set; }

        public string TrainerPackageName { get; set; }

        public string Description { get; set; }

        public string Period { get; set; }

        public int MinimumContractPeriod { get; set; }
        public double Price { get; set; }

      

    }
}
