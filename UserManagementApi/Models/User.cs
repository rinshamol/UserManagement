using System;

namespace UserManagementApi.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Age { get; set; }

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
