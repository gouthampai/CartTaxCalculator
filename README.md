# CartTaxCalculator

## How to run this code
Navigate to `./CartTaxCalculator` and run `dotnet run`

## Run the tests
Navigate to `./CartTaxCalculator.UnitTests` and run `dotnet test`

## About The Code
- The main entrypoint is `Program.cs`
- `ProcessCartDataService` creates a list of carts
- each of these carts are passed to `InvoiceService` to generate the invoice with the sales tax and total invoice price
- `InvoiceService` loops through each item in the cart and depends on the `TaxCalculationService` to calculate the appropriate amount of tax for each cart line item
- After this is done for all cart items, `InvoiceService` will return an `Invoice` result which is rendered to the console by the `ProcessCartDataService`

Note: all tax values are rounded up to the nearest nickel (5 cents) Ex: $2.81 in tax will be rounded to $2.85