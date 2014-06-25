using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window {

        Data data;

        public delegate void Update();
        public Update Uui;

        //int.Parse(tbAmount1.Text)
        //int.Parse(tbAmount2.Text)
        //data.currencyList.ElementAt(cbCurrencyList1.SelectedIndex).getRate()
        //data.currencyList.ElementAt(cbCurrencyList2.SelectedIndex).getRate()

        double _cbCurrencyList1;
        double _cbCurrencyList2;
        double _mtbAmount1=0;
        //double _mtbAmount2=0;

        public MainWindow() {
            InitializeComponent();

            data=new Data();

            Uui=updateUI;
            Dispatcher.Invoke(data.Dd);
            Dispatcher.Invoke(Uui);
            //IAsyncResult r=data.Dd.BeginInvoke(Uui, null);   //<--

            //d
            //data.Dd.EndInvoke(r);   //do something after EndInvoke
            //updateUI();    
        }



        private void bUpdate_Click(object sender, RoutedEventArgs e) {
            // Run Async method
            //IAsyncResult r=data.Dd.BeginInvoke(null, null);   //<--
            
            ////d
            //data.Dd.EndInvoke(r);   //do something after EndInvoke
            //updateUI();     



            Dispatcher.Invoke(data.Dd);
            Dispatcher.Invoke(Uui);
        }

        




        private void cbCurrencyList1_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbCurrencyList1.SelectedIndex >= 0){    //check if user has change the first value
                Console.WriteLine(cbCurrencyList1.SelectedIndex);
                _cbCurrencyList1 = data.currencyList.ElementAt(cbCurrencyList1.SelectedIndex).getRate();
                Console.WriteLine(_cbCurrencyList1);
            }
        }
        private void cbCurrencyList2_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cbCurrencyList2.SelectedIndex>=0) {    //check if user has change the first value
                Console.WriteLine(cbCurrencyList2.SelectedIndex);
                _cbCurrencyList2 = data.currencyList.ElementAt(cbCurrencyList2.SelectedIndex).getRate();
                Console.WriteLine(_cbCurrencyList2);
            }
        }



        private void tbAmount1_TextChanged(object sender, TextChangedEventArgs e) {
            try {
                if (double.Parse(tbAmount1.Text) >=0);
                    _mtbAmount1=double.Parse(tbAmount1.Text);
            } catch (Exception ex) {
                tbAmount1.Text="0";
                _mtbAmount1=0;
            }
        }

        
        private void bResult_Click(object sender, RoutedEventArgs e) {
            // calculate
            Console.WriteLine(_mtbAmount1+" "+_cbCurrencyList1+" "+_cbCurrencyList2);
            tbAmount2.Text=""+(_mtbAmount1*_cbCurrencyList1)/_cbCurrencyList2;
            //_cbCurrencyList2_SelectedIndex        
        }





        //private void updateUI(IAsyncResult ar) {        //   <--------
            //throw new NotImplementedException();
            //// Update LastUpdate
            //lLastUpdate.Content=data.lastUpdate;

            //cbCurrencyList1.Items.Clear();      // init
            //cbCurrencyList2.Items.Clear();      // init
            //// Update ComboBox
            //foreach (Currency currency in data.currencyList) {
            //    cbCurrencyList1.Items.Add(currency.getCurrencyCode());
            //    cbCurrencyList2.Items.Add(currency.getCurrencyCode());
            //}
            //if (cbCurrencyList1.SelectedIndex < 0)
            //    cbCurrencyList1.SelectedIndex=0;

            //if (cbCurrencyList2.SelectedIndex < 0)
            //    cbCurrencyList2.SelectedIndex=0;

            //Console.WriteLine("download complete");
            //tbAmount1.Text = "Start 1";
            
            //tbAmount1.set.Text="222";
        //}
        public void updateUI(){
            // Update LastUpdate
            lLastUpdate.Content=data.lastUpdate;

            cbCurrencyList1.Items.Clear();      // init
            cbCurrencyList2.Items.Clear();      // init
            // Update ComboBox
            foreach (Currency currency in data.currencyList) {
                cbCurrencyList1.Items.Add(currency.getCurrencyCode());
                cbCurrencyList2.Items.Add(currency.getCurrencyCode());
            }
            if (cbCurrencyList1.SelectedIndex<0)
                cbCurrencyList1.SelectedIndex=0;

            if (cbCurrencyList2.SelectedIndex<0)
                cbCurrencyList2.SelectedIndex=0;

            Console.WriteLine("download complete");
        }
    }
}
