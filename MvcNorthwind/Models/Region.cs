using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class Region {
        public Region() { }
        public virtual int RegionID { get; set; }
        public virtual IList<Territory> Territories { get; set; }
        public virtual long RegionDescription { get; set; }

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
