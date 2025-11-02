namespace Jobs.Models
{
    public class AppliedJob
    {
        
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public Company Company { get; set; } = new Company();
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty; // or DateTime if you prefer
        public string Status { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
    }

}
