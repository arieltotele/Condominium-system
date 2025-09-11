using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface ILateFeeService
    {
        Task<int> CalculateLateFeeAsync(int receiptId);
        Task<bool> ApplyLateFeeIfNeededAsync(int receiptId);
    }
}
