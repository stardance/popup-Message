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

using NotifyService;

namespace Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private NotifyService.MainWindow notifyWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(message.Text))
            {
                notifyWindow = new NotifyService.MainWindow("       您的计算机已被感染");
                notifyWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                notifyWindow = new NotifyService.MainWindow("        恭喜您获得100万大奖，访问此网站填写个人信息领奖！", message.Text, new Action(() =>
                {
                    System.Diagnostics.Process.Start("www.Github.com");
                }));
            }
           

           
            double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
            notifyWindow.Left = x1 - 180;
            //notifyWindow.Top = y1 - 60;
            notifyWindow.Show();
        }
    }
}
