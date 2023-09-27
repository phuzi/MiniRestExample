using Common;
using DataUploader.Readers;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow.Assist;
using Tests.Support;

namespace Tests.StepDefinitions
{
    [Binding]
    public sealed class CustomerCsvReaderStepDefinitions
    {
        private CustomerCsvReader? _customerCsvReader;
        private string? _filename;
        private List<Customer>? _customerData;
        private Exception? _exception;

        [BeforeScenario]
        public void BeforeScenario()
        {
            var logger = new Mock<ILogger<CustomerCsvReader>>();
            _customerCsvReader = new CustomerCsvReader(logger.Object);
        }

        [Given("A non-existent file")]
        public void GivenANon_ExistentFile()
        {
            _filename = Path.Combine(Environment.CurrentDirectory, "Files", "non-existent.csv");
        }

        [Given("An empty file")]
        public void GivenAnEmptyFile()
        {
            _filename = Path.Combine(Environment.CurrentDirectory, "Files", "empty.csv");
        }

        [Given("An invalid csv")]
        public void GivenAnInvalidCsv()
        {
            _filename = Path.Combine(Environment.CurrentDirectory, "Files", "invalid.csv");
        }

        [Given(@"A csv containing a customer ref with invalid GUID value")]
        public void GivenACsvContainingACustomerRefWithInvalidGuidValue()
        {
            _filename = Path.Combine(Environment.CurrentDirectory, "Files", "customerRef_not_a_GUID.csv");
        }

        [Given(@"A csv containing a customer ref with a default GUID value")]
        public void GivenACsvContainingACustomerRefWithADefaultGuidValue()
        {
            _filename = Path.Combine(Environment.CurrentDirectory, "Files", "customerRef_with_default_value.csv");
        }

        [Given("A valid csv")]
        public void GivenAValidCsv()
        {
            _filename = Path.Combine(Environment.CurrentDirectory, "Files", "valid.csv");
        }

        [When("The file is loaded")]
        public async Task WhenTheFileIsLoaded()
        {
            try
            {
                _customerData = await _customerCsvReader!
                    .Load(_filename!)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then("A FileNotFoundException should be thrown")]
        public void ThenAFileNotFoundExceptionShouldBeThrown()
        {
            Assert.IsNotNull(_exception);
            Assert.IsInstanceOfType(_exception, typeof(FileNotFoundException));
        }

        [Then("An Exception is thrown")]
        public void ThenAnExceptionIsThrown()
        {
            Assert.IsNotNull(_exception);
        }

        [Then(@"The exception message is ""([^""]*)""")]
        public void ThenTheExceptionMessageIs(string message)
        {
            Assert.AreEqual(message, _exception?.Message);
        }

        [Then(@"The exception message starts with ""([^""]*)""")]
        public void ThenTheExceptionMessageStartsWith(string message)
        {
            if (!_exception!.Message.StartsWith(message))
            {
                Assert.Fail( $"Expected exception message to start with <{message}>. But got <{_exception.Message}>");
            }
        }

        [Then("The following customer records should be returned:")]
        public async Task ThenTheFollowingCustomerRecordsShouldBeReturned(Table table)
        {
            var customerRecords = table.CreateSet<Customer>().ToList();

            if (_customerData is null)
            {
                Assert.Fail("Customer data is null");
                return;
            }

            var customerComparer = new CustomerEqualityComparer();

            foreach (var customer in _customerData)
            {
                var matchedCustomer = customerRecords.FirstOrDefault(x => customerComparer.Equals(x, customer));
                if (matchedCustomer == null)
                {
                    Assert.Fail($"No matching customer found {customer}");
                    return;
                }

                customerRecords.Remove(matchedCustomer);
            }

            if (customerRecords.Any())
            {
                Assert.Fail("Not all records where loaded!");
            }
        }
    }
}