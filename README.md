# RDV-Backend

This is a application for reserving appointment, RDV(rendez-vous) in french means appointment. It is developed with the framework of .Net Core 6

## How to use

It should be used with a database SQL Serve, which can be download https://hub.docker.com/repository/docker/lacroquette/my-sqlserver-image/general

And the Frontend https://github.com/la-croquette/RDV-Frontend ,which is developed with the framework of Angular 14

If you want to use it with the backend, which I have created, you need to change the password as the Mypassword in the RDV-Backend/app.config
 <?xml version="1.0" encoding="utf-8" ?>
<configuration>
     <connectionStrings>
      <add name="RDV-Database" connectionString="Server=localhost;Database=RDV_Database;User Id=sa;Password=Nznznz123.;" providerName="System.Data.SqlClient"/>
  </connectionStrings>
</configuration>