using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class Order {
        public Order() { }
        public virtual int OrderID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }
        public virtual System.Nullable<System.DateTime> OrderDate { get; set; }
        public virtual System.Nullable<System.DateTime> RequiredDate { get; set; }
        public virtual System.Nullable<System.DateTime> ShippedDate { get; set; }
        public virtual System.Nullable<decimal> Freight { get; set; }
        public virtual string ShipName { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual string ShipCity { get; set; }
        public virtual string ShipRegion { get; set; }
        public virtual string ShipPostalCode { get; set; }
        public virtual string ShipCountry { get; set; }


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
