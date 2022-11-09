using InternalUsers.DataAccess.Database.Domain;

namespace InternalUsers.DataAccess.Core;

public interface ILoginDataAccess
{
    object GetUserInformationByUserNameAndPassword(string userName, string password);
}

public class LoginDataAccess: ILoginDataAccess
{
    private readonly ILoginDataAccessDataBase _loginDataAccessDataBase;


    public LoginDataAccess(ILoginDataAccessDataBase loginDataAccessDataBase)
    {
        _loginDataAccessDataBase = loginDataAccessDataBase;
    }
            
    
    
    public object GetUserInformationByUserNameAndPassword(string userName, string password)
    {
        return _loginDataAccessDataBase.GetUserInformationByUserNameAndPassword(userName, password);
    }
}