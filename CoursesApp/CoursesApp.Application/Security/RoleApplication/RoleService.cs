using Common.Services;
using CoursesApp.Application.Security.RoleApplication.DTOs;
using CoursesApp.Domain;
using CoursesApp.Domain.Security.RoleAggregate;
using CoursesApp.Infrastructure;
using CoursesApp.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;

namespace CoursesApp.Application.Security.RoleApplication
{
    public class RoleService
    {
        private ILogger _logger;
        private IUnitOfWork _unitOfWork;

        public RoleService(ILogger logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public Task<ServiceResult> Create(string code, string name, string description)
        {
            ValidateRoleUniqueIndex(code, name);
            Role role = Role.CreateNew(code, name, description);
            if (!role.ValidateModel().IsValid)
            {
                return Task.FromResult(new ServiceResult(role.ValidateModel().Errors));
            }

            _unitOfWork._roleRepository.Add(role);
            _unitOfWork.Commit(role);
            _unitOfWork.Dispose();

            return Task.FromResult(new ServiceResult(RoleDTO.GetDTO(role)));
        }

        public Task<ServiceResult> CreateUser(Guid roleId, string code, string firstName, string lastName,
            Address address, string description)
        {
            ValidateUserUniqueIndex(code);
            Role role = _unitOfWork._roleRepository.Find(r => r.Id == roleId);
            if (role == null)
            {
                return Task.FromResult(new ServiceResult(new NullReferenceException("Role not found")));
            }

            role.AddUser(code, firstName, lastName, address, description);
            if (!role.Users[0].ValidateModel().IsValid)
            {
                return Task.FromResult(new ServiceResult(role.Users[0].ValidateModel().Errors));
            }

            _unitOfWork._roleRepository.AddUser(role.Users[0]);
            _unitOfWork.Commit(role);
            _unitOfWork.Dispose();

            return Task.FromResult(new ServiceResult(UserDTO.GetDTO(role.Users[0])));
        }

        public Task<ServiceResult> UpdateUserFirstName(Guid id, string firstName)
        {
            Role role = _unitOfWork._roleRepository.GetByUserId(id);
            if (role == null)
            {
                return Task.FromResult(new ServiceResult(new NullReferenceException("The user does not exist")));
            }

            role.ChangeUserFirstName(id, firstName);
            if (!role.Users[0].ValidateModel().IsValid)
            {
                return Task.FromResult(new ServiceResult(role.Users[0].ValidateModel().Errors));
            }

            _unitOfWork._roleRepository.Update(role);
            _unitOfWork.Commit(role);
            _unitOfWork.Dispose();

            return Task.FromResult(new ServiceResult(UserDTO.GetDTO(role.Users[0])));
        }

        #region Private Methods

        private void ValidateRoleUniqueIndex(string code, string name)
        {
            Role role = _unitOfWork._roleRepository.Find(e => e.Code == code);
            if (role != null)
            {
                throw new InvalidOperationException("The role code already exist");
            }

            role = _unitOfWork._roleRepository.Find(e => e.Name == name);
            if (role != null)
            {
                throw new InvalidOperationException("The role name already exist");
            }
        }

        private void ValidateUserUniqueIndex(string code)
        {
            Role role = _unitOfWork._roleRepository.GetByUserCode(code);
            if (role != null)
            {
                throw new RepeatedUniqueIndexException("The user code already exist");
            }
        }

        #endregion
    }
}
