using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class OrderDetail {
        public OrderDetail() { }
        public virtual int OrderID { get; set; }
        public virtual int ProductID { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual short Quantity { get; set; }
        public virtual float Discount { get; set; }


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
