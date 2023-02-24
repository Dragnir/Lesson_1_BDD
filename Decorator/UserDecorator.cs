using Decorator;

namespace Lesson_11_BDD.Decorator
{
    public abstract class UserDecorator : User
    {
        protected User BaseUser = null;

        protected string RoleCode = "";
        protected decimal Price = 0.0M;

        protected UserDecorator(User user)
        {
            BaseUser = user;
            Name = user.Name;
        }
        public override string GetRole()
        {
            return string.Format("{0}-{1}", BaseUser.GetRole(), RoleCode);
        }

        public override decimal GetPrice()
        {
            return Price + BaseUser.GetPrice();
        }
    }
}
