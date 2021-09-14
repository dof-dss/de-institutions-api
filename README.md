| Builds  | Branch | Status 
| ------------- | -----  |--------
| Circle CI  | main   |[![CircleCI](https://circleci.com/gh/dof-dss/de-institutions-api/tree/main.svg?style=svg&circle-token=20f739957862b69dfb3b2e12a9fec6aef0194bc6)](https://circleci.com/gh/dof-dss/de-institutions-api/tree/main)
| SonarCloud  | main   | [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=dof-dss_de-institutions-api&metric=alert_status)](https://sonarcloud.io/dashboard?id=dof-dss_de-institutions-api)

# de-institutions-api
Api to provide details of institutions and schools in Northern Ireland

# Access
You will need to contact the team to get an api key and secret to allow your application to consume this api.

## Contents of this file

- [Contributing](#contributing)
- [Licensing](#licensing)
- [Project Documentation](#project-documentation)
    - [Why did we build this project](#why-did-we-build-this-project)
    - [What problem was it solving](#what-problem-was-it-solving)
    - [How did we do it](#how-did-we-do-it)
    - [Future Plans](#future-plans)
    - [Deployment Guide](#deployment-guide)

## Contributing

Contributions are welcomed! Read the [Contributing Guide](./docs/contributing/Index.md) for more information.

## Licensing

Unless stated otherwise, the codebase is released under the MIT License. This covers both the codebase and any sample code in the documentation. The documentation is © Crown copyright and available under the terms of the Open Government 3.0 licence.

## Project Documentation

### Why did we build this project?

We built this api so many applications and users can have access to a list of schools and institutions in Northern Ireland.

### What problem was it solving?

This solves having to create a school table in every single application and adding the same code over and over again.

### How did we do it?

This is a dotnet core application which uses Mysql to store the school data, Entity Framework for data access and JWT to authenticate applications to allow them to use the api.
We have hosted this in the Gov UK PaaS Cloud foundry platform using Circle CI to deploy. This uses Swagger as a handy UI.

### Future plans

We may introduce a more advanced search if needed.

### Deployment guide

To run the databases you need mysql installed. Then run the below commands to set up the database:

- update-database

Restore the nuget package. Then to build run "dotnet build" in command line then dotnet run to run the site.

### Endpoints

GETS

/api/v1/Institution/GetAll - This gets all the institutions by using paging so you can select how many pages and per page you want

/api/v1/Institution/GetByReferenceNumber - Gets institution by its reference number

/api/v1/Institution/SearchByName - Gets Institution by name

/api/v1/Institution/SearchSchoolByName - Gets School (primary, post primary, grammar etc) by name

/api/v1/Institution/GetSchoolByReferenceNumber - Gets school (primary, post primary, grammar etc) by reference number

POST - TBA

PUT - TBA

DELETE - TBA



