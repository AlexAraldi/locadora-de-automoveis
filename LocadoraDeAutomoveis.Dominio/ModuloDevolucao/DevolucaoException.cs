using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloDevolucao
{
    public class DevolucaoException : Exception
    {
        public DevolucaoException(string message) : base(message)
        {
        }
    }
}
