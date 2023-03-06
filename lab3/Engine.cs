using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Engine
    {
        private double displacement;
        private double horsePower;
        private string model;

        public Engine(double displacement, double horsePower, string model)
        {
            this.displacement = displacement;
            this.horsePower = horsePower;
            this.model = model;
        }

        public string GetModel()
        {
            return this.model;
        }
        public double GetHppl()
        {
            double hppl = this.horsePower / this.displacement;
            return hppl;
        }
    }
}
