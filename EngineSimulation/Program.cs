﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineStats engineStats = new EngineStats();
            Engine engine = new InternalCombustionEngine(engineStats);
            
            Console.WriteLine("Введите температуру окружающей среды: ");
            double ambientTemperature = 20;
            try
            {
                ambientTemperature = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Некорректный ввод, выбрано значение по умолчанию - " + ambientTemperature);
            }
            TestingStand testingStand = new TestingStand(engine, ambientTemperature);
            if (testingStand.EngineOverheated)
            {
                Console.WriteLine("Двигатель перегрелся через " + testingStand.OverheatedTime + " секунд");
            }
            else
            {
                Console.WriteLine("Двигатель не перегрелся");
            }
            Console.WriteLine("Максимальная мощность - " + testingStand.MaxPower + " кВт при скорости коленвала " + testingStand.CrankshaftSpeed + " радиан/сек");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
