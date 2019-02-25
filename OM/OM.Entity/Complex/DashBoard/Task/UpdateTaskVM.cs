namespace OM.Entity.Complex.DashBoard.Task
{
    public class UpdateTaskVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string Description { get; set; }
    }
}