using System;

namespace TestProject.Core.Account.ValueObjects
{
    public class ExpenseOverflowCheck
    {
        public bool IsExpenseOverflow(User.User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var monthlyOutflow = user.GetMonthlyOutflow();
            if (monthlyOutflow < 0)
                throw new Exceptions.MonthlyOutflowLimitBreachException("Monthly money amount is too low", monthlyOutflow);

            return false;
        }
    }
}
