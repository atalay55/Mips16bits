using Mips16bits.DataBase;
using Mips16bits.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mips16bits.Compiler
{
    public class MipsCompiler
    {

        Dictionary<string, string> parserData;
        ValueTable valueTable = new ValueTable();
        MachineCode data;
        Register rs, rt, rd;
        RegisterDb registerDb = new RegisterDb();
        Validator validator = new Validator();
        Operation operation = new Operation();
        public MipsCompiler(MachineCode data)
        {
            this.data = data;
            parserData = new Dictionary<string, string>();
            string[] arraay = data.mipsCode.Split(" ");
            parserData.Add("type", valueTable.getType(arraay[0]));
            parserData.Add( "oppCode" ,data.machineCode.Substring(0, 5));
            compiler();

        }
        public MipsCompiler() { }


        public void compiler()
        {

            switch (parserData["type"])
            {

                case "R":
                    parserData.Add("rd", data.machineCode.Substring(5, 3));
                    parserData.Add("rt", data.machineCode.Substring(8, 3));
                    parserData.Add("rs", data.machineCode.Substring(11, 3));

                    string funcName = valueTable.getname(parserData["oppCode"]);
                    switch (funcName)
                    {
                        case "add":
                            rs = registerDb.getRegisterWithRegisterValue(parserData["rs"]);
                            rt = registerDb.getRegisterWithRegisterValue(parserData["rt"]);
                            rd = registerDb.getRegisterWithRegisterValue(parserData["rd"]);
                            validator.checkValue(rs.value, rt.value, rd.value);
                            rd.value = operation.add(rs.value, rt.value);
                            rd.value= int.Parse(rd.value).ToString("x8"); 
                            registerDb.assignValue(rd, rd.value);
                            break;

                        case "sub":
                            rs = registerDb.getRegisterWithRegisterValue(parserData["rs"]);
                            rt = registerDb.getRegisterWithRegisterValue(parserData["rt"]);
                            rd = registerDb.getRegisterWithRegisterValue(parserData["rd"]);
                           validator.checkValue(rs.value, rt.value, rd.value);
                            rd.value = operation.delete(rs.value, rt.value);
                            rd.value = int.Parse(rd.value).ToString("x8");
                            registerDb.assignValue(rd, rd.value);
                            break;

                        case "and":
                            rs = registerDb.getRegisterWithRegisterValue(parserData["rs"]);
                            rt = registerDb.getRegisterWithRegisterValue(parserData["rt"]);
                            rd = registerDb.getRegisterWithRegisterValue(parserData["rd"]);
                            validator.checkValue(rs.value, rt.value, rd.value);
                            rd.value = operation.and(rs.value, rt.value);
                            rd.value = int.Parse(rd.value).ToString("x8");
                            registerDb.assignValue(rd, rd.value);
                            break;


                        case "or":
                            rs = registerDb.getRegisterWithRegisterValue(parserData["rs"]);
                            rt = registerDb.getRegisterWithRegisterValue(parserData["rt"]);
                            rd = registerDb.getRegisterWithRegisterValue(parserData["rd"]);
                            validator.checkValue(rs.value, rt.value, rd.value);
                            rd.value = operation.or(rs.value, rt.value);
                            rd.value = int.Parse(rd.value).ToString("x8");
                            registerDb.assignValue(rd, rd.value);
                            break;
                        case "xor":
                            rs = registerDb.getRegisterWithRegisterValue(parserData["rs"]);
                            rt = registerDb.getRegisterWithRegisterValue(parserData["rt"]);
                            rd = registerDb.getRegisterWithRegisterValue(parserData["rd"]);
                            validator.checkValue(rs.value, rt.value, rd.value);
                            rd.value = operation.xor(rs.value, rt.value);
                            rd.value = int.Parse(rd.value).ToString("x8");
                            registerDb.assignValue(rd, rd.value);
                            break;

                        case "sll":
                            rs = registerDb.getRegisterWithRegisterValue(parserData["rs"]);
                            rt = registerDb.getRegisterWithRegisterValue(parserData["rt"]);
                            rd = registerDb.getRegisterWithRegisterValue(parserData["rd"]);
                            validator.checkValue(rs.value, rt.value, rd.value);
                            rd.value = operation.sll(rs.value, rt.value);
                            rd.value = int.Parse(rd.value).ToString("x8");
                            registerDb.assignValue(rd, rd.value);
                            break;

                        case "srl":
                            rs = registerDb.getRegisterWithRegisterValue(parserData["rs"]);
                            rt = registerDb.getRegisterWithRegisterValue(parserData["rt"]);
                            rd = registerDb.getRegisterWithRegisterValue(parserData["rd"]);
                            validator.checkValue(rs.value, rt.value, rd.value);
                            rd.value = operation.srl(rs.value, rt.value);
                            rd.value = int.Parse(rd.value).ToString("x8");
                            registerDb.assignValue(rd, rd.value);
                            break;
                        default:
                            break;
                    }



                    break;



                case "I":
                    parserData.Add("rs", data.machineCode.Substring(5, 3));
                    parserData.Add("rt", data.machineCode.Substring(8, 3));
                    parserData.Add("imm", data.machineCode.Substring(11, 3));

                    break;


                case "J":
                    parserData.Add("imm", data.machineCode.Substring(11, 3));

                    break;

                default:
                    break;
            }

        }

    }
}
