using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class Shipper {
        public Shipper() { }
        public virtual int ShipperID { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string Phone { get; set; }

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
