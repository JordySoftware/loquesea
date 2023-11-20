using CoursesApp.Domain.Security.RoleAggregate;

namespace CoursesApp.Application.Security.RoleApplication.DTOs
{
    public class RoleDTO
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public RoleStatus Status { get; private set; }

        public static RoleDTO GetDTO(Role role)
        {
            return new RoleDTO()
            {
                Id = role.Id,
                Code = role.Code,
                Name = role.Name,
                Description = role.Description,
                Status = role.Status
            };
        }
    }
}
