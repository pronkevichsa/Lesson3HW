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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double radius = 0;
                bool checkRadius=Double.TryParse(TextBoxRadius.Text, out radius);
            if (checkRadius)
            {
                TextBoxArea.Text = (radius * radius * Math.PI).ToString();
            }
            else
                MessageBox.Show("Введите правильно радиус");
        }

        //private float CalculationSummaMonth(decimal summa, decimal percent)
        //{
        //    float summaMonth = 0;
        //    decimal finalMonth = (summa * percent / 100 + summa) / 12;
        //    int finalMonthInt=Convert.ToInt32( (summa * percent / 100 + summa) / 12*100);

        //    return summaMonth;
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /// получаем данные и приобраовываем к числовому формату
            decimal summa;
            bool checkSumma =  Decimal.TryParse(TextBoxSumma.Text, out summa);          
            decimal percent;
            bool checkPercent = Decimal.TryParse(TextBoxPercent.Text, out percent);

            if (checkSumma && checkPercent)
            {
                decimal finalMonth = (summa * percent / 100 + summa) / 12;
                float finalMonthfloat = (float)Math.Round(Convert.ToDouble(finalMonth), 2);
                ///
                FlowDocument mcFlowDoc = new FlowDocument();
                Paragraph para = new Paragraph();
                para.Inlines.Add("Выплаты по месяцам:\n");
                mcFlowDoc.Blocks.Add(para);
                string str = "";
                string strMonth = String.Format("{0:C}", finalMonth);
                for (int i = 1; i <= 11; i++)
                {
                    str += i.ToString() + " месяц " + strMonth + " руб.\n";
                }
                /// в последний меяц выплаты чуть больше из-за округлений в предыдущие месяцы
                decimal lastMonth = (summa * percent / 100 + summa) - (decimal)finalMonthfloat * 11;
                string strLastMonth = String.Format("{0:C}", lastMonth);
                str += "12 месяц " + strLastMonth + " руб.\n";
                str += "Общая сумма выплат составит:" + (summa * percent / 100 + summa).ToString() + " руб.";
                para.Inlines.Add(str);
                mcFlowDoc.Blocks.Add(para);
                richText.Document = mcFlowDoc;
            }
            else
            {
                MessageBox.Show("Неверные введенные данные");
            }
           
            
        }
    }
}
