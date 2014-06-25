//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace WindowsFormsApplication2 {

//    //delegate Boolean DownloadDelegateAsync();


//    public partial class Form1 : Form {
//        // Data Variables
//        //static List<Currency> CurrencyList=new List<Currency>();
//        //static string LastUpdate="";

//        // Async delegate 
//        //DownloadDelegateAsync Dd=DownloadXML;

//        Data data;

//        public Form1() {
//            InitializeComponent();

//            Console.WriteLine("before Form1");
//            data=new Data();
//            Console.WriteLine("after1");
//            IAsyncResult r=data.Dd.BeginInvoke(null, null);
//            Console.WriteLine("BeginInvoke");
//            data.Dd.EndInvoke(r);
//            Console.WriteLine("EndInvoke");
//            label1.Text="Last update was at: "+data.lastUpdate;
//        }

//        private void button1_Click(object sender, System.EventArgs e) {
//            //IAsyncResult r=Dd.BeginInvoke(null, null);

//            //Dd.EndInvoke(r);
//            //label1.Text="Last update was at: "+LastUpdate;
//        }
//    }
//}
