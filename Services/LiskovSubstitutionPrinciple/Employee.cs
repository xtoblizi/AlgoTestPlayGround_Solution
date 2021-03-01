namespace LiskovSubstitutionPrinciple
{
    public abstract class Employee
    {
        public Employee()
        {

        }
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee Manager { get; set; }
        public int Rank { get; set; }
        public decimal Salary { get; set; }

        public virtual void  CalculateSalary(int rank)
        {
            decimal baseAmount = 12.50M;
            Salary = baseAmount + (rank * 2);
        }
        public virtual void AssignManager(Employee manager)
        {
            Manager = manager;
        }
    }
}
