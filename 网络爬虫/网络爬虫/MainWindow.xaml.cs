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

namespace 网络爬虫
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        const string htmlCode= "UTF-8";
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 读取网页内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listContent.Items.Clear();
            string strUrl = textUrl.Text.ToString();
            
          string content= Crawler.GetHttpWebRequest(strUrl);
            listContent.Items.Add(content);

        }
        /// <summary>
        /// 遍历网页链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listTitle.ItemsSource = "";
            string strUrl = textUrl.Text.ToString();
            string content = Crawler.GetHttpWebRequest(strUrl);
            List<string> urlList=Crawler.GetHyperLinks(content, strUrl);

            listTitle.ItemsSource= urlList;
        }
        /// <summary>
        /// 读取网页标题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listTitle.ItemsSource = "";
            string strUrl = textUrl.Text.ToString();
            string title = Crawler.GetTitle( Crawler.GetHttpWebRequest(strUrl));

            listTitle.ItemsSource=title;
        }
    }
}
