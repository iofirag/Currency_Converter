using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApplication1 {


    public delegate Boolean DownloadDelegateAsync();

    public class Data : IData {

        // Data
        public List<Currency> currencyList {get;set;} 
        public string lastUpdate             {get; set;}

        // Async delegate method
        public DownloadDelegateAsync Dd {get;set;}



        public Data() {
            // initialize
            currencyList=new List<Currency>();
            lastUpdate="";

            // Async delegate 
            Dd=DownloadXML;
                                                Console.WriteLine("Data()");
            //IAsyncResult r=Dd.BeginInvoke(null, null);
            //                                    Console.WriteLine("after");
            //Dd.EndInvoke(r);
                                                //Console.WriteLine("do something after EndInvoke");
        }


        public Boolean DownloadXML() {
            string url="http://www.boi.org.il/currency.xml";    //http://www.bankisrael.gov.il/currency.xml
            string xml;
            try {
                /* Download XML file */
                using (var webClient=new WebClient()) {
                    xml=webClient.DownloadString(url);
                }

                /* parse XML */
                XDocument ob=XDocument.Parse(xml);

                /* Take evry currency data */
                //---------------------------------
                var Currencies=from c in ob.Descendants("CURRENCY")
                               select new {
                                   Name=c.Descendants("NAME").First().Value,
                                   Unit=c.Descendants("UNIT").First().Value,
                                   CurrencyCode=c.Descendants("CURRENCYCODE").First().Value,
                                   Country=c.Descendants("COUNTRY").First().Value,
                                   Rate=c.Descendants("RATE").First().Value,
                                   Change=c.Descendants("CHANGE").First().Value
                               };
                currencyList.Clear();       // init currencyList with parameters   
                foreach (var currency in Currencies) {
                    Currency c=new Currency(currency.Name, int.Parse(currency.Unit), currency.CurrencyCode, currency.Country, double.Parse(currency.Rate), double.Parse(currency.Change));
                    Console.WriteLine(c.toString());
                    currencyList.Add(c);
                }

                /* Take Last Update data */
                //---------------------------------
                var LastUpdateARR=from c in ob.Descendants("CURRENCIES")
                                  select new {
                                      Val=c.Descendants("LAST_UPDATE").First().Value
                                  };
                foreach (var last in LastUpdateARR) {
                    lastUpdate=last.Val;
                }
                System.Console.WriteLine(lastUpdate);
                return true;
            } catch (Exception e) {
                Console.WriteLine("Error: Download field, Check your internet connection.");
                return false;
            }
        }
    }
}
