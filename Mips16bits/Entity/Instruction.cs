using System;
using System.Collections.Generic;
using System.Text;

namespace Mips16bits.Entity
{
    public class Instruction
    {
        public Instruction(string data, int insMemory)
        {
            this.data = data;
            this.insMemory = insMemory;
        }
        public Instruction() { }
        public string data { get; set; }
        public int insMemory { get; set; }

    }
}
