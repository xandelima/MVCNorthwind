using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class CustomerCustomerDemo {
        public CustomerCustomerDemo() { }
        public virtual long CustomerID { get; set; }
        public virtual long CustomerTypeID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerDemographic { get; set; }


        public override bool Equals(object obj)
        {
             return base.Equals(obj);
        }

        public override int  GetHashCode()
        {
 	         return base.GetHashCode();
        }
    }
}
