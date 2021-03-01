namespace LiskovSubstitutionPrinciple
{
    public class Manager : Employee
    {
        public  override  void CalculateSalary(int rank)
        {
            decimal baseAmount = 20.45M;
            Salary = baseAmount + (rank * 3);
        }

        public override void AssignManager(Employee manager)
        {
            Manager = manager;
        }
    }
}
