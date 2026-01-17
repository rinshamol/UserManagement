using UserManagementApi.Dtos;
using UserManagementApi.Models;

namespace UserManagementApi.Mapping
{
    public static class UserMappingExtensions
    {
        public static UserResponseDto ToResponseDto(this User user) => new()
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Age = user.Age,
            CreatedAtUtc = user.CreatedAtUtc
        };

        public static User ToEntity(this UserCreateDto dto) => new()
        {
            FullName = dto.FullName.Trim(),
            Email = dto.Email.Trim().ToLowerInvariant(),
            Age = dto.Age
        };

        public static void ApplyUpdate(this User user, UserUpdateDto dto)
        {
            user.FullName = dto.FullName.Trim();
            user.Email = dto.Email.Trim().ToLowerInvariant();
            user.Age = dto.Age;
        }
    }
}
