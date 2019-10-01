using Developoly.Server.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Developoly.Server.Services
{
    public partial class Service
    {
        public List<Course> CreateCourse(School school)
        {
            List<Skill> skillCourse = GenerateListOfSkillBlank();
            List<Course> coursesSchool = new List<Course>();
            var quantity = random.Next(QuantityNumberMinimumCourse, QuantityNumberMaximumCourse);
            while (quantity > 0)
            {
                int idSkillCourse = random.Next(1, this.SkillsNames.Count);
                skillCourse = generateOneSkill(skillCourse, idSkillCourse);
                Course course = new Course(coursesSchool.Count + 1, school, PriceCourse + (skillCourse.Max(s => s.Level) * MultiPriceCourse), (skillCourse.Max(s => s.Level) < SkillDevLevel) ? 1 : (skillCourse.Max(s => s.Level) < SkillDevLevel + 20) ? 2 : 3,null);
                course.Skills = skillCourse;
                coursesSchool.Add(course);
                
                quantity--;
            }
            return coursesSchool;
        }

       public void ReduceCourseTurnCounter(int clientId) {
            
            this.Companies.Where(c => c.Id == clientId).First().Devs.Where(d=>d.Course != null).ToList().ForEach(d => d.Course.Duration--);

        }

           
        public void RecoverDevFromCourse(int clientId) {
             this.Companies.Where(c => c.Id == clientId).First().Devs.Where(d => d.Course != null).Where(d=>d.Course.Duration == 0).ToList().ForEach(d=> RemoveDevFromCourse(d));
             this.Companies.Where(c => c.Id == clientId).First().Projects.RemoveAll(p => p.Duration == 0);
        }

        public void ImproveDevSkill() { }
    }
}
