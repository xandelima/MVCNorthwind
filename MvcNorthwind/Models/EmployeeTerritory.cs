using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class EmployeeTerritory {
        public EmployeeTerritory() { }
        public virtual int EmployeeID { get; set; }
        public virtual string TerritoryID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }

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
