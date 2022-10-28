using API.Models;

namespace API.Interfaces;
public interface IUserInfo : IGeneric<UserInfo>
{
    public UserInfo CreateUser(UserInfo userInfo);
    public bool Verify(Guid id, string pass);

    public UserInfo GetUserByEmail(string email);
}


