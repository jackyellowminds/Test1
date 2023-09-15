---
Problem Statement: Online Reservation API
You need to develop an online reservation system with API's that allow users to browse menu, make reservation, and order food from tables. The API should be designed using Web API Core and MVC Core for the back-end and SQL Server as the database.

Frontend:
The Frontend is built in Angular. 

Get Table: Get a list of all tables in the TableTB table of database BookingDB
Delete Table: Delete record in the TableTB table of database BookingDB
Save Table: Save and update record in the TableTB table of database BookingDB
Get Menu: Get a list of all Menus in the MenuTB table of database BookingDB
Delete Menu: Delete record in the MenuTB table of database BookingDB
Add Menu: Save and update record in the MenuTB table of database BookingDB
Get Reservation with Tables: Get a list of all reservation in the ReservationTB table of database BookingDB
Delete Reservation: Delete record in the ReservationTB table of database BookingDB
Add Reservation: Save and update record in the ReservationTB table of database BookingDB
Cancel Reservation: Cancel reservation in the ReservationTB table of database BookingDB
Orders: Get a list of all orders in the OrdersTB table of database BookingDB
Delete Order: Delete record in the OrdersTB table of database BookingDB
Add Orders: Save and update record in the OrdersTB table of database BookingDB
Login: Validate the user credentials from UsersTB table of database BookingDB
Register user: Add a new user to the UsersTB table of database BookingDB

Your task is to complete the following file:
1. Src/App/Services/http.service.ts:

Backend
The Backend of this project is built using ASP .NET CORE Web API and MS SQL.

You will need to complete the following files:

1. ../dotNetApi/RBookingWebApi/Controllers/LoginController.cs: This controller allows you to authenticate user during login and register a new user.
2. ../dotNetApi/RBookingWebApi/Controllers/TableController.cs: This controller allows you to Add/Remove records and return a list of all Tables in TableTB table of the database BookingDB.
3../dotNetApi/RBookingWebApi/Controllers/OrderController.cs: This controller allows you to Save order, Update and Delete orders.
4.../dotNetApi/RBookingWebApi/Controllers/MenuController.cs: This controller allows you to Save order, Update and Delete menu
5.../dotNetApi/RBookingWebApi/Controllers/ReservationController.cs: This controller allows you to Save Reservation, Update and Delete reservations

Notes:
1. Do not change the function names and method types provided for you in the Reports.js, just fill them with the correct implementation. These will be 2. imported and used for your evaluation.
3. Implementation-related specifics are added directly as comments in the workspace.
4. Ensure that the structure and datatype of the components are followed as specified in the comments to ensure that the code is evaluated correctly.
5. There is no need to write code to style this application.
6. The database is named BookingDB and the relevant connection details are already given to you in the workspace.

Testing & Submitting your code:

Step 1: Click on the WeCP Projects Button.
Step 2: Click on the start server button to start the server.
Step 3: Click on the Browser Preview button to see the GUI
Step 4: You can click Api Testing via swagger button to test the API's using custom requests.
Step 5: You can test your code by clicking on Test and Submit button. 
Step 6: You will get a congratulations message upon successful completion of the task.
