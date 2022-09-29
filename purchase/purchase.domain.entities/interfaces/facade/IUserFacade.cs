using purchase.domain.entities.dtos;

namespace purchase.domain.entities.interfaces.facade
{
    public interface IUserFacade
    {
        UserResponse UserById(int id);
    }
}
