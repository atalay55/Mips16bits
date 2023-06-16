using Mips16bits.Compiler;
using Mips16bits.DataBase;
using Mips16bits.Entity;
using Mips16bits.Mips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mips16bits
{
    public partial class Form1 : Form
    {
        RegisterDb registerdb;
        ListViewItem item;
        ConverMipsToMachine mipsCon;
        Instruction ins = new Instruction();
        int insMemory = 0x00400000;
        List<Instruction> ınstructions;


        public Form1()
        {
            mipsCon = new ConverMipsToMachine();
            this.ınstructions = new List<Instruction>();
            registerdb = new RegisterDb();
            InitializeComponent();
        }

     
        private void showAllRegister()
        {
            foreach (Register s in registerdb.getRegisters())
            {

                this.item = new ListViewItem(s.name);
                this.item.SubItems.Add(s.number);
                this.item.SubItems.Add(s.value);

                listView1.Items.Add(item);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            showAllRegister();
        }

        public void createInstruction()
        {

            int k = 0;

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {


                string[] variableList = string.Join("", richTextBox1.Lines[i].Split(" ").Skip(1).ToArray()).Split(",");
                
                if (string.IsNullOrEmpty(richTextBox1.Lines[i]))
                {
                    continue;
                }


                else
                {

                    int val = this.insMemory + (k * 4);
                    ins = new Instruction(richTextBox1.Lines[i], val);
                    this.ınstructions.Add(ins);
                   
                    MipsCompiler compiler = new MipsCompiler(mipsCon.converToMac(ins));

                    if (richTextBox1.Lines[i].Contains(":"))
                    {
                        //labes.Add(richTextBox1.Lines[i].Substring(0, richTextBox1.Lines[i].Length - 1), val);

                    }
                    k++;



                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createInstruction();
            this.listView1.Items.Clear();
            showAllRegister();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

        }
    }
}
