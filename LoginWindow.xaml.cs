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
using System.Windows.Shapes;

namespace dromManageSystem
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            this.Closing += (s, e) => {
                var msg = MessageBox.Show("确定关闭吗？", "警告", MessageBoxButton.YesNo);

                if (msg != MessageBoxResult.Yes) {
                    e.Cancel = true;
                }
            };
        }
    }
}
