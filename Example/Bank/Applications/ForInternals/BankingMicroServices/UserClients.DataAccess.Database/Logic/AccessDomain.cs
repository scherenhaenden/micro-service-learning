using AutoMapper;
using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using UserClients.DataAccess.Database.Models.Registration;

namespace UserClients.DataAccess.Database.Logic;

public interface IRegistrationDataAccess
{
    Task<bool> TryRegistration(UserRegistrationModelData request, out UserRegistrationModelData result);

}



public class RegistrationDataAccess: IRegistrationDataAccess
{
    private readonly IUnityOfWork<Customer> _customerUow;
    private readonly IUnityOfWork<Addresses> _addressesUow;
    private readonly IUnityOfWork<CustomerToAccount> _customerToAccountIdUow;
    private readonly IUnityOfWork<CustomerToAddressId> _customerToAddressIdUow;

    public RegistrationDataAccess(
        IUnityOfWork<Customer> customerUow, 
        IUnityOfWork<Addresses> addressesUow,
        IUnityOfWork<CustomerToAccount> customerToAccountIdUow,
        IUnityOfWork<CustomerToAddressId> customerToAddressIdUow
        )


    {
        _customerUow = customerUow;
        _addressesUow = addressesUow;
        _customerToAccountIdUow = customerToAccountIdUow;
        _customerToAddressIdUow = customerToAddressIdUow;
    }
    
    public void AddCustomer(Customer customer)
    {
        _customerUow.Repository.Add(customer);
    }
    
    public void AddAddress(Addresses address)
    {
        _addressesUow.Repository.Add(address);
    }
    
    public void AddCustomerToAccountId(CustomerToAccount customerToAccountId)
    {
        _customerToAccountIdUow.Repository.Add(customerToAccountId);
    }
    
    public void AddCustomerToAddressId(CustomerToAddressId customerToAddressId)
    {
        _customerToAddressIdUow.Repository.Add(customerToAddressId);
    }
    
    public void Commit()
    {
        _customerUow.Save();
    }

    public Task<bool> TryRegistration(UserRegistrationModelData request, out UserRegistrationModelData result)
    {
        
        
        
        
        request.Addresses.Id = Guid.NewGuid();
        request.Addresses.CreatedDateTime = DateTime.Now;
        request.CustomerInput.Id = Guid.NewGuid();
        request.CustomerInput.CreatedDateTime = DateTime.Now;
        
        CustomerToAddressId customerToAddressId = new CustomerToAddressId();
        customerToAddressId.Id = Guid.NewGuid();
        customerToAddressId.CreatedDateTime = DateTime.Now;
        customerToAddressId.CustomerId = request.CustomerInput.Id;
        customerToAddressId.AddressId = request.Addresses.Id;
        
        
        var config = new MapperConfiguration(
            cfg => cfg.CreateMap<Customer, CustomerInput>()
        );
        
        var config2 = new MapperConfiguration(
            cfg => cfg.CreateMap<Addresses, AddressesInput>()
        );
        
        var config3 = new MapperConfiguration(
            cfg => cfg.CreateMap<Customer, CustomerInput>()
        );
        
        
        var mapper = new Mapper(config);
        var customer = mapper.Map<Customer>(request.CustomerInput);
        
        var mapper2 = new Mapper(config2);
        var addresses = mapper2.Map<Addresses>(request.Addresses);
        
        var mapper3 = new Mapper(config3);
        var more = mapper3.Map<Customer>(request.CustomerInput);
        
        AddCustomer(customer);
        AddAddress(addresses);

        result = request;
        
        return Task.FromResult(true);
        
        
        
       
    }
}