using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using MvcNorthwind.Models;

namespace MvcNorthwind.Map {

    public class OrderMap : ClassMap<Order> {
        
        public OrderMap() {
			Table("Orders");
			LazyLoad();
			Id(x => x.OrderID).GeneratedBy.Identity().Column("OrderID");
			References(x => x.Customer).Column("CustomerID");
			References(x => x.Employee).Column("EmployeeID");
			References(x => x.Shipper).Column("ShipVia");
			Map(x => x.OrderDate).Column("OrderDate");
			Map(x => x.RequiredDate).Column("RequiredDate");
			Map(x => x.ShippedDate).Column("ShippedDate");
			Map(x => x.Freight).Column("Freight");
			Map(x => x.ShipName).Column("ShipName");
			Map(x => x.ShipAddress).Column("ShipAddress");
			Map(x => x.ShipCity).Column("ShipCity");
			Map(x => x.ShipRegion).Column("ShipRegion");
			Map(x => x.ShipPostalCode).Column("ShipPostalCode");
			Map(x => x.ShipCountry).Column("ShipCountry");
			HasMany(x => x.OrderDetails);
        }
    }
}
