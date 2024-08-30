using KMCCC.Launcher;
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
using KMCCC.Authentication;
using KMCCC.Launcher;
using System.Data.OleDb;


namespace StarMcLauncher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static KMCCC.Launcher.Version[] versions;
        public static LauncherCore Core = LauncherCore.Create();
        public MainWindow()
        {
            InitializeComponent();
            KMCCC.Launcher.Version[] versions = Core.GetVersions().ToArray();
            VersionsList.ItemsSource = versions;

        }

        private void Button_Click(RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.JavaPath = @"C:\Program Files\Java\jdk-17.0.5\bin\javaw.exe";
            var ver = (KMCCC.Launcher.Version)VersionsList.SelectedItem;
            var result = Core.Launch(new LaunchOptions
            {
                Version = ver, //Ver为Versions里你要启动的版本名字
                MaxMemory = 1024, //最大内存，int类型
                Authenticator = new OfflineAuthenticator(userName.Text), //离线启动，为你要设置的游戏名
                //Authenticator = new YggdrasilLogin("邮箱", "密码", true)  // 正版启动，最后一个为是否twitch登录
                Mode = LaunchMode.MCLauncher, //启动模式，这个我会在后面解释有哪几种
                // Server = new ServerInfo { Address = "服务器IP地址", Port = "服务器端口" }  //设置启动游戏后，自动加入指定IP的服务器，可以不要
                Size = new WindowSize { Height = 768, Width = 1280 } //设置窗口大小，可以不要
            });

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            X.Navigate(new LX());
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            X.Navigate(new WR());
        }
    }
}
