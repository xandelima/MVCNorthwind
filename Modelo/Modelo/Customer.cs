using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    [Serializable]
    public class Customer {
        public Customer() { }
        public virtual string CustomerID { get; set; }

        
        private  IList<Order> orders;
        
        public virtual IList<Order> Orders 
        { 
            get { return orders; }
            set { orders = value; }
        }

        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }


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
