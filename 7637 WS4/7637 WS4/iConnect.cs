using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7637_WS4
{
    public interface iConnect
    {
        void SendCommand(UDPCommand com_out);
        bool Open();
        bool Close();
    }
}
