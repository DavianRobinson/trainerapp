using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainerapp.Models.TrainerAppModels
{
    public class PersonalTrainer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public List<ClientPackageSubscriptions> Clients { get; set; }

    }
}
