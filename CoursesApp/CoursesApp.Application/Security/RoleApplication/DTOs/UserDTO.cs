using CoursesApp.Domain.Security.RoleAggregate;

namespace CoursesApp.Application.Security.RoleApplication.DTOs;

public class UserDTO
{
    public Guid Id { get; private set; }
    public Guid RoleId { get; private set; }
    public string Code { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Address Address { get; private set; }
    public string Description { get; private set; }
    public UserStatus Status { get; private set; }

    public static UserDTO GetDTO(User user)
    {
        return new UserDTO()
        {
            Id = user.Id,
            RoleId = user.RoleId,
            Code = user.Code,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            Description = user.Description,
            Status = user.Status
        };
    }
}
