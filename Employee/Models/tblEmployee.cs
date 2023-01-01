using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class tblEmployee
    {
        [Key]
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhone { get; set; }
        public tblEmployee()
        {

        }
    }
}
