using CartTaxCalculator.Services;
using CartTaxCalculator.Services.Rules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
        .AddTransient<IRule, DomesticSalesTaxRule>()
        .AddTransient<IRule, ImportTaxRule>()
        .AddTransient<ITaxCalculationService, TaxCalculationService>()
        .AddTransient<IInvoiceService, InvoiceService>()
        .AddTransient<IProcessCartDataService, ProcessCartDataService>()
    )
    .Build();

Run(host.Services);

await host.RunAsync();

static void Run(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var processCartDataService = provider.GetRequiredService<IProcessCartDataService>();
    processCartDataService.GetCartsAndPrintInvoices();
    Console.WriteLine();
}