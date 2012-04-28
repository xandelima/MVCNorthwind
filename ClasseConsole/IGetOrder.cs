using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MvcNorthwind.Models;

namespace WCFService
{
    [ServiceContract]
    interface IGetOrder
    {
        [OperationContract]
        List<Order> GetAll(int value);
    }
}
