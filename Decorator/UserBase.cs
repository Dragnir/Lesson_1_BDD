using Decorator;

namespace Lesson_11_BDD.Decorator
{
    public class UserBase : User
    {
        public override string GetRole() { return ""; }
        public override decimal GetPrice() { return 499.0M; }
    }
}
