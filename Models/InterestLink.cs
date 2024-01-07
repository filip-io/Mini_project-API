namespace Mini_project_API.Models
{
    public class InterestLink
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public virtual Interest? Interest { get; set; }
        public virtual Person? Person { get; set; }
    }
}
