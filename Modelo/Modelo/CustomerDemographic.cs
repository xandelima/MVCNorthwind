using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class CustomerDemographic {
        public CustomerDemographic() { }
        public virtual long CustomerTypeID { get; set; }
        public virtual IList<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public virtual string CustomerDesc { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
