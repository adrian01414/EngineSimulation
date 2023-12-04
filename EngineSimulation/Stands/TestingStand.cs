using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineSimulation
{
    class TestingStand
    {
        public double OverheatedTime { get; private set; } = 0;
        public double MaxPower { get; private set; } = 0;
        public double CrankshaftSpeed { get; private set; } = 0;

        public bool EngineOverheated = false;

        private Engine testingEngine = null;

        public TestingStand(Engine engine, double ambientTemperature)
        {
            testingEngine = engine;
            OverheatingTest(ambientTemperature);
            MaxPowerTest(ambientTemperature);
        }
        
        public void OverheatingTest(double ambientTemperature)
        {
            testingEngine.OnEngineOverheated += StopEngine;
            testingEngine.OnEngineUpdate += TemperatureTracker;

            tempTemperature = ambientTemperature;
            testingEngine.StartEngine(ambientTemperature);
            OverheatedTime = testingEngine.CurrentTime;

            testingEngine.OnEngineOverheated -= StopEngine;
        }

        public void MaxPowerTest(double ambientTemperature)
        {
            testingEngine.OnEngineUpdate += PowerTracker;

            testingEngine.StartEngine(ambientTemperature);

            testingEngine.OnEngineUpdate -= PowerTracker;
        }

        double tempTemperature;
        private void TemperatureTracker(EngineStats engineStats)
        {
            double temperatureEps = 1E-10;
            if(Math.Abs(tempTemperature - engineStats.CurrentTemperature) < temperatureEps)
            {
                EngineOverheated = false;
                testingEngine.EngineRun = false;
            }
            tempTemperature = engineStats.CurrentTemperature;
        }

        private double tempV = -1;
        private double vEps = 0.01;
        private void PowerTracker(EngineStats engineStats)
        {
            if(engineStats.N > MaxPower)
            {
                MaxPower = engineStats.N;
                CrankshaftSpeed = engineStats.CurrentV;
            }
            if(Math.Abs(engineStats.CurrentV - tempV) < vEps)
            {
                testingEngine.EngineRun = false;
            }
            tempV = engineStats.CurrentV;
        }

        private void StopEngine()
        {
            EngineOverheated = true;
            testingEngine.EngineRun = false;
        }
    }
}
