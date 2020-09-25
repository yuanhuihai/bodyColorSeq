using System;
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


/**timer1 定时10s，获取面准返修区域车身信息
 * timer2 定时5s，获取颜色编组站过来的车身信息
 * timer3定时1是， 前进方向箭头闪烁
 * timer4定时5分钟，计算换色率
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
            timer1.Start();
            timer2.Start();
            timer3.Start();

            timer4.Start();//计算滞留车
    
            toolStripStatusLabel2.Text = "程序版本 V 1.0.0.37";
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
         
            bigReadyLine.BackColor = Color.HotPink;
            sprayBooth.BackColor = Color.Green;
            stellRepair.BackColor = Color.Goldenrod;
            coatRepair.BackColor = Color.Honeydew;

            //数据库连接打开
            operateDatabase.connOpen();

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



        #region 跳转其他窗口

        private void carToTCone_Click(object sender, EventArgs e)
        {
            bodyToTopCoatOneInfo frm = new bodyToTopCoatOneInfo();
            frm.Show();

        }

        private void repairMenuItem_Click(object sender, EventArgs e)
        {
            repair frmRepair = new repair();
            frmRepair.Show();
        }

        private void ccrate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://10.228.141.253:9080/sc/website/ccrate/index.html");
        }

        #endregion



        #region



        #endregion
        //获取返修区域车身信息
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 6000;
            if (operatePLC.getPlcMX("10.228.141.98", 328, 1, 3))
            {
                RB6075.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6075.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 331, 1, 3))
            {
                RB6080.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6080.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 334, 1, 3))
            {
                RB6090.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6090.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 340, 1, 3))
            {
                RB6095.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6095.BackColor = Color.White;

            }

            if (operatePLC.getPlcMX("10.228.141.98", 343, 1, 3))
            {
                RB6100.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6100.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 346, 1, 3))
            {
                RB6105.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6105.BackColor = Color.White;

            }


            if (operatePLC.getPlcMX("10.228.141.98", 349, 1, 3))
            {
                RB6110.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6110.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 425, 1, 3))
            {
                RB6115.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6115.BackColor = Color.White;

            }
    
            if (operatePLC.getPlcMX("10.228.141.98", 428, 1, 3))
            {
                RB6140.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6140.BackColor = Color.White;
           
            }
            if (operatePLC.getPlcMX("10.228.141.98", 531, 1, 3))
            {
                RB6150.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6150.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 534, 1, 3))
            {
                RB6155.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6155.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 537, 1, 3))
            {
                RB6160.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6160.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 540, 1, 3))
            {
                RB6165.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6165.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 625, 1, 3))
            {
                RB6170.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6170.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 628, 1, 3))
            {
                RB6175.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6175.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 631, 1, 3))
            {
                RB6180.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6180.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 644, 1, 3))
            {
                RB6185.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6185.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 647, 1, 3))
            {
                RB6190.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6190.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 650, 1, 3))
            {
                RB6195.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6195.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 543, 1, 3))
            {
                RB6200.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6200.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 546, 1, 3))
            {
                RB6205.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6205.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 549, 1, 3))
            {
                RB6210.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6210.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 552, 1, 3))
            {
                RB6215.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6215.BackColor = Color.White;

            }
            if (operatePLC.getPlcMX("10.228.141.98", 431, 1, 3))
            {
                RB6220.BackColor = Color.GreenYellow;

            }
            else
            {
                RB6220.BackColor = Color.White;

            }
            //if (operatePLC.getPlcMX("10.228.141.98", 428, 1, 3))
            //{
            //    RB6225.BackColor = Color.GreenYellow;

            //}
            //else
            //{
            //    RB6225.BackColor = Color.White;

            //}
            //if (operatePLC.getPlcMX("10.228.141.98", 428, 1, 3))
            //{
            //    RB6240.BackColor = Color.GreenYellow;

            //}
            //else
            //{
            //    RB6240.BackColor = Color.White;

            //}

        }

        //获取颜色编组站过来的车身信息
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
            mianzhun = operatePLC.readPlcDbwValue("10.228.141.94", 0, 3, 31, 2);//获取大链车身信息

            #endregion
            if (operatePLC.getPlcMX("10.228.141.94", 525, 1, 3))
            {
                RB4370.BackColor = Color.GreenYellow;
                thirty = 1;

                int allTotal = one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen + twenty + twentyone + twentytwo + mianzhun + thirty;
                l4370.Text = colorInfo[allTotal- 1];
                switch (mianzhun)
                {
                    case 8:
                        bigreadyeight.Text = colorInfo[allTotal- 2];
                        bigreadyseven.Text = colorInfo[allTotal - 3];
                        bigreadysix.Text = colorInfo[allTotal - 4];
                        bigreadyfive.Text = colorInfo[allTotal - 5];
                        bigreadyfour.Text = colorInfo[allTotal - 6];
                        bigreadythree.Text = colorInfo[allTotal - 7];
                        bigreadytwo.Text = colorInfo[allTotal - 8];
                        bigreadyone.Text = colorInfo[allTotal - 9];
                        break;
                    case 7:
                        bigreadyeight.Text = colorInfo[allTotal - 2];
                        bigreadyseven.Text = colorInfo[allTotal - 3];
                        bigreadysix.Text = colorInfo[allTotal - 4];
                        bigreadyfive.Text = colorInfo[allTotal - 5];
                        bigreadyfour.Text = colorInfo[allTotal - 6];
                        bigreadythree.Text = colorInfo[allTotal - 7];
                        bigreadytwo.Text = colorInfo[allTotal - 8];
                        bigreadyone.Text = "-";
                        break;
                    case 6:
                        bigreadyeight.Text = colorInfo[allTotal - 2];
                        bigreadyseven.Text = colorInfo[allTotal - 3];
                        bigreadysix.Text = colorInfo[allTotal - 4];
                        bigreadyfive.Text = colorInfo[allTotal - 5];
                        bigreadyfour.Text = colorInfo[allTotal - 6];
                        bigreadythree.Text = colorInfo[allTotal - 7];
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 5:
                        bigreadyeight.Text = colorInfo[allTotal - 2];
                        bigreadyseven.Text = colorInfo[allTotal - 3];
                        bigreadysix.Text = colorInfo[allTotal - 4];
                        bigreadyfive.Text = colorInfo[allTotal - 5];
                        bigreadyfour.Text = colorInfo[allTotal - 6];
                        bigreadythree.Text ="-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 4:
                        bigreadyeight.Text = colorInfo[allTotal - 2];
                        bigreadyseven.Text = colorInfo[allTotal - 3];
                        bigreadysix.Text = colorInfo[allTotal - 4];
                        bigreadyfive.Text = colorInfo[allTotal - 5];
                        bigreadyfour.Text ="-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 3:
                        bigreadyeight.Text = colorInfo[allTotal - 2];
                        bigreadyseven.Text = colorInfo[allTotal - 3];
                        bigreadysix.Text = colorInfo[allTotal - 4];
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 2:
                        bigreadyeight.Text = colorInfo[allTotal - 2];
                        bigreadyseven.Text = colorInfo[allTotal - 3];
                        bigreadysix.Text = "-";
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 1:
                        bigreadyeight.Text = colorInfo[allTotal - 2];
                        bigreadyseven.Text ="-";
                        bigreadysix.Text = "-";
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 0:
                        bigreadyeight.Text ="-";
                        bigreadyseven.Text = "-" ;
                        bigreadysix.Text = "-";
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;

                }
            }
            else
            {
                RB4370.BackColor = Color.White;
                thirty = 0;
                l4370.Text = "-";
                int allTotal = one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen + twenty + twentyone + twentytwo + mianzhun;
                switch (mianzhun)
                {
                    case 8:
                        bigreadyeight.Text = colorInfo[allTotal-1];
                        bigreadyseven.Text = colorInfo[allTotal-2];
                        bigreadysix.Text = colorInfo[allTotal - 3];
                        bigreadyfive.Text = colorInfo[allTotal - 4];
                        bigreadyfour.Text = colorInfo[allTotal - 5];
                        bigreadythree.Text = colorInfo[allTotal - 6];
                        bigreadytwo.Text = colorInfo[allTotal - 7];
                        bigreadyone.Text = colorInfo[allTotal - 8];
                        break;
                    case 7:
                        bigreadyeight.Text = colorInfo[allTotal - 1];
                        bigreadyseven.Text = colorInfo[allTotal - 2];
                        bigreadysix.Text = colorInfo[allTotal - 3];
                        bigreadyfive.Text = colorInfo[allTotal - 4];
                        bigreadyfour.Text = colorInfo[allTotal - 5];
                        bigreadythree.Text = colorInfo[allTotal - 6];
                        bigreadytwo.Text = colorInfo[allTotal - 7];
                        bigreadyone.Text = "-";
                        break;
                    case 6:
                        bigreadyeight.Text = colorInfo[allTotal - 1];
                        bigreadyseven.Text = colorInfo[allTotal - 2];
                        bigreadysix.Text = colorInfo[allTotal - 3];
                        bigreadyfive.Text = colorInfo[allTotal - 4];
                        bigreadyfour.Text = colorInfo[allTotal - 5];
                        bigreadythree.Text = colorInfo[allTotal - 6];
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";

                        break;
                    case 5:
                        bigreadyeight.Text = colorInfo[allTotal - 1];
                        bigreadyseven.Text = colorInfo[allTotal - 2];
                        bigreadysix.Text = colorInfo[allTotal - 3];
                        bigreadyfive.Text = colorInfo[allTotal - 4];
                        bigreadyfour.Text = colorInfo[allTotal - 5];
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";

                        break;
                    case 4:
                        bigreadyeight.Text = colorInfo[allTotal - 1];
                        bigreadyseven.Text = colorInfo[allTotal - 2];
                        bigreadysix.Text = colorInfo[allTotal - 3];
                        bigreadyfive.Text = colorInfo[allTotal - 4];
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";

                        break;
                    case 3:
                        bigreadyeight.Text = colorInfo[allTotal - 1];
                        bigreadyseven.Text = colorInfo[allTotal - 2];
                        bigreadysix.Text = colorInfo[allTotal - 3];
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 2:
                        bigreadyeight.Text = colorInfo[allTotal - 1];
                        bigreadyseven.Text = colorInfo[allTotal - 2];
                        bigreadysix.Text = "-";
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;
                    case 1:
                        bigreadyeight.Text = colorInfo[allTotal - 1];
                        bigreadyseven.Text = "-";
                        bigreadysix.Text = "-";
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";

                        break;
                    case 0:
                        bigreadyeight.Text = "-";
                        bigreadyseven.Text = "-";
                        bigreadysix.Text = "-";
                        bigreadyfive.Text = "-";
                        bigreadyfour.Text = "-";
                        bigreadythree.Text = "-";
                        bigreadytwo.Text = "-";
                        bigreadyone.Text = "-";
                        break;

                }
            }


    
        
           


         
          

            total = one + two + three + four + five + six + seven + eight + nine + ten + eleven + twelve + thirteen + fourteen + fifteen + sixteen + seventeen + eighteen + nineteen + twenty+twentyone+twentytwo+mianzhun+thirty;
            bodyNum.Text = Convert.ToString(total);
            globalData.totalBodyOnLine = total;

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

 

        }


        //车身前进方向箭头闪烁
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 1000;
            toolStripStatusLabel1.Text = DateTime.Now.ToString();

            signalIn++;
            signalOut++;

            if (signalIn % 2 == 0)
            {
                btn_areaone.BackColor = Color.Gainsboro;
                btn_areatwo.BackColor = Color.Gainsboro;
                btn_areathree.BackColor = Color.Gainsboro;
                carToTCone.BackColor = Color.LightGreen;
       
            }
            else
            {
                btn_areaone.BackColor = Color.White;
                btn_areatwo.BackColor = Color.White;
                btn_areathree.BackColor = Color.White;
                carToTCone.BackColor = Color.Wheat;
    
            }

           

       }



        #region  计算滞留车


        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Interval = 60000;


            //获取滞留车数量
            string sql = "select distinct FIS from XIUSHIONEREPAIRBODYINFO";
            int repairCarNum = operateDatabase.OrcGetNums(sql);

                    //定义反修车信息
             string[] repairColorInfo = new string[repairCarNum];
             string[] repairFisInfo = new string[repairCarNum];
             string[] repairSkidInfo = new string[repairCarNum];
             string[] repairBodyInfo = new string[repairCarNum];
            string[] repairRqiInfo = new string[repairCarNum];
            string[] repairShijianInfo = new string[repairCarNum];

            int[] repairTime = new int[repairCarNum];


            //获取滞留车明细
            int j = 0;

           
            OracleDataReader read =operateDatabase.OrcGetRead(sql);
  
            while (read.Read())
            {
         
                repairFisInfo[j] = read["FIS"].ToString();
           
                j++;
            }

       


      

            //判断车身信息是否去了大线，如果去了大线，则记录在返修的表格中的信息删除
            for (int k = 0; k < repairSkidInfo.Length; k++)
            {


                string sqlsearch = "select * from TCONEBODYINFO where FIS='" + repairFisInfo[k] + "'";
            

                OracleDataReader readd = operateDatabase.OrcGetRead(sqlsearch); 
                while (readd.Read())
                {
                    string sqldel = "delete from XIUSHIONEREPAIRBODYINFO where FIS= '" + repairFisInfo[k] + "'";
                 
                    operateDatabase.OrcGetCom(sqldel);
                }
           


            }

            //获取该车身的更多信息
    


            for (int l = 0; l < repairSkidInfo.Length; l++)
            {
                string sqlmore = "select * from XIUSHIONEREPAIRBODYINFO where FIS='" + repairFisInfo[l] + "'and rownum='1' order by XUHAO asc ";

                OracleDataReader readdd = operateDatabase.OrcGetRead(sqlmore);
                while (readdd.Read())
                {
                    repairFisInfo[l] = readdd["FIS"].ToString();
                    repairBodyInfo[l] = readdd["TYPE"].ToString();
                    repairColorInfo[l] = readdd["COLOR"].ToString();
                    repairSkidInfo[l] = readdd["SKID"].ToString();               
                    repairShijianInfo[l] = readdd["SHIJIAN"].ToString();
                    repairTime[l] = stayTime(repairShijianInfo[l]);

         
                }
           

            }

          

            listMoreInfo.Items.Clear();
            listTimeInfo.Items.Clear();

            for(int m = 0; m < repairCarNum; m++)
            {
                listMoreInfo.Items.Add("FIS号码"+repairFisInfo[m] +"--"+"滑橇"+repairSkidInfo[m]+"颜色"+repairColorInfo[m]+"时间"+ repairShijianInfo[m]);
                listTimeInfo.Items.Add("滞留时间" + repairTime[m]);
            }
   

            }


        //计算滞留时间
        public int stayTime(string inTime)
        {

            //数据库读出来时间分解

            string kuhour = inTime.Substring(0, 2);
            string kumin = inTime.Substring(3, 2);
      



            int kulong = Convert.ToInt16(kuhour) * 60 + Convert.ToInt16(kumin);

            //当前时间获取

            int currlong = Convert.ToInt16(DateTime.Now.Hour.ToString()) * 60 + Convert.ToInt16(DateTime.Now.Minute.ToString());


            int  stayMin= currlong - kulong;

            return stayMin;

        }

        #endregion



    }
}
