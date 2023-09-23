# Test C# Application

## Brief

We will need a new Java app to read in a CSV file from a directory. The contents will then need to be
sent to a REST API endpoint, in JSON format, and saved to a SQL database.

  1. Create a console app to read in a CSV file from a directory.
  2. Parse the CSV file of which the contents are:
    - Customer Ref
    - Customer Name
    - Address Line 1
    - Address Line 2
    - Town
    - County
    - Country
    - Postcode
  3. Loop through the rows of the CSV file and send each row to a REST API POST endpoint, in JSON format.
  4. The REST API should then save the content to a database table. Format can match the CSV file.
  5. Create a REST API GET endpoint to retrieve the customer information, passing in a customer ref to filter the data. Contents should be returned in JSON format.
  6. Some documentation or Wiki to explain the approach taken.

Where possible, a Test-Driven Development (TDD) approach should be taken.

## Approach

There are 2 applications required to fulfill the brief:
  1. Console app  
  1. REST API 

There will 2 other projects as part of the solution:
  1. Common - A project containing models that will be used in both applications.
  2. Tests - A project containing tests, testing various aspects of both applications.

### Console app
This will read a local .csv file, parse it checking for required fields and format. The parsed data will then be uploaded row-by-row to the API.

This application will be developed using a Test-Driven approach using Specflow for Behaviour Driven Development in several stages.

  1. Load and parse the CSV
  2. Authenticate with the API using a Client ID and secret taken from config/environment.
  3. Iterate over each row of data uploading each row, one by one, to the REST API.

### REST API
The REST API will have 3 endpoints and will use OpenAPI to self-document the API and assist future development.

#### Endpoints
  - /auth - GET
  - /customer - POST
  - /customer/{customerRef} - GET

To use the customer API, will require that requests are authenticated using a bearer token obtained from the `/auth` endpoint.

## Considerations and Assumptions

For the purposes of this exercise, credentials will be taken from application configuration/environment variables rather than being stored on an application by application basis in a database or other data store.

Data types for the CSV fields are assumed to be strings with the excpetion of the customer ref field, which will use GUID/UUID to prevent easy enumeration of customer data.

All fields except Address Line 2 will be required

Customer data will not be normalised and addresses will be stored alongside their name and customer ref.