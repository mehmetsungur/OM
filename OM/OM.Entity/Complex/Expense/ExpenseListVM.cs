using System;

namespace OM.Entity.Complex.Expense
{
    public class ExpenseListVM
    {
        public int Id { get; set; }
        public DateTime ProcessDate { get; set; }
        public string Process { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime PayDate { get; set; }
        public decimal Price { get; set; }
    }
}