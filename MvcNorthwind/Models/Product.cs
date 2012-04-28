using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class Product {
        public Product() { }
        public virtual int ProductID { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string QuantityPerUnit { get; set; }
        public virtual System.Nullable<decimal> UnitPrice { get; set; }
        public virtual System.Nullable<short> UnitsInStock { get; set; }
        public virtual System.Nullable<short> UnitsOnOrder { get; set; }
        public virtual System.Nullable<short> ReorderLevel { get; set; }
        public virtual bool Discontinued { get; set; }

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
