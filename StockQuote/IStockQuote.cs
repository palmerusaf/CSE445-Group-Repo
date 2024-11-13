using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;


namespace StockQuote
{
    [ServiceContract]
    public interface IStockQuote
    {
        /**
          * @brief calls a stock API and process the data to provide
          * the required output. 
          *
          * @param stock symbol
          * @return opening price
          */
        [OperationContract]
        Task<string> Stockquote(string symbol);
        [OperationContract]
        AnnualStockData AnnualStockReport(string symbol);
    }
    [DataContract]
    public class AnnualStockData
    {
        [DataMember]
        public string annualReturn;
        [DataMember]
        public List<MonthlyClose> monthlyClosings;

    }
    public class MonthlyClose
    {
        public string name;
        public string price;
    }
}
