using dromManageSystem;
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

namespace WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        private Button lastButton;

        public MainWindow() {
            InitializeComponent();

            // 初始登录界面
            this.SourceInitialized += delegate {
                LoginWindow w = new LoginWindow();
                w.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                w.ShowDialog();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (lastButton != null) {
                lastButton.Foreground = Brushes.Blue;
            }
            Button btn = e.Source as Button;
            string content = btn.Content.ToString();

            if (content == "首页") {
                frame1.Source = new Uri("./src/DefaultPage.xaml", UriKind.Relative);
                return;
            }
            else if (content == "全部展开") {
                SetExpanded(true);
                return;
            }
            else if (content == "全部折叠") {
                SetExpanded(false);
                return;
            }
            btn.Foreground = Brushes.Red;

            Uri uri = new Uri(btn.Tag.ToString(), UriKind.Relative);
            object obj = null;
            try {
                obj = Application.LoadComponent(uri);
            }
            catch {
                MessageBox.Show("未找到 " + uri.OriginalString, "对方不想和你说话，并向你扔了一个Bug");
                return;
            }

            // 存在对象是窗体
            if (obj is Window) {
                Window w = obj as Window;
                w.ShowDialog();
                return;
            }

            if (lastButton == btn) {
                frame1.Refresh();
            }
            else {
                frame1.Source = uri;
            }
            lastButton = btn;
        }
        private void SetExpanded(bool isExpanded) {
            foreach (var v in stackPanel1.Children) {
                if (v is Expander expander) {
                    expander.IsExpanded = isExpanded;
                }
            }
        }
    }
}
