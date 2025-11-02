namespace Jobs.Models
{
    public class Company
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // You can store image URLs as strings or handle them as byte arrays if uploaded.
        public string Image { get; set; } = string.Empty;
    }
}
