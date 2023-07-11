namespace EntityFramework.Domain.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
        public DateTime DOJ { get; set; }
        public int Age { get; set; }
        public string? Desc { get; set; }

        public CompanyResponse Company { get; set; }
    }
}
