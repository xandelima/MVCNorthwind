using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcNorthwind.Models {
    
    
    public class CustomerCustomerDemoMap : ClassMap<CustomerCustomerDemo> {
        
        public CustomerCustomerDemoMap() {
			Table("CustomerCustomerDemo");
			LazyLoad();
			CompositeId().KeyProperty(x => x.CustomerID).KeyProperty(x => x.CustomerTypeID);
			References(x => x.Customer).Column("CustomerID");
			References(x => x.CustomerDemographic).Column("CustomerTypeID");
        }
    }
}
