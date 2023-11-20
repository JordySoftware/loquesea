using Common.DomainEvent.Handler;
using CoursesApp.Domain;
using CoursesApp.Domain.Sales.BuyerAggregate;
using CoursesApp.Domain.Security.RoleAggregate.Events;
using CoursesApp.Domain.Service.StudentAggregate;

namespace CoursesApp.Application.Security.RoleApplication.EventHandlers
{
    public class UserFirstNameChangedDomainEventHandler : IDomainEventHandler<UserFirstNameChangedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserFirstNameChangedDomainEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(UserFirstNameChangedDomainEvent handle)
        {
            // Enviar notificaciones
            // Registrar logs

            Buyer buyer = _unitOfWork._buyerRepository.GetById(handle.Id);
            if (buyer != null)
            {
                buyer.ChangeFirstName(handle.FirstName);
                _unitOfWork._buyerRepository.Update(buyer);
                _unitOfWork.Commit(buyer);
                _unitOfWork.Dispose();
            }

            Student student = _unitOfWork._studentRepository.GetById(handle.Id);
            if (student != null)
            {
                student.ChangeFirstName(handle.FirstName);
                _unitOfWork._studentRepository.Update(student);
                _unitOfWork.Commit(student);
                _unitOfWork.Dispose();
            }
        }
    }
}
