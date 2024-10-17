using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Contracts
{
    //Message Consumera iletildiğinde yapılacak işlemler
    //event tanımı geçmiş zaman kipi ve
    //publish methodu
    public record class MessageSubmitted(string message);
}
