using System.Linq.Expressions;
using API.DbContext;
using API.Repositories;
using Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using TechTalk.SpecFlow.Assist;
using Tests.Support;

namespace Tests.StepDefinitions
{
    [Binding]
    public sealed class CustomerRepositoryStepDefinitions
    {
        private CustomerRepository? _repository;
        private Mock<ICustomerDbContext>? _dbContext;

        private Mock<DbSet<Customer>>? _customerDbSet;
        
        private CancellationToken? _cancellationToken;
        private Customer? _returnedCustomer;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _customerDbSet = new Mock<DbSet<Customer>>();
            var setup = _customerDbSet.Setup(x => x.AddAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>()));

            _dbContext = new Mock<ICustomerDbContext>();
            _dbContext.SetupGet(x => x.Customers).Returns(_customerDbSet.Object);

            _repository = new CustomerRepository(_dbContext.Object);
        }

        [Given(@"A cancellation token is passed when adding|retrieving a customer")]
        public void GivenACancellationIsPassedWhenAddingACustomer()
        {
            _cancellationToken = new CancellationTokenSource().Token;

        }

        [Given(@"A customer is added to the repository")]
        public async Task GivenACustomerIsAddedToTheRepository()
        {
            _ = await _repository!.AddAsync(new Customer(), _cancellationToken ?? CancellationToken.None);
        }

        [When(@"A customer is requested from the repository")]
        public async Task WhenACustomerIsRequestedFromTheRepository()
        {
            _returnedCustomer = await _repository!.GetAsync(Guid.NewGuid(), _cancellationToken ?? CancellationToken.None);
        }

        [When(@"A customer with customerRef {([^}]*)} is requested")]
        public async Task WhenACustomerWithCustomerRefIsRequested(Guid customerRef)
        {
            _returnedCustomer = await _repository!.GetAsync(customerRef, CancellationToken.None);
        }

        [Given(@"The following customer is added to the repository:")]
        public async Task GivenTheFollowingCustomerIsAddedToTheRepository(Table table)
        {
            var customer = table.CreateInstance<Customer>(new InstanceCreationOptions()
            {
                VerifyAllColumnsBound = true
            });

            _ = await _repository!.AddAsync(customer, _cancellationToken ?? CancellationToken.None);
        }

        [Given(@"The following customer exists in the database:")]
        public void GivenTheFollowingCustomerExistsInTheDatabase(Table table)
        {
            var customer = table.CreateInstance<Customer>();

            Expression<Func<object?[]?, bool>> predicate = @params =>
                @params != null && @params.Length == 1 && (Guid?)@params[0] == customer.CustomerRef;

            _customerDbSet!.Setup(x => x.FindAsync(It.Is(predicate), It.IsAny<CancellationToken>())).ReturnsAsync(customer);
        }

        [Then(@"(\d+) customers? will be added to the database context")]
        public void NumberCustomersWillBeAddedToTheDatabaseContext(int count)
        {
            _customerDbSet!
                .Verify(x =>
                    x.AddAsync(
                        It.IsAny<Customer>(),
                        It.IsAny<CancellationToken>()),
                    Times.Exactly(count));
        }

        [Then(@"A null is returned")]
        public void ThenANullIsReturned()
        {
            Assert.IsNull(_returnedCustomer);
        }

        [Then(@"The cancellation token is passed to AddAsync")]
        public void ThenTheCancellationTokenIsPassedToAddAsync()
        {
            _customerDbSet!
                .Verify(x => x.AddAsync(It.IsAny<Customer>(), _cancellationToken!.Value));
        }

        [Then(@"The cancellation token is passed to FindAsync")]
        public void ThenTheCancellationTokenIsPassedToFindAsync()
        {
            _customerDbSet!
                .Verify(x => x.FindAsync(It.IsAny<object?[]?>(), _cancellationToken!.Value), Times.Once);

        }

        [Then(@"The changes are saved")]
        public void GivenTheChangesAreSaved()
        {
            _dbContext!.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }

        [Then(@"The following customer will be added to the database context:")]
        public void ThenTheRepositoryWillContainTheFollowingItem(Table table)
        {
            var customer = table.CreateInstance<Customer>();

            _customerDbSet!
                .Verify(x => x.AddAsync(
                    It.Is(customer, new CustomerEqualityComparer()), 
                    It.IsAny<CancellationToken>()));
        }

        [Then(@"The following customer is returned:")]
        public void ThenTheFollowingCustomerIsReturned(Table table)
        {
            var customerComparer = new CustomerEqualityComparer();
            
            var expected = table.CreateInstance<Customer>();
            Assert.IsTrue(customerComparer.Equals(expected, _returnedCustomer));
        }
    }
}