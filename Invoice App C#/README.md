# Invoice App ✍
App that will be used for managing invoices by different companies.
## Features 🔹
* Log in
  * An user or an admin can login into the app (all the users are hardcoded)
  * Usernames and passwords should be predefined ( created before hand in the system )
* User
  * For each user we keep track about the balance (amount of money) that he/she has.
  * For each user we keep track for all the invoices that he/she has.
  * Each user should have an option to increase the balance, by adding certain amount of money.
  * Each user should have an option to pay a specific invoice that is still unpayed. The money for invoice payment are taken from the user balance.
  * The user should have an option to overview all the invoices, and their status (payed/unpayed).
  * User can continiously do some of the actions above, until he\she selects an option to log-out
* Invoice
  * For each invoice we keep information about the company that invoice is about (BEG, EVN, Vodovod etc.)
  * For each invoice we keep information about the amount that needs to be payed.
  * For each invoice we keep information about the due date when it needs to be payed.
  * For each invoice we keep information about the month and year when that invoice is issued
  * If the user is late with the invoice payment, he\she pays additional penalties 10 denars per each day that he\she is late.
* Administrator
  * For each administrator we keep track about the company that he\she works. (BEG, EVN, Vodovod etc.)
  * When the administrator logs in, he is able to view all the invocies that are issued from his company, with the status if they are paid or not.
  * Once the list is shown, the adminstartor is automaticly logged out, and the application prompts for new login.
* Validations
  * It's up to you what kind of validations you will add, but prevent the application to enter in a state with corrupted data (ex. User has -3000 den balance.)