using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GeoLib.WindowsHost.Contracts
{
  [ServiceContract]
  public interface IMessageService
  {
    [OperationContract]
    void ShowMessage(string message);
  }
}
