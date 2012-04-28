using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class Territory {
        public Territory() { }
        public virtual string TerritoryID { get; set; }
        public virtual Region Region { get; set; }
        public virtual IList<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual long TerritoryDescription { get; set; }

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
