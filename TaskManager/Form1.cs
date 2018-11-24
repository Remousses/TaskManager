using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Reflection;
using System.Management;
using System.Media;
using System.Security.Principal;
using System.Threading;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        private BindingList<Process> proc_list = new BindingList<Process>();
        private ManagementEventWatcher startProcessEW = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
        private ManagementEventWatcher stopProcessEW = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
        private SoundPlayer SP = new SoundPlayer();
        private PopUp popUp = new PopUp();
        public Form1()
        {
            InitializeComponent();
            initProcessEventHandler();
            initName_DGV();
            initProp_DGV();
        }

        private void initName_DGV()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                proc_list.Add(proc);
            }
            name_dgv.AutoGenerateColumns = false;
            name_dgv.Columns.Clear();
            name_dgv.ColumnCount = 2;
            name_dgv.Columns[0].Name = "Process ID";
            name_dgv.Columns[0].DataPropertyName = "Id";
            name_dgv.Columns[1].Name = "Process Name";
            name_dgv.Columns[1].DataPropertyName = "ProcessName";
            name_dgv.DataSource = proc_list;
        }
        private void initProp_DGV()
        {
            prop_dgv.Hide();
            prop_dgv.AutoGenerateColumns = false;
            prop_dgv.ColumnCount = 2;
            prop_dgv.Columns[0].Name = "Properties";
            prop_dgv.Columns[1].Name = "Values";
            prop_dgv.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (var prop in typeof(Process).GetProperties())
            {
                prop_dgv.Rows.Add(prop.Name, "");
            }
        }
        private void initProcessEventHandler()
        {
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent()) {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            if (isElevated) {
                startProcessEW.EventArrived += new EventArrivedEventHandler(onStartProcessEvent);
                startProcessEW.Start();
                stopProcessEW.EventArrived += new EventArrivedEventHandler(onStopProcessEvent);
                stopProcessEW.Start();
            }
            else
            {
                popUp.Show(this);
                logEvent("Vous n'avez les droits nécessaires");
            }
        }
        private void onStartProcessEvent(object sender, EventArrivedEventArgs e)
        {
            logEvent(e.NewEvent.Properties["ProcessName"].Value.ToString() + "with id : " + e.NewEvent.Properties["ProcessId"].Value.ToString() + " has started");
            addProcessToDGV(Convert.ToInt32(e.NewEvent.Properties["ProcessId"].Value));
            SP.SoundLocation = "../../mp3/light.wav";
            SP.Play();
        }
        private void onStopProcessEvent(object sender, EventArrivedEventArgs e)
        {
            logEvent(e.NewEvent.Properties["ProcessName"].Value.ToString() + "with id : " + e.NewEvent.Properties["ProcessId"].Value.ToString() + " has terminated");
            removeProcessToDGV(Convert.ToInt32(e.NewEvent.Properties["ProcessId"].Value));
            SP.SoundLocation = "../../mp3/long-expected.wav";
            SP.Play();
        }
        private void addProcessToDGV(int id)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(addProcessToDGV), new object[] { id });
                return;
            }
            try
            {
                proc_list.Add(Process.GetProcessById(id));
            }
            catch (Exception)
            {
                Console.WriteLine(id +": This Process exited when you entered the program");
            }   
        }
        private void removeProcessToDGV(int id)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(removeProcessToDGV), new object[] { id });
                return;
            }

            proc_list.Remove(proc_list.Where(i => i.Id == id).FirstOrDefault());
        }
        private int findIndexByName(string str)
        {
            List<string> tmp = new List<string>();
            foreach(DataGridViewRow row in name_dgv.Rows)
            {
                tmp.Add(row.Cells[0].Value.ToString());
            }
            return tmp.IndexOf(str);
        }
        private void listDetails(object sender, EventArgs e)
        {
            if (!prop_dgv.Visible) prop_dgv.Show();
            Process curr_proc = proc_list.Where(i => i.Id == Convert.ToInt32(name_dgv.CurrentRow.Cells[0].Value)).FirstOrDefault();
            var props = typeof(Process).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                try
                {
                    prop_dgv.Rows[i].Cells[1].Value = props[i].GetValue(curr_proc);
                }
                catch (Exception)
                {
                    prop_dgv.Rows[i].Cells[1].Value = "Undefined";
                }
            }
        }
        private void logEvent(string str)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(logEvent), new object[] { str });
                return;
            }
            log_textbox.Text += "[" + DateTime.Now + "] : " + str + "\r\n";
        }

        private void displayGraph(object sender, EventArgs e)
        {
            //initNewBkgWrkr();
            prop_chart.Series.Clear();
            try
            {
                Int32.Parse(prop_dgv.CurrentRow.Cells[1].Value.ToString());
                no_chart_label.Hide();
                prop_chart.Show();
                string series_name = prop_dgv.CurrentRow.Cells[0].Value.ToString();
                prop_chart.Series.Add(series_name);
                prop_chart.Series[series_name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                prop_chart.Series[series_name].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                prop_chart.Series[series_name].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                Console.WriteLine(double.Parse(prop_dgv.CurrentRow.Cells[1].Value.ToString())+" "+DateTime.Now);
                prop_chart.Series[series_name].Points.AddXY(DateTime.Now, double.Parse(prop_dgv.CurrentRow.Cells[1].Value.ToString()));
            }
            catch (FormatException)
            {
                no_chart_label.Show();
                prop_chart.Hide();
            }
        }
        // Travail incomplet 
        private void initNewBkgWrkr()
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.RunWorkerAsync(worker);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i = (int)e.UserState;
            Console.WriteLine("Hello from worker" + i);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker) e.Argument;
            int i = 0;
            while (true)
            {
                Thread.Sleep(1000);
                worker.ReportProgress(i, new object[] { i });
                Console.WriteLine("hello"+ i);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    Console.WriteLine("Closing Worker");
                    return;
                }
            }
        }
    }
}