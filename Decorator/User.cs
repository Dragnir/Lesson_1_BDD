
namespace Decorator
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public abstract string GetRole();
        public abstract decimal GetPrice();
    }
}
