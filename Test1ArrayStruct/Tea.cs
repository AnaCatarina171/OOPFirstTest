using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Ana Silva
 * ITPA 2021-10-04
 */

namespace Test1ArrayClass
{
    public class Tea
    {
        private string name;
        private string category;
        private decimal weight;
        private decimal cost;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public decimal Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        public bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
                throw new Exception("The name must be defined.");
            }
            else
            {
                return true;
            }
        }

        public bool IsValidCategory(string category)
        {
            if (category.ToLower() == "white" ||
                category.ToLower() == "green" ||
                category.ToLower() == "oolong" ||
                category.ToLower() == "black" ||
                category.ToLower() == "pu-erh" ||
                category.ToLower() == "herbal")
            {
                return true;
            }
            else
            {
                return false;
                throw new Exception("The category must be defined.");
            }
        }

        public bool IsValidWeight(decimal weight)
        {
            if (weight <= 0)
            {
                return false;
                throw new Exception("The cost must be a number greater than 0.");
            }
            else
            {
                return true;
            }
        }

        public bool IsValidCost(decimal cost)
        {
            if(cost <= 0)
            {
                return false;
                throw new Exception("The cost must be a number greater than 0.");
            }
            else
            {
                return true;
            }
        }

        public bool IsValid()
        {
            if(IsValidName(name) == false || IsValidCategory(category) == false ||
                IsValidWeight(weight) == false || IsValidCost(cost) == false)
            {
                return false;
                throw new Exception("Invalid Order.");
            }
            else
            {
                return true;
            }
        }
    }
}
