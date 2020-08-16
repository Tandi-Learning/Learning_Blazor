using System;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Services
{
    public class ExpenseApprovalService : IExpenseApprovalService
    {
        private IEmployeeDataService _employeeDataService { get; set; }

        public ExpenseApprovalService(IEmployeeDataService EmployeeDataService)
        {
            _employeeDataService = EmployeeDataService;
        }

        public async Task<ExpenseStatus> GetExpenseStatus(Expense expense)
        {
            var employee = await _employeeDataService.GetEmployeeDetails(expense.EmployeeId);

            if (employee.IsOPEX)
            {
                switch (expense.ExpenseType)
                {
                    case ExpenseType.Conference:
                    case ExpenseType.Transportation:
                    case ExpenseType.Hotel:
                    case ExpenseType.Food:
                        return ExpenseStatus.Denied;
                }

                if (expense.Status != ExpenseStatus.Denied)
                {
                    expense.CoveredAmount = expense.Amount / 2;
                }
            }

            if (!employee.IsFTE)
            {
                if (expense.ExpenseType != ExpenseType.Training)
                {
                    return ExpenseStatus.Denied;
                }
            }

            if (expense.ExpenseType == ExpenseType.Food && expense.Amount > 100)
            {
                return ExpenseStatus.Pending;
            }

            if (expense.Amount > 5000)
            {
                return ExpenseStatus.Pending;
            }

            return ExpenseStatus.Pending;
        }
    }
}
