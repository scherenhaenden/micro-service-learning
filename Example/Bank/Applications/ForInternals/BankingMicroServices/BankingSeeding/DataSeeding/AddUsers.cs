using System.Security.Cryptography;
using BankingDataAccess.Core.Domain;
using GenericTools.Security.Core;
using GenericTools.Security.Persistance;

namespace BankingSeeding.DataSeeding;

public class AddUsers
{
    // Create a new user manager

    public List<Users> GetUsers()
    {
        // init Cryptographic Service Provider
        //var csp = new RSACryptoServiceProvider(2048);
        //var publicKey = csp.ToXmlString(false);
        //var privateKey = csp.ToXmlString(true);
        
        ISimpleEncryptionService encryptionService = new SimpleEncryptionServiceMd5();
        
        
        
        var listOfUsers = new List<Users>();
        
        
        var userAdmin = new Users();
        userAdmin.UserName = "admin";
        userAdmin.Password = encryptionService.EncryptValue("admin");
        userAdmin.Email = "";
        userAdmin.FirstName = "Admin";
        userAdmin.LastName = "Admin";
        userAdmin.IsActive = true;
        
        
        listOfUsers.Add(userAdmin);
        
        return listOfUsers;
    }
    
    
    // Create a new roles
    public List<Roles> GetRoles()
    {
        var listOfRoles = new List<Roles>();
        
        var roleAdmin = new Roles();
        roleAdmin.RoleName = "Admin";
        roleAdmin.Description = "Admin";
        roleAdmin.IsActive = true;
        
        listOfRoles.Add(roleAdmin);
        return listOfRoles;
    }
    
    // Create new Tokens
    public List<Tokens> GetTokens()
    {
        var listOfTokens = new List<Tokens>();
        var tokenAdmin = new Tokens();
        tokenAdmin.Token = "TKA_ADMIN";
        tokenAdmin.TokenName = "Admin";
        tokenAdmin.Description = "Admin";
        tokenAdmin.IsActive = true;
        listOfTokens.Add(tokenAdmin);
        return listOfTokens;
    }


}