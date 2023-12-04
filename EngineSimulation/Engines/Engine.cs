using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineSimulation
{
    class Engine
    {
        public double I { get; protected set; } = 0;
        public double[] M { get; protected set; } = { 0, 0, 0 };
        public double[] V { get; protected set; } = { 0, 0, 0 };
        public double T { get; protected set; } = 0;
        public double Hm { get; protected set; } = 0;
        public double Hv { get; protected set; } = 0;
        public double C { get; protected set; } = 0;
        public double CurrentTemperature { get; protected set; } = 0;
        public double CurrentTime { get; protected set; } = 0;
        public double N { get; protected set; } = 0;

        public bool EngineRun { get; set; } = false;

        public Action<EngineStats> OnEngineUpdate = delegate { };
        public Action OnEngineOverheated = delegate { };

        protected double timeInterval = 0.1;

        public virtual void StartEngine(double ambientTemperature) { }

        public void InitializeEngine(EngineStats engineStats)
        {
            I = engineStats.I;
            M = engineStats.M;
            V = engineStats.V;
            T = engineStats.T;
            Hm = engineStats.Hm;
            Hv = engineStats.Hv;
            C = engineStats.C;
        }
    }

    
}