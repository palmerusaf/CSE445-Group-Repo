using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Web;

namespace NewsFocus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsFocus" in both code and config file together.
    [ServiceContract]
    public interface INewsFocus
    {

        [WebGet]
        [OperationContract]
        string[] NewsFocus(string topics);
    }

}
