# **Callboard**
*Site for posting and viewing ads*

# Deployment of the application

#### Step 1: Deployment of the Database

To deploy the database to the *database* folder, ypu should run a **startup.bat** file. When it will be run, the database will be deployed. However, you need to change the host name and the name of your SQL Server instance in this file. Open the **startup.bat** file and substitute the following data:

```bat
set server="YourHostName\YourSQLServerName"
```

> If SQL authentication is not enabled in your SQL Server, it will be enabled using the script **startup.sql**. In this case, before you start the deployment of the database, change the password of the **sa** (System Administrator) account:

> ```sql
> ALTER LOGIN sa WITH PASSWORD = 'MyVeryStrongPassword1234';
> GO
> ```

#### Step 2: Deployment of the Web Site

To run the site, you need to publish the project **Callboard.App.Web** and run it on IIS.
> I would like to draw your attention to the fact that the site was developed on the .NET Framework 4.6.1 and requires ASP.NET 4.6 support for its operation.

After you run it, you should change the connection string to the database. To do this, go to the **project publishing folder -> bin ->** and find the file **Callboard.App.Data.dll.config**.
Change the host name and the name of your SQL Server instance:

```xml
<connectionStrings>
    <add name="callboardDB"
        connectionString="Data Source=YourHostName\YourSQLServerName;Initial Catalog=callboardDB;Integrated Security=False;Connect Timeout=30;User ID=callboard_admin;Password=1D2F2f3E3asd"
        providerName="System.Data.SqlClient" />
</connectionStrings>
```
After that, the site will be ready to go.

#### Step 3: Deployment of the Commercial Service

Now the site is working, but without ads. If you want to add ads to your site, you need to publish the project **Callboard.Service.Commercial** and also run it on IIS.

After the startup is done, you need to link the service to our site. To do this, go to **the service publishing folder ->** and find the file **Web.config**.
Change the service location port *(default is 4001)*, and also the hostname *(by default localhost)*, if necessary.

```xml
<host>
    <baseAddresses>
        <add baseAddress="http://localhost:4001/Callboard.Service.Commercial.CommercialContract.svc" />
    </baseAddresses>
</host>
```
You also need to change the path to pictures with ads. You can specify the path to any folder with pictures.  To do this, go to **the service publishing folder ->** and find the file **Web.config**. 

```xml
<commercialSettings>
    <pathways>
        <imagePath path="D:\_projects\_callboard\images" />
    </pathways>
</commercialSettings>
```
> In the project folder you can find the *ads_images* folder, where there will be a set of 10 pictures for advertising.

Now you need to change the same data in the configuration files of our site. To do this, go to the **project publishing folder -> bin ->** and find the file **Callboard.App.Data.dll.config**. Change the service location port *(default is 4001)*, and also the hostname *(by default localhost)*, if necessary.

```xml
<client>
    <endpoint address="http://localhost:4001/Callboard.Service.Commercial.CommercialContract.svc" 
    binding="basicHttpBinding" bindingConfiguration="basicHttpFor2MBMessage" 
    contract="CommercialService.ICommercialContract" name="CommercialContractEndpoint" />
</client>
```
Now the site is advertising.