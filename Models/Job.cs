using System.Numerics;
using Jobs.Models;

namespace Jobs.Models
{
    public class Job
    {
        
            public string Id { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public string Level { get; set; } = string.Empty;

            public Company Company { get; set; } = new Company();

            public string Description { get; set; } = string.Empty;
            public decimal Salary { get; set; }

            // Assuming this is a Unix timestamp (milliseconds)
            public long Date { get; set; }

            public string Category { get; set; } = string.Empty;
        

    }
}
