namespace FinalProject.Models
{
    public class EventViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string EventOrganiser { get; set; }

        public string ImageUrl { get; set; }

        public int Likes { get; set; }

        public string? Category { get; set; }
    }
}
