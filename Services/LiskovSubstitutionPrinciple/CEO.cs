using System;

namespace LiskovSubstitutionPrinciple
{
    public class CEO : Employee
    {
        public override void CalculateSalary(int rank)
        {
            decimal baseAmount = 30.99m;
            Salary = baseAmount + (rank * 4);
        }

        public override void AssignManager(Employee manager)
        {
            // This below violates the principle of Liskov Substitution Principle. 
            // because on use of this CEO in place of an Employee; An exception would be thrown which is a breaking change on 
            // over thr process of substiting the CEO for Employee.
            throw new Exception("The CEO cannot have a mamager");
        }
    }
}
