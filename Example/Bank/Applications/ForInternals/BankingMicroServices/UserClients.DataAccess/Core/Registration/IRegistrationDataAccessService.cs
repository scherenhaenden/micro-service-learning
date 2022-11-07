using AutoMapper;
using UserClients.DataAccess.Database.Logic;
using UserClients.DataAccess.Database.Models.Registration;
using UserClients.DataAccess.Models.RegistrationDomain;

namespace UserClients.DataAccess.Core.Registration;

public interface IRegistrationDataAccessService
{
    Task<bool> TryRegistration(UserRegistrationModelDataAccess request, out UserRegistrationModelDataAccess result);
}

public class RegistrationDataAccessService: IRegistrationDataAccessService
{
    private readonly IRegistrationDataAccess _registrationDataAccess;

    public RegistrationDataAccessService(IRegistrationDataAccess registrationDataAccess)
    {
        _registrationDataAccess = registrationDataAccess;
    }
  
    
    public Task<bool> TryRegistration(UserRegistrationModelDataAccess request, out UserRegistrationModelDataAccess result)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<UserRegistrationModelDataAccess, UserRegistrationModelData>());
        
        var mapper = new Mapper(config);
        var dataAccessModel = mapper.Map<UserRegistrationModelData>(request);

        _registrationDataAccess.TryRegistration(dataAccessModel, out var resultDataAccess);
        
        result = mapper.Map<UserRegistrationModelDataAccess>(resultDataAccess);
        return Task.FromResult(true);
    }
}