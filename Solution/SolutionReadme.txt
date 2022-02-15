Q-LESS Exam by Errold Sanchez

/*
** Backend Implementation
***** ***** */
- I created an API Solution using .NET Core 3.0
  - I used the default WebApi for project startup
  - I created segregation of codes for better architecture
    - QLESS.Api, interfaces the controller
    - QLESS.Controller, classes controls the request and response of each service
    - QLESS.Contract, classes for the request and response of each controller
    - QLESS.Domain, classes that contains the service implementations
    - QLESS.Data, has the repository classes for data manipulation
  - I used repository pattern as per the architecture described above
  - I created a generic repository for the entity operations
  - I created a Unit Of Work to keep a list of request in one place


/*
** UI
***** ***** */
For quick UI I used swagger to be able to test the services in the API. 
Will be giving instructions based on screnarios.


/*
** Limitations
***** ***** */
- Actual fare matrix not implemented. Rather put in settings a regular/default fare amount.
- There is no backend validations in place so actual request may error if not given correct parameters.


/*
** TODOS
***** ***** */
- Section A: No checking of 5 yrs validity
- Section B: No checking of max additional daily discount has been reached
- Section C: No checking of min/max amount when loading
- Section D: No checking of provided ID format based on registration type
- Section D: Registration has no checking if it was already registered, though it only uses the same data row

/*
** BUYING A NEW CARD
***** ***** */
- Use https://localhost:44311/api/Card/Add

/*
** REGISTERING THE CARD
***** ***** */
- Use https://localhost:44311/api/Card/Register
- Use either 2 or 3 for cardRegTypeId
- For getting the serial number of a card use https://localhost:44311/api/Card/List

/*
** USING THE CARD
***** ***** */
- Use https://localhost:44311/api/Card/Use
- Discounts will apply given the limitations and TODOS above
- For getting the serial number of a card use https://localhost:44311/api/Card/List

/*
** RELOAD THE CARD
***** ***** */
- Use https://localhost:44311/api/Card/Reload
- Reload will apply given the limitations and TODOS above
- For getting the serial number of a card use https://localhost:44311/api/Card/List









