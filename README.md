Application Description:
The developed application is a .NET 7 WebAPI designed to efficiently process and transform data collected from a public API into a usable format for further representation. The app allows users to interact with its endpoints via Swagger UI, providing a user-friendly interface. The primary purpose of this application is to fetch data from a public API in JSON format, presenting a list of countries with associated information. The app implements filtering, sorting, and pagination functionalities that enable users to consume only the necessary data in selected amounts based on specific criteria.
The API endpoint exposed by the application accepts four optional parameters: country (string), population (int), countrySort (string), and numberOfRecords (int). The country parameter filters the countries based on their names, the population parameter filters the countries based on their population size, and the countrySort parameter allows users to sort the countries in ascending or descending order based on specific attributes. The numberOfRecords parameter controls the pagination, specifying how many countries to include in a single page of results.

Running the Developed Application Locally:

To run the developed application locally, follow these steps:
Clone or download the application repository to your local machine.
Ensure you have .NET 7 SDK and the necessary dependencies installed.
Navigate to the root directory of the application in your terminal or command prompt.
Run the following command to build the application: dotnet build.
Run the application using the following command: dotnet run.
Once the application is running, you can access the Swagger UI interface by opening a web browser and navigating to http://localhost:<PORT>/swagger, where <PORT> is the port number on which the application is running (typically 5000).

Examples of How to Use the Developed Endpoint:

•	Fetch all countries: GET /api/countries
•	Fetch countries with the name containing "United": GET /api/countries?country=United
•	Fetch countries with a population greater than 100 million: GET /api/countries?population=100
•	Fetch countries sorted by their names in ascending order: GET /api/countries?countrySort=ascend
•	Fetch countries sorted by their population in descending order: GET /api/countries?countrySort=descend
•	Fetch the first 10 countries: GET /api/countries?numberOfRecords=10
•	Fetch countries named "Germany" with a population less than 100 million: GET /api/countries?country=Germany&population=100
•	Fetch the top 5 most populous countries: GET /api/countries?countrySort=descend&numberOfRecords=5
•	Fetch countries with a population less than 1 million, sorted by name in ascending order: GET /api/countries?population=-1&countrySort=asc
