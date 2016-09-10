using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainerapp.Models.TrainerAppModels
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int UserName { get; set; }

        public string Mobile { get; set; }
        public string  Telephone { get; set; }
      
        public List<Goal> Goals { get; set; }

        public List<ClientPackageSubscriptions> Subscriptions{ get; set; }


    }
}
