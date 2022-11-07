using AutoMapper;
using UserClients.BusinessLogic.Models.RegistrationDomain;
using UserClients.DataAccess.Core.Registration;
using UserClients.DataAccess.Models.RegistrationDomain;

namespace UserClients.BusinessLogic.Core.Registration;

public interface IRegistrationLogicService
{
    //Task<RegistrationResult> RegisterAsync(RegistrationRequest request);
    Task<bool> TryRegistration(UserRegistrationModelBusinessLogic request, out UserRegistrationModelBusinessLogic result);
}

public class RegistrationLogicService: IRegistrationLogicService
{
    private readonly IRegistrationDataAccessService _registrationDataAccessService;

    public RegistrationLogicService(IRegistrationDataAccessService registrationDataAccessService)
    {
        _registrationDataAccessService = registrationDataAccessService;
    }

    public Task<bool> TryRegistration(UserRegistrationModelBusinessLogic request, out UserRegistrationModelBusinessLogic result)
    {
        
        var config = new MapperConfiguration(
            cfg => 
                cfg.CreateMap<UserRegistrationModelBusinessLogic, UserRegistrationModelDataAccess>().ReverseMap());
        
        var mapper = new Mapper(config);
        var dataAccessModel = mapper.Map<UserRegistrationModelDataAccess>(request);

         _registrationDataAccessService.TryRegistration(dataAccessModel, out var resultDataAccess);
        
        result = mapper.Map<UserRegistrationModelBusinessLogic>(resultDataAccess);
        return Task.FromResult(true);
    }
}