using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Interfaces
{
    public interface ISeguridadServices
    {
        bool VerifyPassByCrypt(string passDigitado, string storedHash);
        string GenerateHashByCrypt(string data);
        bool ValidarSession(int idUser, string vista);
    }
}
