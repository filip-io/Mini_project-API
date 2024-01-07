using Mini_project_API.Data;

namespace Mini_project_API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<InterestLink> InterestLinks { get; set; }
    }
}
