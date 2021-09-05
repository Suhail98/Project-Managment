using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GanttChart;
using Microsoft;
namespace databasebebo
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-2VHDSQBM\\SQLEXPRESS;Initial Catalog=PMDataBase;Integrated Security=True");
        TextBox txtLog;
        GanttChart.GanttChart ganttChart1;
        GanttChart.GanttChart ganttChart2;
        GanttChart.GanttChart ganttChart3;
        int projectID;
        public Form3(int projectID)
        {
            InitializeComponent();
            
              SaveImageToolStripMenuItem.Click += new EventHandler(SaveImageToolStripMenuItem_Click);
            this.projectID = projectID;
            txtLog = new TextBox();
            txtLog.Dock = DockStyle.Fill;
            txtLog.Multiline = true;
            txtLog.Enabled = false;
            txtLog.ScrollBars = ScrollBars.Horizontal;
            tableLayoutPanel1.Controls.Add(txtLog, 0, 3);
            //first Gantt Chart
            con.Open();
            ganttChart1 = new GanttChart.GanttChart();
            ganttChart1.AllowChange = false;
            ganttChart1.Dock = DockStyle.Fill;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("select * FROM PROJECTS WHERE PROJECTID = " + projectID + " ");
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
             
            int year = DateTime.Parse(dr["STARTDATE"].ToString()).Year;
            int month = DateTime.Parse(dr["STARTDATE"].ToString()).Month;
            int day = DateTime.Parse(dr["STARTDATE"].ToString()).Day;
            ganttChart1.FromDate = new DateTime(year, month, day, 0, 0, 0);
             year = DateTime.Parse(dr["ENDDATE"].ToString()).Year;
             month = DateTime.Parse(dr["ENDDATE"].ToString()).Month;
             day = DateTime.Parse(dr["ENDDATE"].ToString()).Day;
            ganttChart1.ToDate = new DateTime(year , month, day , 0, 0, 0);

            //ganttChart1.FromDate = DateTime.Parse(dr["STARTDATE"].ToString());
            // ganttChart1.ToDate = DateTime.Parse(dr["ENDDATE"].ToString());

            tableLayoutPanel1.Controls.Add(ganttChart1, 0, 1);

            ganttChart1.MouseMove += new MouseEventHandler(ganttChart1.GanttChart_MouseMove);
            ganttChart1.MouseMove += new MouseEventHandler(GanttChart1_MouseMove);
            ganttChart1.MouseDragged += new MouseEventHandler(ganttChart1.GanttChart_MouseDragged);
            ganttChart1.MouseLeave += new EventHandler(ganttChart1.GanttChart_MouseLeave);
            ganttChart1.ContextMenuStrip = ContextMenuGanttChart1;

            dr.Close();
            List<GanttChart.BarInformation> lst1 = new List<GanttChart.BarInformation>();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("select * from [TASKS] join [PROJECTTASKS] on TASKS.ID = PROJECTTASKS.ID where PROJECTTASKS.projectID = " + projectID + " ");
            dr = cmd.ExecuteReader();
            Color[] colors = new Color[5];
            colors[0] = Color.Aqua;
            colors[1] = Color.AliceBlue;
            colors[2] = Color.Violet;
            colors[3] = Color.Yellow;
            colors[4] = Color.LawnGreen;
            int i = 0;
            int j = 0;
            while (dr.Read())
            {
                lst1.Add(new GanttChart.BarInformation(dr["NAME"].ToString(), DateTime.Parse(dr["STARTDATE"].ToString()),
                DateTime.Parse(dr["ENDDATE"].ToString()), colors[i], Color.Khaki, j++));
                i++;
                i %= 5;
                
            }
            

            foreach (GanttChart.BarInformation bar in lst1)
            {
                ganttChart1.AddChartBar
                (bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
            
            /*
            txtLog = new TextBox();
            txtLog.Dock = DockStyle.Fill;
            txtLog.Multiline = true;
            txtLog.Enabled = false;
            txtLog.ScrollBars = ScrollBars.Horizontal;
            tableLayoutPanel1.Controls.Add(txtLog, 0, 3);

            //first Gantt Chart
            ganttChart1 = new GanttChart.GanttChart();
            ganttChart1.AllowChange = false;
            ganttChart1.Dock = DockStyle.Fill;
            ganttChart1.FromDate = new DateTime(2015, 12, 12, 0, 0, 0);
            ganttChart1.ToDate = new DateTime(2015, 12, 24, 0, 0, 0);
            tableLayoutPanel1.Controls.Add(ganttChart1, 0, 1);

            ganttChart1.MouseMove += new MouseEventHandler(ganttChart1.GanttChart_MouseMove);
            ganttChart1.MouseMove += new MouseEventHandler(GanttChart1_MouseMove);
            ganttChart1.MouseDragged += new MouseEventHandler(ganttChart1.GanttChart_MouseDragged);
            ganttChart1.MouseLeave += new EventHandler(ganttChart1.GanttChart_MouseLeave);
            ganttChart1.ContextMenuStrip = ContextMenuGanttChart1;

            List<BarInformation> lst1 = new List<BarInformation>();

            lst1.Add(new BarInformation("Row 1", new DateTime(2015, 12, 12), new DateTime(2015, 12, 16), Color.Aqua, Color.Khaki, 0));
            lst1.Add(new BarInformation("Row 2", new DateTime(2015, 12, 13), new DateTime(2015, 12, 20), Color.AliceBlue, Color.Khaki, 1));
            lst1.Add(new BarInformation("Row 3", new DateTime(2015, 12, 14), new DateTime(2015, 12, 24), Color.Violet, Color.Khaki, 2));
            lst1.Add(new BarInformation("Row 2", new DateTime(2015, 12, 21), new DateTime(2015, 12, 22, 12, 0, 0), Color.Yellow, Color.Khaki, 1));
            lst1.Add(new BarInformation("Row 1", new DateTime(2015, 12, 17), new DateTime(2015, 12, 24), Color.LawnGreen, Color.Khaki, 0));

            foreach (BarInformation bar in lst1)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
            */
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void GanttChart1_MouseMove(Object sender, MouseEventArgs e)
        {
            List<string> toolTipText = new List<string>();

            if (ganttChart1.MouseOverRowText.Length > 0)
            {
                GanttChart.BarInformation val = (GanttChart.BarInformation)ganttChart1.MouseOverRowValue;
                toolTipText.Add("[b]Date:");
                toolTipText.Add("From ");
                toolTipText.Add(val.FromTime.ToLongDateString() + " - " + val.FromTime.ToString("HH:mm"));
                toolTipText.Add("To ");
                toolTipText.Add(val.ToTime.ToLongDateString() + " - " + val.ToTime.ToString("HH:mm"));
            }
            else
            {
                toolTipText.Add("");
            }

            ganttChart1.ToolTipTextTitle = ganttChart1.MouseOverRowText;
            ganttChart1.ToolTipText = toolTipText;

        }

        private void GanttChart2_MouseMove(Object sender, MouseEventArgs e)
        {
            List<string> toolTipText = new List<string>();

            if (ganttChart2.MouseOverRowText != null && ganttChart2.MouseOverRowText != "" && ganttChart2.MouseOverRowValue != null)
            {
                object obj = ganttChart2.MouseOverRowValue;
                string typ = obj.GetType().ToString();
                if (typ.ToLower().Contains("barinformation"))
                {
                    GanttChart.BarInformation val = (GanttChart.BarInformation)ganttChart2.MouseOverRowValue;
                    toolTipText.Add("[b]Time:");
                    toolTipText.Add("From " + val.FromTime.ToString("HH:mm"));
                    toolTipText.Add("To " + val.ToTime.ToString("HH:mm"));
                }
                else if (typ.ToLower() == "string")
                {
                    toolTipText.Add(ganttChart2.MouseOverRowValue.ToString());
                }
            }
            else
            {
                toolTipText.Add("");
            }

            ganttChart2.ToolTipTextTitle = ganttChart2.MouseOverRowText;
            ganttChart2.ToolTipText = toolTipText;
        }

        private void ganttChart2_BarChanged(object sender, EventArgs e)
        {
            GanttChart.BarInformation b = sender as GanttChart.BarInformation;
            txtLog.Text += String.Format("\r\n{0} has changed", b.RowText);
        }

        private void SaveImageToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            Control chart = null;
            if (menuItem != null)
            {
                ContextMenuStrip calendarMenu = menuItem.Owner as ContextMenuStrip;

                if (calendarMenu != null)
                {
                    chart = calendarMenu.SourceControl;
                }
            }

            SaveImage(chart);
        }

        private void SaveImage(Control control)
        {
            /*
            GanttChart.GanttChart gantt = control as GanttChart.GanttChart;
            string filePath = Microsoft.VisualBasic.Interaction.InputBox("Where to save the file?", "Save image", "C:\\Temp\\GanttChartTester.jpg");
            if (filePath.Length == 0)
                return;
            gantt.SaveImage(filePath);
            Interaction.MsgBox("Picture saved", MsgBoxStyle.Information);*/
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ContextMenuGanttChart1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void SaveImageToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
