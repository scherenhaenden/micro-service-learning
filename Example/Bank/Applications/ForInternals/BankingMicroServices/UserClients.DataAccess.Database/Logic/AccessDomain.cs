using AutoMapper;
using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using Newtonsoft.Json;
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
    private readonly IUnityOfWork<CustomerToBankAccount> _customerToAccountIdUow;
    private readonly IUnityOfWork<CustomersToAddresses> _customerToAddressIdUow;

    public RegistrationDataAccess(
        IUnityOfWork<Customer> customerUow, 
        IUnityOfWork<Addresses> addressesUow,
        IUnityOfWork<CustomerToBankAccount> customerToAccountIdUow,
        IUnityOfWork<CustomersToAddresses> customerToAddressIdUow
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
    
    public void AddCustomerToAccountId(CustomerToBankAccount customerToBankAccountId)
    {
        _customerToAccountIdUow.Repository.Add(customerToBankAccountId);
    }
    
    public void AddCustomerToAddressId(CustomersToAddresses customersToAddresses)
    {
        _customerToAddressIdUow.Repository.Add(customersToAddresses);
    }
    
    public void Commit()
    {
        _customerUow.Save();
    }

    public Task<bool> TryRegistration(UserRegistrationModelData request, out UserRegistrationModelData result)
    {
        
        
        
        
        request.Addresses.Id = Guid.NewGuid();
        request.Addresses.CreatedDateTime = DateTime.Now;
        request.Customer.Id = Guid.NewGuid();
        request.Customer.CreatedDateTime = DateTime.Now;
        
        CustomersToAddresses customersToAddresses = new CustomersToAddresses();
        customersToAddresses.Id = Guid.NewGuid();
        customersToAddresses.CreatedDateTime = DateTime.Now;
        customersToAddresses.CustomerId = request.Customer.Id;
        customersToAddresses.AddressId = request.Addresses.Id;
        
        
        /*var config = new MapperConfiguration(
            cfg => cfg.CreateMap<Customer, CustomerInput>()
        );
        
        var config2 = new MapperConfiguration(
            cfg => cfg.CreateMap<Addresses, AddressesInput>()
        );
        
        var config3 = new MapperConfiguration(
            cfg => cfg.CreateMap<Customer, CustomerInput>()
        );
        
        
        var mapper = new Mapper(config);
        var customer = mapper.Map<Customer>(request.Customer);
        
        var mapper2 = new Mapper(config2);
        var addresses = mapper2.Map<Addresses>(request.Addresses);
        
        var mapper3 = new Mapper(config3);
        var more = mapper3.Map<Customer>(request.Customer);*/
        
        // Convert Object to Entity using json
        var customer = JsonConvert.DeserializeObject<Customer>(JsonConvert.SerializeObject(request.Customer));
        
        var addresses = JsonConvert.DeserializeObject<Addresses>(JsonConvert.SerializeObject(request.Addresses));
        
        
        AddCustomer(customer);
        AddAddress(addresses);
        
        AddCustomerToAddressId(customersToAddresses);

        result = request;
        
        return Task.FromResult(true);
        
        
        
       
    }
}