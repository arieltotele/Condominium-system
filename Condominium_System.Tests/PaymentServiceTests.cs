using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using Moq;

namespace Condominium_System.Tests.Services
{
    public class PaymentServiceTests
    {
        private readonly Mock<IRepositoryWithId<Payment>> _mockPaymentRepo;
        private readonly Mock<IRepositoryWithId<Receipt>> _mockReceiptRepo;
        private readonly Mock<ILateFeeService> _mockLateFeeService;
        private readonly PaymentService _service;

        public PaymentServiceTests()
        {
            _mockPaymentRepo = new Mock<IRepositoryWithId<Payment>>();
            _mockReceiptRepo = new Mock<IRepositoryWithId<Receipt>>();
            _mockLateFeeService = new Mock<ILateFeeService>();
            _service = new PaymentService(
                _mockPaymentRepo.Object,
                _mockReceiptRepo.Object,
                _mockLateFeeService.Object
            );
        }

        [Fact]
        public async Task GetAllPaymentsAsync_ReturnsPayments()
        {
            var payments = new List<Payment>
            {
                new Payment{Id=1, ReceiptId=1, AmountPaid=100},
                new Payment{Id=2, ReceiptId=1, AmountPaid=200}
            };

            _mockPaymentRepo.Setup(p => p.GetAllWithIncludesAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Payment, object>>[]>()
            )).ReturnsAsync(payments);

            var result = await _service.GetAllPaymentsAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetPaymentByIdAsync_ReturnsPayment()
        {
            var payment = new Payment { Id = 1, AmountPaid = 50 };
            _mockPaymentRepo.Setup(p => p.GetByIdWithIncludesAsync(
                1, It.IsAny<System.Linq.Expressions.Expression<Func<Payment, object>>[]>()
            )).ReturnsAsync(payment);

            var result = await _service.GetPaymentByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetPaymentsByReceiptIdAsync_ReturnsFilteredPayments()
        {
            var payments = new List<Payment>
            {
                new Payment{Id=1, ReceiptId=5, AmountPaid=100},
                new Payment{Id=2, ReceiptId=6, AmountPaid=200}
            };

            _mockPaymentRepo.Setup(p => p.FindAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Payment, bool>>>()
            )).ReturnsAsync((System.Linq.Expressions.Expression<Func<Payment, bool>> expr) =>
                payments.Where(expr.Compile()));

            var result = await _service.GetPaymentsByReceiptIdAsync(5);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetPaymentsByDateRangeAsync_ReturnsInRange()
        {
            var payments = new List<Payment>
            {
                new Payment{Id=1, Date=DateTime.Today, AmountPaid=100},
                new Payment{Id=2, Date=DateTime.Today.AddDays(-10), AmountPaid=200}
            };

            _mockPaymentRepo.Setup(p => p.FindAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Payment, bool>>>()
            )).ReturnsAsync((System.Linq.Expressions.Expression<Func<Payment, bool>> expr) =>
                payments.Where(expr.Compile()));

            var result = await _service.GetPaymentsByDateRangeAsync(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));
            Assert.Single(result);
        }

        [Fact]
        public async Task CreatePaymentAsync_UpdatesReceiptAndSavesPayment()
        {
            var payment = new Payment { Id = 1, ReceiptId = 10, AmountPaid = 50, Detail = "Pago" };
            var receipt = new Receipt { Id = 10, Amount = 100, AmountPaid = 0, Status = "Pending", LateFee = 10 };

            _mockLateFeeService.Setup(l => l.ApplyLateFeeIfNeededAsync(10)).ReturnsAsync(true);
            _mockReceiptRepo.Setup(r => r.GetByIdAsync(10)).ReturnsAsync(receipt);
            _mockPaymentRepo.Setup(p => p.AddAsync(payment)).Returns(Task.CompletedTask);
            _mockPaymentRepo.Setup(p => p.SaveChangesAsync()).Returns(Task.CompletedTask);

            var result = await _service.CreatePaymentAsync(payment);

            _mockPaymentRepo.Verify(p => p.AddAsync(payment), Times.Once);
            _mockPaymentRepo.Verify(p => p.SaveChangesAsync(), Times.Once);
            _mockReceiptRepo.Verify(r => r.Update(It.IsAny<Receipt>()), Times.Once);

            Assert.Contains("Mora aplicada", payment.Detail); // se añadió nota de mora
            Assert.Equal(50, receipt.AmountPaid);
        }

        [Fact]
        public async Task UpdatePaymentAsync_CallsUpdateAndSave()
        {
            var payment = new Payment { Id = 2, AmountPaid = 100 };
            _mockPaymentRepo.Setup(p => p.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.UpdatePaymentAsync(payment);

            _mockPaymentRepo.Verify(p => p.Update(payment), Times.Once);
            _mockPaymentRepo.Verify(p => p.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeletePaymentAsync_RemovesPaymentAndUpdatesReceipt()
        {
            var payment = new Payment { Id = 1, ReceiptId = 10, AmountPaid = 50 };
            var receipt = new Receipt { Id = 10, AmountPaid = 100 };

            _mockPaymentRepo.Setup(p => p.GetByIdAsync(1)).ReturnsAsync(payment);
            _mockReceiptRepo.Setup(r => r.GetByIdAsync(10)).ReturnsAsync(receipt);
            _mockPaymentRepo.Setup(p => p.SaveChangesAsync()).Returns(Task.CompletedTask);

            await _service.DeletePaymentAsync(1);

            _mockReceiptRepo.Verify(r => r.Update(receipt), Times.Once);
            _mockPaymentRepo.Verify(p => p.Remove(payment), Times.Once);
            _mockPaymentRepo.Verify(p => p.SaveChangesAsync(), Times.Once);
            Assert.Equal(50, receipt.AmountPaid); // se le restó el pago eliminado
        }

        [Fact]
        public async Task GetTotalPaymentsByReceiptAsync_ReturnsSum()
        {
            var payments = new List<Payment>
            {
                new Payment{AmountPaid=100},
                new Payment{AmountPaid=50}
            };

            _mockPaymentRepo.Setup(p => p.FindAsync(
                It.IsAny<System.Linq.Expressions.Expression<Func<Payment, bool>>>()
            )).ReturnsAsync(payments);

            var result = await _service.GetTotalPaymentsByReceiptAsync(1);
            Assert.Equal(150, result);
        }
    }
}
