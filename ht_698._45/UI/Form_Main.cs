using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunisoft.IrisSkin;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ht_698._45.Base;

namespace ht_698._45.UI
{
    public partial class Form_Main : Form
    {
        [DllImport("shell32.dll")]//调用外部程序.exe
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);
        public static SkinEngine se=null;
        private IniFile iniFile = new IniFile(Application.StartupPath + @"\config.ini");
        private IniFile iniFile1 = new IniFile(Application.StartupPath + @"\Comm_Info.ini");
        public Form_Main()
        {
            this.InitializeComponent();
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            new Connection(this).Show();
            new CommParam(this).Show();
        }
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }
        /// <summary>
        /// 增加换肤菜单
        /// </summary>
        /// <param name="toolMenu"></param>
        public static void AddSkinMenu(ToolStripMenuItem toolMenu)
        {
            DataSet skin = new DataSet();
            try
            {
                skin.ReadXml("skin.xml", XmlReadMode.Auto);
            }
            catch
            {

            }
            if (skin == null || skin.Tables.Count < 1)
            {
                skin = new DataSet();
                skin.Tables.Add("skin");
                skin.Tables["skin"].Columns.Add("style");
                System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                dr[0] = "系统默认";
                skin.Tables[0].Rows.Add(dr);
                skin.WriteXml("skin.xml", XmlWriteMode.IgnoreSchema);
            }
            foreach (SkinType st in (SkinType[])System.Enum.GetValues(typeof(SkinType)))
            {
                toolMenu.DropDownItems.Add(new ToolStripMenuItem(st.ToString()));

                toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1].Click += new EventHandler(frm_Main_Click);
                if (st.ToString() == skin.Tables[0].Rows[0][0].ToString())
                {
                    ((ToolStripMenuItem)toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1]).Checked = true;
                    frm_Main_Click(toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1], null);

                }

            }

            toolMenu.DropDownItems.Add(new ToolStripMenuItem("系统默认"));
            toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1].Click += new EventHandler(frm_Main_Click);
            if (skin.Tables[0].Rows[0][0].ToString() == "系统默认")
            {
                ((ToolStripMenuItem)toolMenu.DropDownItems[toolMenu.DropDownItems.Count - 1]).Checked = true;
            }
        }

        public static void ChangeSkin(SkinType st)
        {
            System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                if (se == null)
                {
                    se = new SkinEngine(Application.OpenForms[0], executingAssembly.GetManifestResourceStream("ht_698._45.skin." + st.ToString() + ".ssk"));
                    se.Active = true;
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                    {
                        se.AddForm(Application.OpenForms[i]);
                    }
                }
                else
                {
                    se.SkinStream = executingAssembly.GetManifestResourceStream("ht_698._45.skin." + st.ToString() + ".ssk");
                    se.Active = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            }
            
        }
        /// <summary>
        /// 移除皮肤
        /// </summary>
        public static void RemoveSkin()
        {
            if (se == null)
            {
                return;
            }
            else
            {
                se.Active = false;
            }
        }
        static void frm_Main_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)sender).Text == ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i].Text)
                {
                    ((ToolStripMenuItem)sender).CheckState = CheckState.Checked;
                    DataSet skin = new DataSet();
                    skin.Tables.Add("skin");
                    skin.Tables["skin"].Columns.Add("style");
                    System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                    dr[0] = ((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i].Text;
                    skin.Tables[0].Rows.Add(dr);
                    skin.WriteXml("skin.xml", XmlWriteMode.IgnoreSchema);

                }
                else
                {
                    ((ToolStripMenuItem)((ToolStripMenuItem)((ToolStripMenuItem)sender).OwnerItem).DropDownItems[i]).CheckState = CheckState.Unchecked;
                }
            }
            if (((ToolStripMenuItem)sender).Text == "系统默认")
            {
                RemoveSkin();
                DataSet skin = new DataSet();
                skin.Tables.Add("skin");
                skin.Tables["skin"].Columns.Add("style");
                System.Data.DataRow dr = skin.Tables["skin"].NewRow();
                dr[0] = "系统默认";
                skin.Tables[0].Rows.Add(dr);
                skin.WriteXml("skin.xml", XmlWriteMode.IgnoreSchema);
                return;
            }
            foreach (SkinType st in (SkinType[])System.Enum.GetValues(typeof(SkinType)))
            {
                if (st.ToString() == ((ToolStripMenuItem)sender).Text)
                {
                    ChangeSkin(st);
                    return;
                }
            }
        }
        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var mb=MessageBox.Show("是否确定退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes==mb)
            {
                this.Close();
            }
            
        }

        private void GetMessage()
        {
            try
            {
                if (PublicVariable.ChangedFlag)
                {
                    string str = "->" + PublicVariable.SendDataString;
                    string str2 = "<-" + PublicVariable.RecDataString;
                    this.TXB_Rec.AppendText("===============================================\r\n");
                    this.TXB_Rec.AppendText(str + "\r\n");
                    this.TXB_Rec.AppendText(str2 + "\r\n");
                    PublicVariable.comTicks = ((float)(PublicVariable.RecOverTicks - PublicVariable.SendTimeTicks)) / 10000f;
                    if (PublicVariable.RecTimeOutFlag)
                    {
                        this.toolStripStatusLabelComTicks.Text = "超时";
                        PublicVariable.RecTimeOutFlag = false;
                    }
                    else
                    {
                        this.toolStripStatusLabelComTicks.Text = PublicVariable.comTicks.ToString() + "ms";
                    }
                }
                PublicVariable.ChangedFlag = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.toolStripStatusLabelShowTime.Text != DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))
                {
                    this.toolStripStatusLabelShowTime.Text = DateTime.Now.ToString(" yyyy-MM-dd hh:mm:ss");
                }
                if (this.toolStripStatusLabelInfo.Text != PublicVariable.Info)
                {
                    this.toolStripStatusLabelInfo.Text = PublicVariable.Info;
                }
                if (this.toolStripStatusLabelComShow.Text != PublicVariable.ComName)
                {
                    this.toolStripStatusLabelComShow.Text = PublicVariable.ComName;
                }
                if (this.toolStripStatusLabelComParam.Text != PublicVariable.ComInfo)
                {
                    this.toolStripStatusLabelComParam.Text = PublicVariable.ComInfo;
                }
                this.toolStripStatusLabelInfo.ToolTipText = PublicVariable.Info;
                this.toolStripStatusLabelInfo.ForeColor = (PublicVariable.Info_Color == "Blue") ? Color.Black : Color.Red;
                this.GetMessage();
            }
            catch (Exception exception)
            {
                string caption = "错误";
                caption = "timer1_Tick" + caption;
                MessageBox.Show(exception.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 50;
            this.timer1.Enabled = true;
            this.tcb_密钥选择.SelectedIndex = 0;
            PublicVariable.IP = this.iniFile.IniReadValue("MAIN", "ip");
            PublicVariable.port = this.iniFile.IniReadValue("MAIN", "port");
            PublicVariable.timeOut = this.iniFile.IniReadValue("MAIN", "timeout");
            PublicVariable.LinkRoadFlag = Convert.ToBoolean(this.iniFile.IniReadValue("MAIN", "LinkRoadFlag"));
            AddSkinMenu(this.pfu);
            
        }

        private void 串口配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "CommParam")
                {
                    form.Activate();
                    return;
                }
            }
            new CommParam(this).Show();
        }

        private void iP参数配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "SetIP")
                {
                    form.Activate();
                    return;
                }
            }
            new SetIP(this).Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Energy")
                {
                    form.Activate();
                    return;
                }
            }
            new Energy(this).Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Freeze")
                {
                    form.Activate();
                    return;
                }
            }
            new Freeze(this).Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Event")
                {
                    form.Activate();
                    return;
                }
            }
            new Event(this).Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "demand")
                {
                    form.Activate();
                    return;
                }
            }
            new demand(this).Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Variable")
                {
                    form.Activate();
                    return;
                }
            }
            new Variable(this).Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Follow_Collection")
                {
                    form.Activate();
                    return;
                }
            }
            new Follow_Collection(this).Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "StateMeter")
                {
                    form.Activate();
                    return;
                }
            }
            new StateMeter(this).Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "meterInfo")
                {
                    form.Activate();
                    return;
                }
            }
            new meterInfo(this).Show();
        }

        private void 参变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Parameter")
                {
                    form.Activate();
                    return;
                }
            }
            new Parameter(this).Show();
        }

        private void 模式字特征字ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "ModeKeys")
                {
                    form.Activate();
                    return;
                }
            }
            new ModeKeys(this).Show();
        }

        private void 高级参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Advanced")
                {
                    form.Activate();
                    return;
                }
            }
            new Advanced(this).Show();
        }

        private void 远程控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "feesCharge")
                {
                    form.Activate();
                    return;
                }
            }
            new feesCharge(this).Show();
        }

        private void 费率时段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Rates")
                {
                    form.Activate();
                    return;
                }
            }
            new Rates(this).Show();
        }

        private void 阶梯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "LadderAndPrice")
                {
                    form.Activate();
                    return;
                }
            }
            new LadderAndPrice(this).Show();
        }

        private void 数据回抄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "dataBack")
                {
                    form.Activate();
                    return;
                }
            }
            new dataBack(this).Show();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "display")
                {
                    form.Activate();
                    return;
                }
            }
            new display(this).Show();
        }

        private void 安全模式参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "安全模式参数")
                {
                    form.Activate();
                    return;
                }
            }
            new form_安全模式参数(this).Show();
        }

        private void 主动上报ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "AutoReport")
                {
                    form.Activate();
                    return;
                }
            }
            new AutoReport(this).Show();
        }

        private void 应用连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Connection")
                {
                    form.Activate();
                    return;
                }
            }
            new Connection(this).Show();
        }

        private void 远程控制ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "feesCharge")
                {
                    form.Activate();
                    return;
                }
            }
            new feesCharge(this).Show();
        }

        private void 测试工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "selfWrop")
                {
                    form.Activate();
                    return;
                }
            }
            new selfWrop(this).Show();
        }

        private void 批操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "BatchOperation")
                {
                    form.Activate();
                    return;
                }
            }
            new BatchOperation(this).Show();
        }

        private void 内部进厂命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "InnerCommand")
                {
                    form.Activate();
                    return;
                }
            }
            new InnerCommand(this).Show();
        }

        private void 系统配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Sysconfig")
                {
                    form.Activate();
                    return;
                }
            }
            new Sysconfig(this).Show();
        }
        /// <summary>
        /// 此函数用于判断某一外部进程是否打开
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        private bool IsProcessStarted(string processName)
        {

            Process[] temp = Process.GetProcessesByName(processName);
            if (temp.Length > 0) return true;
            else
                return false;

        }
        /// <summary>
        /// 外部程序显示置顶
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        private void 报文解析toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool b = IsProcessStarted("国网报文解析(面向对象)");
            string pName = "国网报文解析(面向对象)";//要启动的进程名称，可以在任务管理器里查看，一般是不带.exe后缀的;  
            Process[] temp = Process.GetProcessesByName(pName);//在所有已启动的进程中查找需要的进程；
            if (temp.Length > 0)//如果查找到
            {
                IntPtr handle = temp[0].MainWindowHandle;
                SwitchToThisWindow(handle, true);    // 激活，显示在最前
            }
            if (!b)
                ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("国网报文解析(面向对象).exe"), new StringBuilder(""), new StringBuilder(Application.StartupPath), 1);
        }

        private void 安全传输方式ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            tcb_密钥选择.Focus();
        }

        private void tcb_密钥选择_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicVariable.link_Math = (Link_Math)this.tcb_密钥选择.SelectedIndex;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            var mb = MessageBox.Show("是否确定清空测试内容？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == mb)
            {
                TXB_Rec.Text = "";
            }
        }

        private void toolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
            this.CmbLogical.Focus();
        }

        private void 集合类接口toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "FrmCollection")
                {
                    form.Activate();
                    return;
                }
            }
            new FrmCollection(this).Show();
        }

        private void 关于ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "Aboat")
                {
                    form.Activate();
                    return;
                }
            }
            new Aboat(this).Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            foreach (Form form in base.MdiChildren)
            {
                if (form.Name == "CommParam")
                {
                    form.Activate();
                    return;
                }
            }
            new CommParam(this).Show();
        }

        private void CmbLogical_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicVariable.logical_Address = (Logical_Address)this.CmbLogical.SelectedIndex;
            PublicVariable.Address = (PublicVariable.logical_Address == Logical_Address.计量芯 ? "15" : "05") + PublicVariable.address;
        }
    }
}
