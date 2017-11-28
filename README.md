## Cake.Deploy.Azure.Authentication ![Build status](https://ci.appveyor.com/api/projects/status/github/ObjectivityLtd/Cake.Deploy.Azure.Authentication?svg=true)
Cake addin for log in to azure active directory in non-interactive mode using organizational credentials or using service principal.

## How to add Cake.Deploy.Azure.Authentication
In order to use it add the following line in your addin section:
```cake
#addin Cake.Deploy.Azure.Authentication
```

## How to use Cake.Deploy.Azure.Authentication

### Login using user credentials: 
```cake
#addin "Cake.Deploy.Azure.Authentication"

var credentials = LoginAzureRM("tenantId", "username", "password");
```
* tenantId - The active directory domain or tenant id to authenticate with.
* username - The organizational account user name, given in the form of a user principal name (e.g. ``user1@contoso.org``).
* password - The organziational account password. 

### Login using service principal:
```cake
#addin "Cake.Deploy.Azure.Authentication"

var credentials = LoginAzure("tenantId", "clientId", "secret");
```
* tenantId - The active directory domain or tenant id to authenticate with.
* clientId - Other names: servicePrincipalId in VSTS, Application ID in Azure Portal.
* secret - Other names: servicePrincipalKey in VSTS, Password in Azure Portal.

Both methods returns a ServiceClientCredentials object that can be used to authenticate http requests.
