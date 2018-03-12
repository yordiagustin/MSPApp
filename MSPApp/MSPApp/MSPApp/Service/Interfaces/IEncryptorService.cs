using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPApp.Service
{
    public interface IEncryptorService
    {
        string EncryptAes(string data, string password);
        string DecryptAes(string encryptedData, string password);
    }
}
