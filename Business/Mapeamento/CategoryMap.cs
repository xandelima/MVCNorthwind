using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using MvcNorthwind.Models;

namespace MvcNorthwind.Map {
    
    
    public class CategoryMap : ClassMap<Category> {
        
        public CategoryMap() {
			Table("Categories");
			LazyLoad();
			Id(x => x.CategoryID).GeneratedBy.Identity().Column("CategoryID");
			Map(x => x.CategoryName).Not.Nullable().Column("CategoryName");
			Map(x => x.Description).Column("Description");
			Map(x => x.Picture).Column("Picture");
			HasMany(x => x.Products);
        }
    }
}
