using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MyToolBoxForAudioProcessing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ListViewDataContext> listContext;
        private Action<string> converter;
        public MainWindow()
        {
            converter = ConvertFromReal;
            listContext = new ObservableCollection<ListViewDataContext>();
            listContext.Add(new ListViewDataContext() { Name = "REAL", Value = "0" });
            listContext.Add(new ListViewDataContext() { Name = "dB", Value = "0" });
            listContext.Add(new ListViewDataContext() { Name = "IEEE754", Value = "0" });
            InitializeComponent();
            ListView1.ItemsSource = listContext;
            ListView1.SelectedIndex = 0;
            ListView1.SelectionChanged += (s, e) =>
            {
                if(ListView1.SelectedIndex == 0)
                {
                    converter = ConvertFromReal;
                }else if(ListView1.SelectedIndex == 1)
                {
                    converter = ConvertFromDB;
                }else if(ListView1.SelectedIndex == 2)
                {
                    converter = ConvertFromIeee754;
                }
            };
        }

        private void InputText_TextChanged(object sender, TextChangedEventArgs e)
        {
            converter?.Invoke(InputText.Text.Trim());
        }
        private void ConvertFromReal(float val)
        {
            listContext[0].Value = val.ToString("E8");
            listContext[1].Name = (val >= 0) ? "dB [Pos]" : "dB [Neg]";
            listContext[1].Value = (val == 0) ? "-inf" : (20 * Math.Log10(Math.Abs(val))).ToString("E8");
            listContext[2].Value = "0x" + BitConverter.SingleToInt32Bits(val).ToString("X8");
        }
        private void ConvertFromReal(string input)
        {
            if(float.TryParse(input, out var val))
            {
                ConvertFromReal(val);
            }
        }

        private void ConvertFromDB(string input)
        {
            if(float.TryParse(input, out var val))
            {
                var real = Math.Pow(10, val / 20);
                ConvertFromReal((float)real);
            }
        }

        private void ConvertFromIeee754(string input)
        {
            if(int.TryParse(input, System.Globalization.NumberStyles.HexNumber, null, out var val))
            {
                var real = BitConverter.Int32BitsToSingle(val);
                ConvertFromReal(real);
            }
        }
    }
}
