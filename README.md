# Reef Tank Tracker Back End
Reef Tank Tracker aims to make logging tank parameters hassle free as well as provide the bigger picture overtime

# Goals for MVP 1

* **Auth Using JWT** - Make sure that the app uses authentication as well as proper user management using Microsoft Identity Framework
* **Multiple Tanks Per User** - A user should be able to own multiple tanks that each have their own idividual history and parameters
* **History Per User And Per Tank** - A user should be able to get history for individual tanks as well as all history pertaining to them
* **Parameters Per User** - User should be able to create and retrieve their own custom parameters
* **Versioning** - Should implement versioning from the begining as this will hopefully serve as a base for automatic logging and automation using an Arduino or similiar hardware.
  
This initial DB design should look something like [this](https://erd.dbdesigner.net/designer/schema/1703784879-reef-tank-tracker-v1)

# Getting Started

1 Clone the repo 

`gh repo clone steveothedev/ReefTankTrackerBackEnd`

2 Add connection string for your DB in appsettings.json

`  "ConnectionStrings": {
    "DefaultConnection": "placeyourconnectionstringhere"
  },`

3 Add your Audience, Issuer and security key in appsetting.json using a secret manager of your choice

`  "Jwt": {
    "Key": "pleasekeepthisinasecretsmanagerthisisjustanexample",
    "Issuer": "yourissuer.com",
    "Audience": "youraudience.com",
  }`

4 In Visual Studio open the Packager Manager Console and create a migration as well as update the database

`Add-Migration InitialMigration`

`update-database`


# License
This project is licensed under the MIT License 
