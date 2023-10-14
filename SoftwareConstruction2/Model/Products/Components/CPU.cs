﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products.Components
{
    [Serializable]
    public class CPU : Components
    {
        public double Frequency { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public override string GetDescription()
        {
            return base.GetDescription() + $"\nFrequency: {Frequency}\nCores amount: {Cores}\nThread amount: {Threads}";
        }
        public override List<string> GetDescriptionInList()
        { 
            var x = base.GetDescriptionInList();
            x.AddRange(new List<string>() { Frequency.ToString(), Cores.ToString(), Threads.ToString() });
            return x ;
        }
        public CPU(int id, string name, double price, string man, double fr, int cores, int threads) : base(id, name, price, man) 
        {
            Frequency = fr;
            Cores = cores;
            Threads = threads;
        }
    }
}
