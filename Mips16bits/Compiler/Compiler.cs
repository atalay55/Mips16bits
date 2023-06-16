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

                            rd.value = add(rs.value, rt.value);
                           

                            rd.value= int.Parse(rd.value).ToString("x8");
                          
                            registerDb.assignValue(rd, rd.value);
                         
                        
                            //data.machineCode = data.machineCode.Substring(0, 5) + (rs.value+rt.value+ rd.value) + data.machineCode.Substring(5 + 16);
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
        public string add(string num1, string num2)
        {


            int number;
            if (int.TryParse(num2, System.Globalization.NumberStyles.HexNumber, null, out number))
            {
                return (Convert.ToInt64(num1, 16) + (int.Parse(num2, System.Globalization.NumberStyles.AllowLeadingSign))).ToString();

            }
            else if (int.TryParse(num2, System.Globalization.NumberStyles.HexNumber, null, out number) && int.TryParse(num1, System.Globalization.NumberStyles.HexNumber, null, out number))
            {
                return ((int.Parse(num1)) + (int.Parse(num2))).ToString();
            }
            else if (num2.Contains("-"))
            {
                return (Convert.ToInt64(num1, 16) - int.Parse(num2.TrimStart('-'))).ToString();
            }
            else
            {

                return (Convert.ToInt64(num2, 16) + Convert.ToInt64(num1, 16)).ToString();
            }


        }



    }
}
