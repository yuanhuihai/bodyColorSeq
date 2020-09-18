﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using comWithPlc;
using oracleDatabase;
using Oracle.ManagedDataAccess.Client;


/**timer1 定时60s，获取读写站数据
 * 
 * 
 
     */

namespace bodyColorSeq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        getPlcValues operatePLC = new getPlcValues();

        oracleDatabaseOperate operateDatabase = new oracleDatabaseOperate();

        public int total,one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty;


        public string[] colorInfo=new string[41];
        public string[] fisInfo = new string[41];
        public string[] skidInfo = new string[41];

        public int twentyone, twentytwo, twentythree, twentyfour, twentyfive, twentysix, twentyseven, twentyeight, twentynine, thirty;

        public int signalIn=0, signalOut=0;

        public int mianzhun = 0;
        public int totalbeformianzhun = 0;
        public string mianzhunbody;

 
       

        private void Form1_Load(object sender, EventArgs e)
        {
        
            timer2.Start();
            timer3.Start();
            toolStripStatusLabel2.Text = "程序版本 V 1.0.0.16";
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
            
            
    
        }

        #region 程序后台运行



        //窗体关闭时执行，窗体后台运行
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }

        private void hideMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();

        }

        //桌面右小角图标
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//判断鼠标的按键
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Minimized;

                    this.Hide();
                }
                else if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                }
            }
        }


        #endregion

   


        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 5000;

            #region RB3725

            if (operatePLC.getPlcMX("10.228.141.94", 129, 1, 3))
            {
                RB3725.BackColor = Color.GreenYellow;
                one = 1;
                l3725.Text = colorInfo[one-1];
            }
            else
            {
                RB3725.BackColor = Color.White;
                one = 0;
                l3725.Text = "-";
      

            }

            #endregion

            if (operatePLC.getPlcMX("10.228.141.94", 137, 1, 3))
            {
                RB3730.BackColor = Color.GreenYellow;
                two = 1;
                l3730.Text=colorInfo[one + two-1];
               
            }
            else
            {
                RB3730.BackColor = Color.White;
                two = 0;
                l3730.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 141, 1, 3))
            {
                RB3735.BackColor = Color.GreenYellow;
                three = 1;
                l3735.Text = colorInfo[one + two + three-1];
            }
            else
            {
                RB3735.BackColor = Color.White;
                three = 0;
                l3735.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 145, 1, 3))
            {
                RB3740.BackColor = Color.GreenYellow;
                four = 1;
                l3740.Text = colorInfo[one + two + three + four-1];
            }
            else
            {
                RB3740.BackColor = Color.White;
                four = 0;
                l3740.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 149, 1, 3))
            {
                RB3745.BackColor = Color.GreenYellow;
                five = 1;
                l3745.Text = colorInfo[one + two + three + four + five-1];
            }
            else
            {
                RB3745.BackColor = Color.White;
                five = 0;
                l3745.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 153, 1, 3))
            {
                RB3750.BackColor = Color.GreenYellow;
                six = 1;
                l3750.Text = colorInfo[one + two + three + four + five+six-1];
            }
            else
            {
                RB3750.BackColor = Color.White;
                six = 0;
                l3750.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 225, 1, 3))
            {
                RB3755.BackColor = Color.GreenYellow;
                seven = 1;
                l3755.Text = colorInfo[one + two + three + four + five + six+seven-1];
            }
            else
            {
                RB3755.BackColor = Color.White;
                seven = 0;
                l3755.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 229, 1, 3))
            {
                RB3760.BackColor = Color.GreenYellow;
                eight = 1;
                l3760.Text = colorInfo[one + two + three + four + five + six + seven+eight-1];
            }
            else
            {
                RB3760.BackColor = Color.White;
                eight = 0;
                l3760.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 233, 1, 3))
            {
                RB3765.BackColor = Color.GreenYellow;
                nine = 1;
                l3765.Text = colorInfo[one + two + three + four + five + six + seven + eight+nine-1];
            }
            else
            {
                RB3765.BackColor = Color.White;
                nine = 0;
                l3765.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 237, 1, 3))
            {
                RB3770.BackColor = Color.GreenYellow;
                ten = 1;
                l3770.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine+ten-1];
            }
            else
            {
                RB3770.BackColor = Color.White;
                ten = 0;
                l3770.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 241, 1, 3))
            {
                RB3775.BackColor = Color.GreenYellow;
                eleven = 1;
                l3775.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten+eleven-1];
            }
            else
            {
                RB3775.BackColor = Color.White;
                eleven = 0;
                l3775.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94",245, 1, 3))
            {
                RB3780.BackColor = Color.GreenYellow;
                twelve = 1;
                l3780.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve-1];
            }
            else
            {
                RB3780.BackColor = Color.White;
                twelve = 0;
                l3780.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 249, 1, 3))
            {
                RB3785.BackColor = Color.GreenYellow;
                thirteen = 1;
                l3785.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve+thirteen-1];
            }
            else
            {
                RB3785.BackColor = Color.White;
                thirteen = 0;
                l3785.Text = "-";
            }
            if (operatePLC.getPlcMX("10.228.141.94", 253, 1, 3))
            {
                RB3790.BackColor = Color.GreenYellow;
                fourteen = 1;
                l3790.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen+fourteen-1];
            }
            else
            {
                RB3790.BackColor = Color.White;
                fourteen = 0;
                l3790.Text = "-";
            }
            if (operatePLC.getPlcMX("10.228.141.94", 257, 1, 3))
            {
                RB3795.BackColor = Color.GreenYellow;
                fifteen = 1;
                l3795.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen+fifteen-1];
            }
            else
            {
                RB3795.BackColor = Color.White;
                fifteen = 0;
                l3795.Text = "-";
            }
            if (operatePLC.getPlcMX("10.228.141.94", 261, 1, 3))
            {
                RB3800.BackColor = Color.GreenYellow;
                sixteen = 1;
                l3800.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen+sixteen-1];
            }
            else
            {
                RB3800.BackColor = Color.White;
                sixteen = 0;
                l3800.Text = "-";
            }
            if (operatePLC.getPlcMX("10.228.141.94", 325, 1, 3))
            {
                RB3805.BackColor = Color.GreenYellow;
                seventeen = 1;
                l3805.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen+seventeen-1];
            }
            else
            {
                RB3805.BackColor = Color.White;
                seventeen = 0;
                l3805.Text = "-";
            }
            if (operatePLC.getPlcMX("10.228.141.94", 328, 1, 3))
            {
                RB3810.BackColor = Color.GreenYellow;
                eighteen = 1;
                l3810.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen+eighteen-1];
            }
            else
            {
                RB3810.BackColor = Color.White;
                eighteen = 0;
                l3810.Text = "-";
            }
            if (operatePLC.getPlcMX("10.228.141.94", 331, 1, 3))
            {
                RB3815.BackColor = Color.GreenYellow;
                nineteen = 1;
                l3815.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen+nineteen-1];
            }
            else
            {
                RB3815.BackColor = Color.White;
                nineteen = 0;
                l3815.Text = "-";
            }
            if (operatePLC.getPlcMX("10.228.141.94", 334, 1, 3))
            {
                RB3820.BackColor = Color.GreenYellow;
                twenty = 1;
                l3820.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen+twenty-1];
            }
            else
            {
                RB3820.BackColor = Color.White;
                twenty = 0;
                l3820.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 348, 1, 3))
            {
                RB3825.BackColor = Color.GreenYellow;
                twentyone = 1;
                l3825.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen + twenty+twentyone - 1];
            }
            else
            {
                RB3825.BackColor = Color.White;
                twentyone = 0;
                l3825.Text = "-";
            }

            if (operatePLC.getPlcMX("10.228.141.94", 365, 1, 3))
            {
                RB4330.BackColor = Color.GreenYellow;
                twentytwo = 1;
                l4330.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen + twenty + twentyone+twentytwo - 1];
            }
            else
            {
                RB4330.BackColor = Color.White;
                twentytwo = 0;
                l4330.Text = "-";
            }

            #region RB4365--- RB4370
            mianzhun = operatePLC.readPlcDbwValue("10.228.141.94", 0, 3, 31, 2);
            #endregion
            if (operatePLC.getPlcMX("10.228.141.94", 525, 1, 3))
            {
                RB4370.BackColor = Color.GreenYellow;
                thirty = 1;
                l4370.Text = colorInfo[one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen + twenty + twentyone + twentytwo + mianzhun - 1];
            }
            else
            {
                RB4370.BackColor = Color.White;
                thirty = 0;
                l4370.Text = "-";
            }


            if (thirty == 1)
            {
                ltotal.Text = "面漆准备间内有车身----" + mianzhun + "----台,从右到左对应的车身信息为右侧第"+2+"到"+(mianzhun+thirty)+"台车！";
            }
            else
            {
                ltotal.Text = "面漆准备间内有车身----" + mianzhun + "----台,从右到左对应的车身信息为右侧第" + 1 + "到" + mianzhun + "台车！";
            }
        
           


         
          

            total = one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen + twenty+twentyone+twentytwo+mianzhun+thirty;
            bodyNum.Text = Convert.ToString(total);

            string sql = "select * from (select * from BODYCOLORSEQ order by XUHAO desc ) where rownum<="+total;

        
            int i = 0;
       
            OracleConnection conn = new OracleConnection("Data Source=10.228.141.253/ORCL;User Id=WEBKF;Password=WEBKF");
            OracleCommand comm = new OracleCommand(sql, conn);
            conn.Open();
            OracleDataReader read = comm.ExecuteReader();
            while (read.Read())
            {
                colorInfo[i] = read["COLOR"].ToString();
                skidInfo[i] = read["SKID"].ToString();
                fisInfo[i] = read["FIS"].ToString();
                i++;
            }
            conn.Close();

            listInfo.Items.Clear();
            for (int j = 0; j < total; j++)
            {
                int a = total-1-j;
                int b = j + 1;
                listInfo.Items.Add("第"+b+"台车身颜色是"+"------"+colorInfo[a]+"滑橇号"+skidInfo[a]);
            }

        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 1000;
            toolStripStatusLabel1.Text = DateTime.Now.ToString();

            signalIn++;
            signalOut++;

            if (signalIn % 2 == 0)
            {
                btn_areaone.BackColor = Color.Red;
                btn_areatwo.BackColor = Color.Red;
                btn_areathree.BackColor = Color.Red;
                btn_lineonein.BackColor = Color.Red;
                btn_linetwoin.BackColor = Color.Red;
                btn_linethreein.BackColor = Color.Red;
                btn_lineoneout.BackColor = Color.Red;
                btn_linetwoout.BackColor = Color.Red;
                btn_linethreeout.BackColor = Color.Red;
            }
            else
            {
                btn_areaone.BackColor = Color.White;
                btn_areatwo.BackColor = Color.White;
                btn_areathree.BackColor = Color.White;
                btn_lineonein.BackColor = Color.White;
                btn_linetwoin.BackColor = Color.White;
                btn_linethreein.BackColor = Color.White;
                btn_lineoneout.BackColor = Color.White;
                btn_linetwoout.BackColor = Color.White;
                btn_linethreeout.BackColor = Color.White;
            }

       }




  


    }
}
