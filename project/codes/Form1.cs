using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    public partial class Scheduling : Form
    {
        public Scheduling()
        {
            InitializeComponent();
        }

    int n;
    process[] x;
    int flag = 0;
    public void button1_Click(object sender, EventArgs e)
    {
        n = Convert.ToInt32(textBox1.Text); //number of processes
        x = new process[n];

        for (int i = 0; i < n; i++)
        {

            x[i] = new process(i);
        }      //contstructing array

        dataGridView1.Rows.Add(n);
        for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
        {
          dataGridView1.Rows[rows].Cells[0].Value=x[rows].name;

        }   //to display the name of processess in the table

      
        if (comboBox1.SelectedItem.ToString() == "Non-preemptive priority")
        {

            dataGridView1.Columns[3].Visible=true;
            
        }
        if (comboBox1.SelectedItem.ToString() == "Preemptive priority")
        {
            dataGridView1.Columns[3].Visible = true;
        }
        if (comboBox1.SelectedItem.ToString() == "Round robin")
        {
            label2.Visible = true;
            textBox2.Visible = true;
        }


        dataGridView1.Visible = true;
        button2.Visible = true;
           
      }
      
    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
        int[] value = new int[n];
        for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
        {

            value[rows] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[1].Value);


        }
        for (int i = 0; i < n; i++)
        {
            x[i].arrival_time = value[i];

        }
        for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
        {
            value[rows] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[2].Value);

        }
        for (int i = 0; i < n; i++)
        {
            x[i].burst_time = value[i];

        }

        if (dataGridView1.Columns[3].Visible == true)
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                value[rows] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[3].Value);

            }
            for (int i = 0; i < n; i++)
            {
                x[i].priority_input = value[i];

            }
        }

        tableLayoutPanel1.AutoSize = true;

        if (comboBox1.SelectedItem.ToString() == "First come first served")
        {
            label3.Text = "Average waiting time equals " + fcfs.fcfs_function(x, n, this);

        }
        if (comboBox1.SelectedItem.ToString() == "Non-preemptive sjf")
        {
            label3.Text = "Average waiting time equals " + sjf.nonpreemptive(x, n, this);

        }
        if (comboBox1.SelectedItem.ToString() == "Preemptive sjf")
        {
            label3.Text = "Average waiting time equals " + sjf.preemptive(x, n, this);

        }
        if (comboBox1.SelectedItem.ToString() == "Non-preemptive priority")
        {
            label3.Text = "Average waiting time equals " + periority.nonpreemptive(x, n, this);

        }
        if (comboBox1.SelectedItem.ToString() == "Preemptive priority")
        {
            label3.Text = "Average waiting time equals " + periority.preemptive(x, n, this);

        }
        if (comboBox1.SelectedItem.ToString() == "Round robin")
        {
            if (textBox2.Text != null)
            {
                int q = Convert.ToInt32(textBox2.Text);
                label3.Text = "Average waiting time equals " + roundrobin.func(x, n, q, this);
            }
        }
        //tableLayoutPanel1.Visible = true;
        label3.Visible = true;
        label3.Font=new Font("Arial", 14, FontStyle.Bold);
    }

   public void add_label(string name,int number,int time)
    {
        if(number==0)
        {
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle() { Width = 40, SizeType = SizeType.Absolute });

        }
        Label process = new Label();
        process.Text = name;
        process.Padding = new Padding(3, 6, 0, 0);
        process.Margin = new Padding(0, 0, 0, 0);
        process.Dock = DockStyle.Fill;
        tableLayoutPanel1.ColumnCount = number+1;
        tableLayoutPanel1.Controls.Add(process, number, 0);
        Random x = new Random();
        tableLayoutPanel1.GetControlFromPosition(number, 0).BackColor = Color.FromArgb(x.Next(0,255) ,x.Next(0, 255), x.Next(0, 255));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle() { Width = 40, SizeType = SizeType.Absolute });
        Point locationOnForm = tableLayoutPanel1.GetControlFromPosition(number,0).FindForm().PointToClient(
        tableLayoutPanel1.GetControlFromPosition(number, 0).Parent.PointToScreen(tableLayoutPanel1.GetControlFromPosition(number, 0).Location));
        Label z = new Label();
        z.Text = time.ToString(); ;
        z.AutoSize = true;
        z.Location = new Point((locationOnForm.X)-5,locationOnForm.Y+33);
        this.Controls.Add(z);

    }

    public void add_last_time(int number,int time)
    {
        Label z = new Label();
        z.Text = time.ToString(); ;
        z.AutoSize = true;
        Point locationOnForm = tableLayoutPanel1.GetControlFromPosition(number, 0).FindForm().PointToClient(tableLayoutPanel1.GetControlFromPosition(number, 0).Parent.PointToScreen(tableLayoutPanel1.GetControlFromPosition(number, 0).Location));  //getting the location of the last one
        z.Location = new Point((locationOnForm.X) +32, locationOnForm.Y + 33);
        this.Controls.Add(z);

    }

    
}

