using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PasswordHasher
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPasswordHasher
    {
        [OperationContract]
        string GenerateSalt();

        [OperationContract]
        string HashPassword(string password, string salt);

        [OperationContract]
        bool VerifyPassword(string inputPassword, string storedHash, string salt);
        // TODO: Add your service operations here
    }


    
}
