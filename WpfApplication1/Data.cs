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
        public List<Currency> CurrencyList {get;set;}
        public string LastUpdate { get; set; }

        // Async delegate method
        public DownloadDelegateAsync DDownload {get;set;}



        public Data() {
            // initialize
            CurrencyList=new List<Currency>();
            LastUpdate="";

            // Async delegate 
            DDownload=DownloadXML;
        }


        public Boolean DownloadXML() {
            string Url="http://www.boi.org.il/currency.xml";
                 //Url="hhttp://www.bankisrael.gov.il/currency.xml";
            string Xml=null;
            try {

                /* Download XML file */
                //for (int i=0; i<2; i++ ){
                    //data downloaded great
                    //if (Xml != null && !Xml.Contains("cookie") ){
                    //    break;
                    //}
                Xml=new WebClient().DownloadString(Url);
                Console.WriteLine(Xml);

                /* Download XML file from my server */
                //if data downloaded with errors
                if (Xml!=null&&Xml.Contains("cookie")) {
                    Console.WriteLine("Data downloaded with error.");
                    Url="http://ofir.eu5.org/currencyConverter/currency.xml";
                    Xml=new WebClient().DownloadString(Url);
                    Console.WriteLine("Download file from my server.");
                }
                Console.WriteLine(Xml);


                /* parse XML */
                XDocument Ob = XDocument.Parse(Xml);



                /* Take evry currency data */
                //---------------------------------
                var Currencies=from c in Ob.Descendants("CURRENCY")
                               select new {
                                   Name=c.Descendants("NAME").First().Value,
                                   Unit=c.Descendants("UNIT").First().Value,
                                   CurrencyCode=c.Descendants("CURRENCYCODE").First().Value,
                                   Country=c.Descendants("COUNTRY").First().Value,
                                   Rate=c.Descendants("RATE").First().Value,
                                   Change=c.Descendants("CHANGE").First().Value
                               };
                CurrencyList.Clear();       // init currencyList with parameters   
                foreach (var currency in Currencies) {
                    Currency c=new Currency(currency.Name, int.Parse(currency.Unit), currency.CurrencyCode, currency.Country, double.Parse(currency.Rate), double.Parse(currency.Change));
                    Console.WriteLine(c.toString());
                    CurrencyList.Add(c);
                }

                /* Take Last Update data */
                //---------------------------------
                var LastUpdateARR=from c in Ob.Descendants("CURRENCIES")
                                  select new {
                                      Val=c.Descendants("LAST_UPDATE").First().Value
                                  };
                foreach (var last in LastUpdateARR) {
                    LastUpdate=last.Val;
                }
                System.Console.WriteLine(LastUpdate);
                return true;
            } catch (Exception e) {
                Console.WriteLine("Error: Download field, Check your internet connection.");
                return false;
            }
        }
    }
}
