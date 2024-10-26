# EventCalendar
This is a project that was written for a preinterview task for a company. This project should be able to run on Visual Studio 2022, as long as Microsoft.Data.Sqlite is installed from the Extensions in Visual Studio.

## Design Demonstration
The design  for this project comprises of multiple aspects - as this is both a frontend and backend project. In short, the project demonstrates the following skills:
- knowledge of ASP.NET - demonstrated through technology used for the project - ASP.NET MVC
- knowledge of basic coding languages - including C#, HTML5 Javacsript - demonstrated through writing HTML forms, C# code for the controllers, and Javascript for the client side validation
- knowledge of .NET framework - demonstrated through technology used 
- knowledge of databases and OS   - demonstrated through use of SQL to store data of events
- familiarity with web services - demonstrated through setting up MVC pattern to handle requests - could perhaps be decopulated further through a microservice implementation instead of MVC
- knowledge of Git - demonstrated through the repo commits - may have been better to use branches for development of features so that they could be merged back into the main.
- JQuery - demonstrated through client side validation code that will prevent submission of form if found to be invalid
- CSS - as this is demonstrated through custom CSS built for the application to give it a responsive design and feel

## Design Rationale
This section details the rationale for each part of the application. This includes the following:
- Frontend Design
    - Styling - the styling used flexbox in order to ensure that the app was responsive for users
    - HTML - the HTML is basic, it could be further improved via using semantic HTML which can improve SEO 
    - Javascript - was mainly used for client side validation to ensure that any data sent to the serverside would be 
- Backend Design
    - ASP.NET - used as it comprised part of the techstack for the company, but also it's class based interface allows for reusability of components
    - MVC Pattern - the MVC pattern is used to allow for separataion of concerns, making the project more maintainable than if it was page based
- Database Design
    - Events Table - simplistic table as the data requirements were not too strenous and would normally expect a low volume of data rather than a higher volume
- Maintenance
    - Documentation - documentation could be further improved via incorporating docstrings - was not included here as I wanted to get this in early