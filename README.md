"# OnboardingAssignment"

This is a web application I created using ASP.NET Core 2.0 and React.js with the help of Entity Framework Core code first approach. We will be creating a sample Store Record Management system and perform CRUD operations on it. To read the inputs from the user, we are using HTML Form element with required field validations on the client side.

It was built using Visual Studio 2019 and SQL Server 2018. It only works with SDK 2.2

How to create your database:
step1: Go to Model : ECCoreWarehouseDBContext.cs step2: Look for optionsBuilder and replace XXXX with your connection string. ==> for example, your connection string is DESKTOP-ABCD/SQLEXPRESS. optionsBuilder.UseSqlServer(@"Server=DESKTOP-ABCD/SQLEXPRESS; Database=EFCoreWarehouseDb; Trusted_Connection=True;");

===> you can also set it to optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False .....) if you are using Integrated security or persist security....

New Migration:

Open Package manager console.
add-migration EFCoreWarehouseDB
update-database