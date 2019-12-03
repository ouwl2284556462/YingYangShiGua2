using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YinYangShiGua2.core;

namespace YinYangShiGua2
{
    public partial class MainForm : Form
    {
        private Gua gua = new Gua();

        private Action<String> uiLogAction;

        public MainForm()
        {
            InitializeComponent();
            uiLogAction = new Action<String>(msg => log(msg));
            GlobalStatus.addMsgChgListener(onDebugMsgChg);
            GlobalStatus.addStopEvenListener(onStopEvenOccur);
        }

        private void onStopEvenOccur()
        {
            //如果调用控件的线程和创建创建控件的线程不是同一个则为True
            if (this.stopBtn.InvokeRequired)
            {
                while (!this.stopBtn.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.stopBtn.Disposing || this.stopBtn.IsDisposed)
                        return;
                }

                this.stopBtn.Invoke(new Action(() => this.stopBtn.PerformClick()));
            }
            else
            {
                this.stopBtn.PerformClick();
            }
        }

        private void onDebugMsgChg(String deBugMsg)
        {
            //如果调用控件的线程和创建创建控件的线程不是同一个则为True
            if (this.debugTextBox.InvokeRequired)
            {
                while (!this.debugTextBox.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.debugTextBox.Disposing || this.debugTextBox.IsDisposed)
                        return;
                }

                this.debugTextBox.Invoke(uiLogAction, deBugMsg);
            }
            else
            {
                log(deBugMsg);
            }
        }

        private void log(String msg)
        {
            debugTextBox.AppendText(msg + Environment.NewLine);
        }


        private void jueXingBtn_Click(object sender, EventArgs e)
        {
            gua.startGuaJi(Gua.GuaJiType.JUE_XING, getInputData());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            gua.stop();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            gua.stop();
        }

        private void yunHunBtn_Click(object sender, EventArgs e)
        {
            gua.startGuaJi(Gua.GuaJiType.YU_HUN, getInputData());
        }

        private InputData getInputData()
        {
            InputData data = new InputData();
            data.yuHunDoCount = getIntFormTextBox(yunHunCntTextBox);
            data.jueXingDoCount = getIntFormTextBox(juXingCntTextBox);
            return data;
        }

        private int? getIntFormTextBox(TextBox textBox)
        {
            try
            {
                return int.Parse(textBox.Text);
            }
            catch
            {
                return null;
            }
        }

  
    }
}
