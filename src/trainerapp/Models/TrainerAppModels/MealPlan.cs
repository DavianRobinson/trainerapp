using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainerapp.Models.TrainerAppModels
{
    public class MealPlan
    {
        public int MealPlanId { get; set; }
        public string MealPlanName { get; set; }
        public Dictionary<string,Recipes> Meals { get; set; }
    }
}
