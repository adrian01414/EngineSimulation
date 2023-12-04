using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EngineSimulation
{
    class EngineStats
    {
        public double I { get; protected set; } = 10;
        public double[] M { get; protected set; } = { 20, 75, 100, 105, 75, 0 };
        public double[] V { get; protected set; } = { 0, 75, 150, 200, 250, 300 };
        public double T { get; protected set; } = 110;
        public double Hm { get; protected set; } = 0.01;
        public double Hv { get; protected set; } = 0.0001;
        public double C { get; protected set; } = 0.1;

        public double CurrentV { get; set; }
        public double CurrentTemperature { get; set; }
        public double N { get; set; }
    }
}
