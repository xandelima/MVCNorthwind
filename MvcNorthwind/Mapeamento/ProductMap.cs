using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcNorthwind.Models {
    
    
    public class ProductMap : ClassMap<Product> {
        
        public ProductMap() {
			Table("Products");
			LazyLoad();
			Id(x => x.ProductID).GeneratedBy.Identity().Column("ProductID");
			References(x => x.Supplier).Column("SupplierID");
			References(x => x.Category).Column("CategoryID");
			Map(x => x.ProductName).Not.Nullable().Column("ProductName");
			Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
			Map(x => x.UnitPrice).Column("UnitPrice");
			Map(x => x.UnitsInStock).Column("UnitsInStock");
			Map(x => x.UnitsOnOrder).Column("UnitsOnOrder");
			Map(x => x.ReorderLevel).Column("ReorderLevel");
			Map(x => x.Discontinued).Not.Nullable().Column("Discontinued");
			HasMany(x => x.OrderDetails);
        }
    }
}
