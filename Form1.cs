using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UpdateFBKeyword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FBService.getFilterKey();
            int KeywordID = -1; //關鍵字ID
            var cmd = new SqlCommand();
            cmd.CommandText = @"
                select * from FB_message where KWID=-1
            ";
            DataTable dt = Persister.Execute(cmd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["id"].ToString();
                string msg = dt.Rows[i]["Message"].ToString();
                KeywordID = FBService.matchTitle(msg);
                FBService.updFB(KeywordID,id);
            }
        }
    }
}
