using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcNorthwind.Models {
    
    public class Employee {
        public Employee() { }
        public virtual int EmployeeID { get; set; }
        public virtual Employee employee { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Title { get; set; }
        public virtual string TitleOfCourtesy { get; set; }
        public virtual System.Nullable<System.DateTime> BirthDate { get; set; }
        public virtual System.Nullable<System.DateTime> HireDate { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string Extension { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual string Notes { get; set; }
        public virtual string PhotoPath { get; set; }

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
