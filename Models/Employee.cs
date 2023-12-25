using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otdelkadrov.Models
{
    class Employee : Chapter
    {
        //Личные данные
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string BankCardNumber { get; set; }

        //Паспортные данные
        public string PassSerial { get; set; }
        public string PassNumber { get; set; }
        public string DepartmentNumber { get; set; }
        public string IssueDate { get; set; }
        public string IssuedBy { get; set; }

        //Зарегистрирован
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }

        //Трудовая деятельность
        public string Department { get; set; }
        public string Position { get; set; }
        public string EmploymentDate { get; set; }
        public string Rate { get; set; }

        public string Photo { get; set; }
    }
}
