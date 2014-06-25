

namespace WpfApplication1 {
    public class Currency {
        string Name;
        int Unit;
        string CurrencyCode;
        string Country;
        double Rate;
        double Change;


        public Currency(string name, int unit, string currencyCode, string country, double rate, double change) {
            this.Name=name;
            this.Unit=unit;
            this.CurrencyCode=currencyCode;
            this.Country=country;
            this.Rate=rate;
            this.Change=change;
        }

        public void setName(string o) {
            this.Name=o;
        }
        public void setUnit(int o) {
            this.Unit=o;
        }
        public void setCurrencyCode(string o) {
            this.CurrencyCode=o;
        }
        public void setCountry(string o) {
            this.Country=o;
        }
        public void setRate(double o) {
            this.Rate=o;
        }
        public void setChange(double o) {
            this.Change=o;
        }

        public string getName() {
            return this.Name;
        }
        public int getUnit() {
            return this.Unit;
        }
        public string getCurrencyCode() {
            return this.CurrencyCode;
        }
        public string getCountry() {
            return this.Country;
        }
        public double getRate() {
            return this.Rate;
        }
        public double getChange() {
            return this.Change;
        }

        public string toString() {
            return Name
                +" "+Unit
                +" "+CurrencyCode
                +" "+Country
                +" "+Rate
                +" "+Change;
        }
    }
}
