using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

using System.Timers;

namespace NotifyService
{

    /*
     闲来无事，实现一个右下角消息弹出框的功能
     Author:Stardance
     Date:2017-10-23
     */

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string notifyMessage;

        public string NotifyMessage
        {
            get { return notifyMessage; }
            set { notifyMessage = value; }
        }

        private string actionText;

        public string ActionText
        {
            get { return actionText; }
            set { actionText = value; }
        }

        private bool isAction;

        public bool IsAction
        {
            get { return isAction; }
            set { isAction = value; }
        }

        private Action action;

        private Timer timer;

        public MainWindow(string notifyMessage,string actionMessage = null,Action action = null)
        {
            InitializeComponent();
            this.DataContext = this;
            if(actionMessage == null)
            {
                IsAction = false;

                timer = new Timer(4000);
                timer.AutoReset = false;
                timer.Elapsed += (s, e) =>
                {
                    this.Dispatcher.BeginInvoke(new Action(()=>
                    {
                        this.Close();
                    })); 
                };
                timer.Start();
            }

            NotifyMessage = notifyMessage;
            ActionText = actionMessage;
            this.action = action;

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (actionText != null && action != null)
            {
                action.Invoke();
                this.Close();
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
