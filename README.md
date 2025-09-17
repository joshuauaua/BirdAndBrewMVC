<img width="1920" height="935" alt="Screenshot 2025-09-17 at 21 51 55" src="https://github.com/user-attachments/assets/2ec01747-2fd3-483c-8e6d-04a7e02405da" />

Bird & Brew – ASP.NET MVC Frontend

This is a school project built with ASP.NET MVC as part of my coursework. The application serves as the public website for a fictional restaurant called Bird & Brew, specializing in humble chicken sandwiches and good craft beer.

The MVC app is designed to connect to a separate ASP.NET Web API project (link will be added here), which provides all the data and handles authentication.

⸻

✨ Features

🏠 Landing Page (Home)
	•	Welcomes visitors with a short introduction to the restaurant.
	•	Highlights popular menu items, including name, description, price, and optional images.
	•	Includes links to the Menu and Booking pages.

📜 Menu Page
	•	Displays all dishes dynamically by consuming the connected Web API.
	•	Shows dish details (name, description, price, and optional image).
	•	Clean, attractive presentation styled with Bootstrap, matching the Bird & Brew theme.

🖥️ Admin Interface
	•	Provides CRUD operations for restaurant data:
	•	Manage bookings.
	•	Add, edit, and delete menu items.
	•	Manage tables.
	•	Secured with authentication and authorization.

🔒 Authentication
	•	JWT-based login integrated with the Web API.
	•	Administrators must be logged in to access the admin area.
	•	If a JWT is missing or invalid, restricted pages are inaccessible.

🌐 SEO Optimization
	•	Meta tags added for better discoverability.
	•	Clean URL structure.
	•	Image optimizations for faster loading.

🎨 UI/UX
	•	Responsive design using Bootstrap.
	•	Layout works across desktop and mobile devices.
	•	Consistent styling reflecting the Bird & Brew brand.


 🚀 How to Run the Project
	1.	Clone the repository
 	2.	Open in Rider or Visual Studio
	•	Ensure you have the .NET 8 SDK (or beyond) installed.
 	3.	Restore dependencies 
  4.	Set up the Web API
	•	This MVC frontend requires the Bird & Brew Web API project running in the background. Find it here: https://github.com/joshuauaua/BirdAndBrew
 	5.	Run the MVC project. The app will be available at https://localhost:5001 or similar, depending on your setup.

  📂 Tech Stack
	•	ASP.NET MVC
	•	Bootstrap 5 for responsive design
	•	Entity Framework Core (via API backend)
	•	JWT Authentication
	•	SEO and analytics setup


  




<img width="1905" height="967" alt="Screenshot 2025-09-17 at 21 52 13" src="https://github.com/user-attachments/assets/f34ea537-4fa2-4aea-9c7b-fe90f5283534" />
<img width="1906" height="966" alt="Screenshot 2025-09-17 at 21 52 27" src="https://github.com/user-attachments/assets/c774433b-5d22-4527-b982-53392de03edf" />
