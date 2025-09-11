using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Moq;

namespace Condominium_System.Tests.Services
{
    public class ReceiptServiceTests
    {
        private readonly Mock<IRepositoryWithId<Receipt>> _mockReceiptRepo;
        private readonly Mock<IServiceProvider> _mockServiceProvider;
        private readonly ReceiptService _service;

        public ReceiptServiceTests()
        {
            _mockReceiptRepo = new Mock<IRepositoryWithId<Receipt>>();
            _mockServiceProvider = new Mock<IServiceProvider>();
            _service = new ReceiptService(_mockReceiptRepo.Object, _mockServiceProvider.Object);
        }

        [Fact]
        public async Task GetAllReceiptsAsync_ReturnsReceipts()
        {
            // Arrange
            var receipts = new List<Receipt>
            {
                new Receipt{ Id=1, TenantId=1, HousingId=1, Amount=100, AmountPaid=0, Status="Pending"},
                new Receipt{ Id=2, TenantId=2, HousingId=1, Amount=200, AmountPaid=200, Status="Paid"}
            };
            _mockReceiptRepo.Setup(r => r.GetAllWithIncludesAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Receipt, object>>[]>()
            )).ReturnsAsync(receipts);

            // Act
            var result = await _service.GetAllReceiptsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetReceiptByIdAsync_ReturnsSingleReceipt()
        {
            var receipt = new Receipt { Id = 1, TenantId = 1, HousingId = 1, Amount = 100 };
            _mockReceiptRepo.Setup(r => r.GetByIdWithIncludesAsync(
                1, It.IsAny<System.Linq.Expressions.Expression<Func<Receipt, object>>[]>()
            )).ReturnsAsync(receipt);

            var result = await _service.GetReceiptByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetReceiptsByTenantIdAsync_ReturnsPendingReceipts()
        {
            var receipts = new List<Receipt>
            {
                new Receipt{Id=1, TenantId=5, Amount=100, AmountPaid=0},
                new Receipt{Id=2, TenantId=5, Amount=100, AmountPaid=100}
            };

            _mockReceiptRepo.Setup(r => r.FindAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Receipt, bool>>>()
            )).ReturnsAsync((System.Linq.Expressions.Expression<Func<Receipt, bool>> expr) =>
                receipts.Where(expr.Compile()));

            var result = await _service.GetReceiptsByTenantIdAsync(5);

            Assert.Single(result); // solo uno pendiente
        }

        [Fact]
        public async Task GetOverdueReceiptsAsync_ReturnsOverdue()
        {
            var receipts = new List<Receipt>
            {
                new Receipt{Id=1, DueDate=DateTime.Now.AddDays(-10), Amount=100, AmountPaid=0},
                new Receipt{Id=2, DueDate=DateTime.Now.AddDays(5), Amount=100, AmountPaid=0}
            };

            _mockReceiptRepo.Setup(r => r.FindAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Receipt, bool>>>()
            )).ReturnsAsync((System.Linq.Expressions.Expression<Func<Receipt, bool>> expr) =>
                receipts.Where(expr.Compile()));

            var result = await _service.GetOverdueReceiptsAsync();
            Assert.Single(result);
        }

        [Fact]
        public async Task CreateReceiptAsync_SavesReceipt()
        {
            var receipt = new Receipt { Id = 10, TenantId = 1, HousingId = 1, Amount = 300 };
            _mockReceiptRepo.Setup(r => r.AddAsync(receipt)).Returns(Task.CompletedTask);
            _mockReceiptRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            var result = await _service.CreateReceiptAsync(receipt);

            _mockReceiptRepo.Verify(r => r.AddAsync(receipt), Times.Once);
            _mockReceiptRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.Equal(10, result.Id);
        }

        [Fact]
        public async Task UpdateReceiptAsync_CallsUpdateAndSave()
        {
            var receipt = new Receipt { Id = 2, Amount = 100 };
            _mockReceiptRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.UpdateReceiptAsync(receipt);

            _mockReceiptRepo.Verify(r => r.Update(receipt), Times.Once);
            _mockReceiptRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteReceiptAsync_RemovesIfExists()
        {
            var receipt = new Receipt { Id = 1 };
            _mockReceiptRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(receipt);
            _mockReceiptRepo.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.DeleteReceiptAsync(1);

            _mockReceiptRepo.Verify(r => r.Remove(receipt), Times.Once);
            _mockReceiptRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetTotalAmountDueAsync_ReturnsSum()
        {
            var receipts = new List<Receipt>
            {
                new Receipt{Amount=100, AmountPaid=50},
                new Receipt{Amount=200, AmountPaid=0}
            };

            // Para que GetReceiptsByTenantIdAsync funcione usamos el mock
            _mockReceiptRepo.Setup(r => r.FindAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Receipt, bool>>>()
            )).ReturnsAsync(receipts);

            var result = await _service.GetTotalAmountDueAsync(1);
            Assert.Equal(250, result);
        }
    }
}
