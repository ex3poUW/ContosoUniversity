using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//tinfo200:[2021-03-10-ex3po-dykstra1] - Allows for students to have course objects
namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}