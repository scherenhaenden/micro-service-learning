using BankingDataAccess.Core.Configuration;

namespace InternalUsers.DataAccess.Database.Domain;

public interface ILoginDataAccessDataBase
{
    object GetUserInformationByUserNameAndPassword(string userName, string password);
}

public class LoginDataAccessDataBase: ILoginDataAccessDataBase
{
    private readonly IUnitOfWorkV2 _unitOfWork;

    public LoginDataAccessDataBase(IUnitOfWorkV2 unitOfWork)
    {
        _unitOfWork = unitOfWork;
        
    }
    
    public object GetUserInformationByUserNameAndPassword(string userName, string password)
    {
        
        var user = _unitOfWork.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();


        
        

        
        


        return user;
    }
}