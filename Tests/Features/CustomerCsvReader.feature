Feature: Customer CSV Reader

Customer CSV loading and parsing

Link to a feature: [Customer CSV Reader](Tests/Features/CustomerCsvReader.feature)

Scenario: Throw FileNotFoundException if file doesn't exist
  Given A non-existent file
  When The file is loaded
  Then A FileNotFoundException should be thrown

Scenario: The upload file is empty 
  Given An empty file
  When The file is loaded
  Then An Exception is thrown
  And The exception message is "Unable to process an empty file"

Scenario: The upload file has an invalid header
  Given An invalid csv
  When The file is loaded
  Then An Exception is thrown
  And The exception message starts with "Unable to process CSV. The file does not have valid headers."

  Scenario: Ensure customer ref is a valid GUID/UUID
  Given A csv containing a customer ref with invalid GUID value
  When The file is loaded
  Then An Exception is thrown
  And The exception message starts with "Invalid CustomerRef on row 1: 'Not a GUID'"

Scenario: Ensure customer ref has a non-default GUID value
  Given A csv containing a customer ref with a default GUID value
  When The file is loaded
  Then An Exception is thrown
  And The exception message starts with "Invalid CustomerRef on row 1: '00000000-0000-0000-0000-000000000000'"

Scenario: The upload file is valid
  Given A valid csv
  When The file is loaded
  Then The following customer records should be returned:
    | CustomerRef                          | CustomerName | AddressLine1   | AddressLine2   | Town        | County         | Country        | Postcode |
    | e840fba7-768d-46cd-a309-e3405dc5fae0 | Bruce Wayne  | Wayne Manor    |                | Gotham City | West Yorkshire | United Kingdon | A1 1AA   |
    | 83654fe7-1a05-4044-aa54-483771181ce9 | Eric Wimp    | 29 Acacia Road | Somewhere Else | Nuttytown   | West Yorkshire | United Kingdon | A1 1AA   |
