using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Emp
    {
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public string EmpAddress { get; set; }
        [Key]
        public string EmpPhone { get; set; }

        public Emp()
        {

        }
    }
}
