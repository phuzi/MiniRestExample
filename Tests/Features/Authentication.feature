Feature: Authentication

Rudimentary authentication and JWT bearer token generation.

Link to a feature: [Authentication](Tests/Features/Authentication.feature)

@CredentialValidation
Scenario: Valid credentials results in a bearer token
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  When The client Id "client_id" and client secret "client_secret" are used to authenticate
  Then A bearer token should be returned

Scenario Outline: Invalid credentials results in an AuthenticationFailedException
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  When The client Id "<ClientId>" and client secret "<ClientSecret>" are used to authenticate
  Then An AuthenticationFailedException should be thrown

  Examples: 
    | ClientId        | ClientSecret        |
    | client_id_wrong | client_secret       |
    | client_id       | client_secret_wrong |
    | client_id_wrong | client_secret_wrong |

Scenario: Bearer token should be a JSON Web Token
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  When The client Id "client_id" and client secret "client_secret" are used to authenticate
  Then A JWT bearer token should be returned

Scenario: Bearer token should use the clientId as the subject
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  When The client Id "client_id" and client secret "client_secret" are used to authenticate
  Then A JWT bearer token should be returned
  And The token subject should be "client_id"

Scenario: Bearer token should be a valid for 60 minutes
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  And The token lifetime is configured to be 60 minutes
  When The client Id "client_id" and client secret "client_secret" are used to authenticate
  Then A JWT bearer token should be returned
  And The token should be valid for 60 minutes

Scenario: Bearer token should use configured issuer
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  And Token issuer is configured to be "https://valid-issuer.com"
  When The client Id "client_id" and client secret "client_secret" are used to authenticate
  Then A JWT bearer token should be returned
  And The token issuer should be "https://valid-issuer.com"

Scenario: Bearer token should use configured audience
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  And Token audience is configured to be "web.api"
  When The client Id "client_id" and client secret "client_secret" are used to authenticate
  Then A JWT bearer token should be returned
  And The token audience should be "web.api"

Scenario: Bearer token should be signed with the configured signing key
  Given The following credentials are configured:
    | Field        | Value         |
    | ClientId     | client_id     |
    | ClientSecret | client_secret |
  And Token signing key is configured to be "a-valid-signing-key"
  When The client Id "client_id" and client secret "client_secret" are used to authenticate
  Then A JWT bearer token should be returned
  And The token should be signed with "a-valid-signing-key"
