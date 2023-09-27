using Common;
using CsvHelper;
using Microsoft.Extensions.Logging;
using System.Globalization;
using CsvHelper.Configuration;
using System.Diagnostics;

namespace DataUploader.Readers;

public class CustomerCsvReader : ICustomerCsvReader
{
    private readonly ILogger<CustomerCsvReader> _logger;

    public CustomerCsvReader(ILogger<CustomerCsvReader> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async IAsyncEnumerable<Customer> Load(string filename)
    {
        var fileInfo = new FileInfo(filename);

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException(filename);
        }

        if (fileInfo.Length == 0)
        {
            throw new Exception($"Unable to process an empty file");
        }

        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = x => x.Header.Replace(" ", string.Empty),
            HasHeaderRecord = true,
        };

        await using var stream = fileInfo.OpenRead();
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, csvConfig);

        csv.Context
            .RegisterClassMap<CustomerMap>();

        try
        {
            // ReSharper disable once MethodHasAsyncOverload
            csv.Read();
            csv.ReadHeader();
            csv.ValidateHeader<Customer>();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to process CSV. The file does not have valid headers. {ex.Message}");
        }

        var records = csv.GetRecordsAsync<Customer>();

        await foreach (var customer in records)
        {
            yield return customer;
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Local
    private sealed class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.CustomerRef)
                .Validate(x => Guid.TryParse(x.Field, out var id) && id != Guid.Empty, args => $"Invalid {nameof(Customer.CustomerRef)} on row {args.Row.CurrentIndex + 1}: '{args.Field}'.");
        }
    }
}