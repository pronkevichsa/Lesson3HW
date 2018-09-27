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
        
        private bool CheckValues(string strSumma, string strPercent, out decimal sum, out decimal per)
        {            
            bool checkSumma = Decimal.TryParse(TextBoxSumma.Text, out sum);          
            bool checkPercent = Decimal.TryParse(TextBoxPercent.Text, out per);
            return (checkSumma && checkPercent);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {            
            decimal summa = 0;
            decimal percent = 0;
            bool check = CheckValues(TextBoxSumma.Text, TextBoxPercent.Text, out summa, out percent);
            if (check)
            {
                Class1 Calculation = new Class1(summa, percent);
                decimal[] payment = new decimal[12];
                payment = Calculation.MonthPaymentCalc();
                FlowDocument mcFlowDoc = new FlowDocument();
                Paragraph para = new Paragraph();
                para.Inlines.Add("Выплаты по месяцам:\n");
                mcFlowDoc.Blocks.Add(para);
                string str = "";
                for (int i = 1; i <= 12; i++)
                {
                    str += i.ToString() + " месяц " + payment[i-1] + " руб.\n";
                }
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
