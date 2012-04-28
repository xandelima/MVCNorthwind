using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using MvcNorthwind.Models;

namespace MvcNorthwind.Map {
    
    
    public class OrderDetailMap : ClassMap<OrderDetail> {
        
        public OrderDetailMap() {
			Table("OrderDetails");
			LazyLoad();
			CompositeId().KeyProperty(x => x.OrderID).KeyProperty(x => x.ProductID);
			References(x => x.Order).Column("OrderID");
			References(x => x.Product).Column("ProductID");
			Map(x => x.UnitPrice).Not.Nullable().Column("UnitPrice");
			Map(x => x.Quantity).Not.Nullable().Column("Quantity");
			Map(x => x.Discount).Not.Nullable().Column("Discount");
        }
    }
}
