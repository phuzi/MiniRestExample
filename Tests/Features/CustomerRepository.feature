Feature: CustomerRepository

Customer repository adding and rereiving customer data

Link to a feature: [Calculator](Tests/Features/CustomerRepository.feature)

@AddACustomer
Scenario: Add a customer to the repository
  Given The following customer is added to the repository:
    | Field        | Value                                |
    | CustomerRef  | 69141d84-f724-4350-b508-8530f54faf42 |
    | CustomerName | Major Tom                            |
    | AddressLine1 | Ground Control                       |
    | AddressLine2 |                                      |
    | Town         | Some Town                            |
    | County       | Some County                          |
    | Country      | Some Country                         |
    | Postcode     | A1 1AA                               |
  Then 1 customer will be added to the database context
  And The following customer will be added to the database context:
    | Field        | Value                                |
    | CustomerRef  | 69141d84-f724-4350-b508-8530f54faf42 |
    | CustomerName | Major Tom                            |
    | AddressLine1 | Ground Control                       |
    | AddressLine2 |                                      |
    | Town         | Some Town                            |
    | County       | Some County                          |
    | Country      | Some Country                         |
    | Postcode     | A1 1AA                               |
  And The changes are saved


Scenario: Adding a customer passes the cancellation token to the database context
  Given A cancellation token is passed when adding a customer
  And A customer is added to the repository
  Then The cancellation token is passed to AddAsync

@RetrieveACustomer
Scenario: Retrieve a single customer
  Given The following customer exists in the database:
    | Field        | Value                                |
    | CustomerRef  | ede208e7-a176-4c5d-ac7f-b41473048a1e |
    | CustomerName | Name 3                               |
    | AddressLine1 | AddressLine1 3                       |
    | AddressLine2 | AddressLine2 3                       |
    | Town         | Some Town 3                          |
    | County       | Some County 3                        |
    | Country      | Some Country 3                       |
    | Postcode     | A1 1AA 3                             |
  When A customer with customerRef {ede208e7-a176-4c5d-ac7f-b41473048a1e} is requested
  Then The following customer is returned:
    | Field        | Value                                |
    | CustomerRef  | ede208e7-a176-4c5d-ac7f-b41473048a1e |
    | CustomerName | Name 3                               |
    | AddressLine1 | AddressLine1 3                       |
    | AddressLine2 | AddressLine2 3                       |
    | Town         | Some Town 3                          |
    | County       | Some County 3                        |
    | Country      | Some Country 3                       |
    | Postcode     | A1 1AA 3                             |

Scenario: Attempt to retrieve a non-existant customer
  Given The following customer exists in the database:
    | Field        | Value                                |
    | CustomerRef  | ede208e7-a176-4c5d-ac7f-b41473048a1e |
    | CustomerName | Name 3                               |
    | AddressLine1 | AddressLine1 3                       |
    | AddressLine2 | AddressLine2 3                       |
    | Town         | Some Town 3                          |
    | County       | Some County 3                        |
    | Country      | Some Country 3                       |
    | Postcode     | A1 1AA 3                             |
  When A customer with customerRef {3f24b829-1f04-4c36-b2b2-cbcbeb351d69} is requested
  Then A null is returned

Scenario: Retrieving a customer passes the cancellation token to the database context
  Given A cancellation token is passed when retrieving a customer
  When A customer is requested from the repository
  Then The cancellation token is passed to FindAsync
