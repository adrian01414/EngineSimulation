using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineSimulation
{
    class InternalCombustionEngine : Engine
    {
        public InternalCombustionEngine(EngineStats engineStats)
        {
            InitializeEngine(engineStats);
        }

        public override void StartEngine(double ambientTemperature)
        {
            EngineRun = true;
            
            int i = 0;
            double currentV = V[0];
            double currentM = M[0];
            CurrentTemperature = ambientTemperature;
            double Vh;
            double Vc;

            double a = M[0] / I;

            while (EngineRun)
            {
                CurrentTime += timeInterval;

                if (i < V.Length - 1)
                {
                    if (currentV >= V[i + 1])
                    {
                        i++;
                    }
                }
                
                currentM += ((M[i + 1] - M[i]) / (V[i + 1] - V[i])) * a;
                a = currentM / I;
                currentV += a;
                
                Vh = (M[i] * Hm + Math.Pow(currentV, 2) * Hv) * timeInterval;
                Vc = (C * (ambientTemperature - CurrentTemperature)) * timeInterval;

                CurrentTemperature += Vh + Vc;
                if (CurrentTemperature >= T)
                {
                    OnEngineOverheated?.Invoke();
                }

                N = currentM * currentV / 1000;

                EngineStats engineStats = new EngineStats();
                engineStats.N = N;
                engineStats.CurrentV = currentV;
                engineStats.CurrentTemperature = CurrentTemperature;
                OnEngineUpdate?.Invoke(engineStats);
            }
        }
    }
}
