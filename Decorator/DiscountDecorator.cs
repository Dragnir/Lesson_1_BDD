using Decorator;

namespace Lesson_11_BDD.Decorator
{
    class DiscountDecorator : UserDecorator
    {
        private int DiscountRate = 5;

        public DiscountDecorator(User user) : base(user)
        {
            this.RoleCode = "Discount";
            this.Price = 0;
        }

        public override string GetRole()
        {
            return base.GetRole() + string.Format("Disc{0}", DiscountRate);
        }

        public override decimal GetPrice()
        {
            return (100 - DiscountRate) * BaseUser.GetPrice() / 100;
        }
    }
}
