using System;

namespace OM.Entity.Complex.DashBoard.Task
{
    public class TaskListVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FromAss { get; set; }
        public bool ShowToAss { get; set; }
        public bool ShowFromAss { get; set; }
        public string ToAss { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public DateTime Modified { get; set; }
        public string Description { get; set; }
    }
}