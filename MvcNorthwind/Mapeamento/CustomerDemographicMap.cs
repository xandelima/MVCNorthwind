using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcNorthwind.Models {
    
    
    public class CustomerDemographicMap : ClassMap<CustomerDemographic> {
        
        public CustomerDemographicMap() {
			Table("CustomerDemographics");
			LazyLoad();
			Id(x => x.CustomerTypeID).GeneratedBy.Identity().Column("CustomerTypeID");
			Map(x => x.CustomerDesc).Column("CustomerDesc");
			HasMany(x => x.CustomerCustomerDemos);
        }
    }
}
