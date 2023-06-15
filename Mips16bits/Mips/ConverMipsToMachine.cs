using Mips16bits.DataBase;
using Mips16bits.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mips16bits.Mips
{
    class ConverMipsToMachine
    {
        string functionName;
        MachineCode machineCode;
        ValueTable valueTable;
        RegisterDb registerDb;

        public MachineCode converToMac( Instruction ins )
        {
            machineCode = new MachineCode();
            valueTable = new ValueTable();
            registerDb = new RegisterDb();
            string data = ins.data;
            machineCode.mipsCode = data;
            string[] arraay = data.Split(" ");
            this.functionName = arraay[0];
            machineCode.machineCode = valueTable.getValue(functionName);

            string[] constants = arraay.Skip(1).ToArray();
            string variables = string.Join("", constants);

            string[] variableList = variables.Split(",");

            foreach(string r in variableList)
            {
                machineCode.machineCode= machineCode.machineCode + (registerDb.getRegisterValue(r));

             
            }

            machineCode.machineCode = machineCode.machineCode + "00";

            return machineCode;

        }
    }
}
