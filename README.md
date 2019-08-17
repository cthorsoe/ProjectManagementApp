# ProjectManagementApp

A web app to manage development projects and more from.

# Deploy guide

In order to deploy the project, publish the project from Visual Studio to a local folder on your PC.

After the publish is done, you need to move the published files to the Ubuntu server.

The compiled files for the backend is located at:

ProjectRoot/bin/Release/netcoreapp2.2

These files should be moved to

ServerRoot/var/www/pma/bin/Release/netcoreapp2.2

The compiled files for the frontend is located at:

ProjectRoot/ClientApp/build

These files should be moved to

ServerRoot/var/www/pma/ClientApp/build
