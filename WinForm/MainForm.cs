using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitPicCtr();
            InitTimer();
            InitProgressBar();
            InitCheckListBox();
            InitTreeView();
            InitWebBrowser();
            InitCheckTestToolStrip();
        }
        private void InitCheckTestToolStrip()
        {
            this.ToolStripButtonEx1.CheckOnClick = true;
            this.ToolStripButtonEx2.CheckOnClick = true;
            this.ToolStripButtonEx3.CheckOnClick = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(this.textBox1.Text);
            this.webBrowser1.Refresh(WebBrowserRefreshOption.Normal);
        }
        private void InitWebBrowser()
        {
            this.webBrowser1.AllowNavigation = true;
        }
        private void InitTreeView()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;
            for (int index=0;index<10;index++)
            {
                var node=this.treeView1.Nodes.Add("Main"+index.ToString());
                node.ImageIndex = index;
                for(int sub=0;sub<10;sub++)
                {
                    var subnode = node.Nodes.Add("sub" + sub.ToString());
                    subnode.ImageIndex = sub;
                }
            }
        }
        private void InitCheckListBox()
        {
            this.checkedListBox1.Items.Clear();
            this.checkedListBox1.Items.Add("你做的太好了");
            this.checkedListBox1.Items.Add("你做的很一般");
            this.checkedListBox1.Items.Add("你做的烂透了");
            this.checkedListBox1.SelectedIndex = 0;
            this.checkedListBox1.SetItemChecked(0, true);
            this.checkedListBox1.SelectedIndexChanged += CheckedListBox1_SelectedIndexChanged;
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selindex = this.checkedListBox1.SelectedIndex;
            int index = 0;
            while(index<this.checkedListBox1.Items.Count)
            {
                if(index==selindex)
                {
                    this.checkedListBox1.SetItemChecked(index, true);
                }
                else
                    this.checkedListBox1.SetItemChecked(index, false);
                index++;
            }
        }

        private void InitProgressBar()
        {
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Step = 5;
        }
        private void UpdateProgress()
        {
            var newvalue = this.progressBar1.Value+this.progressBar1.Step;
            if(newvalue>this.progressBar1.Maximum)
            {
                this.progressBar1.Value = newvalue - this.progressBar1.Maximum;
            }
            else
            {
                this.progressBar1.Value = newvalue;
            }
        }
        private void InitTimer()
        {
            this.timer1.Interval = 500;
            this.timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ChangePic();
            UpdateProgress();
        }

        private void InitPicCtr()
        {
            this.pictureBox1.Image = Properties.Resources.pic2;//使用工程资源文件
            this.pictureBox1.Image.Tag = "pic2";
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.MouseDown += PictureBox1_MouseDown;
        }
        private void ChangePic()
        {
            if (this.pictureBox1.Image.Tag.ToString() == "pic2")
            {
                this.pictureBox1.Image = Properties.Resources.pic3;
                this.pictureBox1.Image.Tag = "pic3";
            }
            else
            {
                this.pictureBox1.Image = Properties.Resources.pic2;
                this.pictureBox1.Image.Tag = "pic2";
            }
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                ChangePic();
            }
            else if(e.Button==MouseButtons.Right)
            {
                this.contextMenuStrip1.Items.Clear();
                var itblik = this.contextMenuStrip1.Items.Add("闪烁");
                var stopblink = this.contextMenuStrip1.Items.Add("停止闪烁");
                itblik.Image = Properties.Resources.pic7;
                stopblink.Image= Properties.Resources.pic7;
                itblik.Click += Itblik_Click;
                stopblink.Click += Stopblink_Click;
                this.contextMenuStrip1.Show(sender as Control, e.Location);
            }
        }

        private void Stopblink_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }

        private void Itblik_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
