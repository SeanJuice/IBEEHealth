using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAssignment2._0
{
    public class MealPlan
    {
        private int MealPlanID;
        private string MealPlanName;
        private DateTime Duration;

        public int MealPlanID1
        {
            get
            {
                return MealPlanID;
            }

            set
            {
                MealPlanID = value;
            }
        }

        public string MealPlanName1
        {
            get
            {
                return MealPlanName;
            }

            set
            {
                MealPlanName = value;
            }
        }

        public DateTime Duration1
        {
            get
            {
                return Duration;
            }

            set
            {
                Duration = value;
            }
        }
    }
}