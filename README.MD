# Movie Database

![Build](https://img.shields.io/github/workflow/status/NMC-CIT255-Master-Detail/MovieDatabase/.NET%20Core) ![CodeQL](https://github.com/NMC-CIT255-Master-Detail/MovieDatabase/workflows/CodeQL/badge.svg?branch=master) ![Size](https://img.shields.io/github/repo-size/NMC-CIT255-Master-Detail/MovieDatabase) 
![License](https://img.shields.io/github/license/NMC-CIT255-Master-Detail/MovieDatabase) ![Last Commit](https://img.shields.io/github/last-commit/NMC-CIT255-Master-Detail/MovieDatabase) 

### Welcome 

Welcome to our application for NMC's CIT255 Object Oriented Programming class
This project has been broken out into many different sprints. There are 4 sprints in total and this is a group project.

### App Requirements

The goal and requirements for the application are to create a Master Detail application with basic CRUD operations.
The user should be able to view a master list of the items, select items, and edit or delete those items.
The user should also be able to add items as well. The user can also search for, filter, and sort items in the master list as well.

Since the backend will be shared between team members with the same persistance, each team member must make a different front end and tie to the backend.
Since each developer has to have a different front end, the application needs to have a way to switch between the two various "applications" to view.

For persitence, any option can be used such as json, xml, SQL server, MySQL, MongoDB, etc. For this application we opted for MySQL hosted on a remote server.

EntityFramwork will also be used to help facilitate this connection and the repositories for the DAL and final persistance. 

No other requirements were laid out, outside of making sure the application looks and feels cohesive, input and actions are properly error checked and handled, etc.

For this, we decided on a movie database with a GUI front end built in .NET Core 3.1 and EF. 

# Application Description

### Application Overview

The application for the Master/Detail app described in this Project Notebook will be for a Movie Database. This movie database will house several different views for items such as Movies, Producers, and even Studios. On the HomeView, users will be greeted with a “split” screen of sorts that will allow them to view a Master list on the left hand side, and a Detail view on the right hand side. Starting with the left side of the MainView, users will be greeted with a file menu, a title, and the Search, Filter, Sort section. This section will allow users to sort the Master list by searching for a movie by name, producer, or studio. Upon hitting search, this will update the Master list with the requested data. Beneath the search functionality, the users will have the option to filter the Master list by the length of the movie using a range from min to max in minutes. The final option will be the ability to sort the Master list by Producer, Studio, or Year released. 

Beneath the search, filter, and sort functionality, you will see a List view of the movies in the database. This list view will show a small thumbnail image next to the movie’s title and year. Beneath the title and year, there will be 3 buttons. The buttons will say View, Edit, and Delete. These will be the same for all items in the list view and listed for each individual movie. 

Upon clicking on the view button, the movie's information will be displayed on the right hand side of the window. This will include a larger image of the movie, the title, year, release date, runtime, description and Producer and Studio information. Below this information will be an edit button that will appear as well which will allow the user to quickly edit the movie that has been loaded along with buttons or icons next to the Producer and Studio field that will allow editing of that information as well.

To add a movie, studio, or producer, there will be a file menu option to do so at the top of the screen. We opted for this to declutter the buttons on the MainView and keep it in a central location across multiple views. 

To edit the Producer or Studio information without needing to select a movie first, there will be an option to swap the datacontext for the user control on the MainView to retrieve the list of each respectively. This should allow us to use one MainView and to swap viewmodels and datacontexts out as needed for databinding. Doing this will show the appropriate CRUD operation buttons needed to edit Studio and Producer data. 

There will be confirmation boxes for adding, editing/updating, and deleting items from the database. These will be generic, but will be injected with the proper information needed to display them as though they were separate dialogues that pop up for each of the actions.

### Domain Overview

The data set used for this application is rather simple. These, so far, are just simple POCO/Domain Object classes. We have a Movie class, Studio class, and Producer class. There is also a Domain Object class that just houses an Id field that all of the other classes inherit from. This is important to ensure that there is an Id field to use with the service layer for getting, updating, and deleting entities and tracking them.

The Movie class has the following auto properties: Id, title, description, release date, runtime, image, IMDB link, Producer, and Studio. 
The Studio class has the following auto-properties: Id, name, phone, email, website, description, address, city, state, zipcode.
The Producer class has the following auto-properties: Id, name, date of birth (DOB), and biography.
The DomainObject class has just the Id auto-property.

There is also an interface called IDataService implemented here as well so far for DI later on, and for creating a generic CRUD repository in the DAL that will take T where T : DomainObject.
There will be more added later, but for now that is what we have set up at the moment. 

### DAL and Service layer Overview

Regarding the database for the application, this will be handled by Entity Framework Core and a remote MySQL server hosted on my web host. The main project is .NET Core 3 as well. With EF Core, we will use a DBContextFactory to build the DBContexts for the various CRUD operations against a generic data service in the DAL and Service layer. This will also be useful if we decide to switch to Tasks and async various CRUD operations for an API (like IMDB) in the future. There is a lot more to add in for the dependency injection stuff, but I haven’t gotten that far yet, and don’t have any of it skeletonized out. So far though, migrations are working as intended, the generic repository against the database is working as expected, and entities are returned from these functions back to the caller which will be used to create the ViewModels as needed and pass through the bound data requested. 

### Presentation Overview

The Presentation layer will be the general WPF stuff. Views and ViewModels. The Domain aspect normally put here like we have with past projects has been split into its own project for better decoupling and organization. This layer will heavily rely on the dependency injection to get what it needs and to build the ViewModels needed for the views. This is also where the Resource Dictionaries, UserControls, and DataContexts will reside (in this project). There will be a lot added here over the other assemblies in this solution, but we will update with that information as needed as the sprints progress. 

# Contributing

TBA

# Running the Application

TBA

# Project Links

**Discord:** https://discord.gg/dDMmDEA

**Trello Sprint 1:** https://trello.com/b/V8tOfAY6/power-squad-sprint-1

**Trello Sprint 2:** https://trello.com/b/fB4pNtOR/power-squad-sprint-2 

**Trello Sprint 3:** https://trello.com/b/f7s8NYPY/power-squad-sprint-3

**GitHub Repo:** https://github.com/NMC-CIT255-Master-Detail/MovieDatabase

**Application Website:** https://nmc-cit255-master-detail.github.io/MovieDatabase/

