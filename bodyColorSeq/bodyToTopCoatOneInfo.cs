using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using oracleDatabase;
using Oracle.ManagedDataAccess.Client;
namespace bodyColorSeq
{
    public partial class bodyToTopCoatOneInfo : Form
    {
        public bodyToTopCoatOneInfo()
        {
            InitializeComponent();
        }

        oracleDatabaseOperate operateDatabase = new oracleDatabaseOperate();

        public string[] colorInfo = new string[41];
        public string[] fisInfo = new string[41];
        public string[] skidInfo = new string[41];

        private void bodyToTopCoatOneInfo_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 5000;

            int total = globalData.totalBodyOnLine;

            string sql = "select * from (select * from BODYCOLORSEQ order by XUHAO desc ) where rownum<=" + total;


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
                int a = total - 1 - j;
                int b = j + 1;
                listInfo.Items.Add("第" + b + "台车身颜色是" + "------" + colorInfo[a] + "滑橇号" + skidInfo[a]);
            }
        }

    }
}
