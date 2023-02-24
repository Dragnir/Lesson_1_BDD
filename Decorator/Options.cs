
using Decorator;

namespace Lesson_11_BDD.Decorator
{
    class SipmleUserOption : UserDecorator
    {
        public SipmleUserOption(User user)
            : base(user)
        {
            RoleCode = "Simple";
            Price = 50.0M;
        }
    }

    class PrivilageUserOption : UserDecorator
    {
        public PrivilageUserOption(User user)
            : base(user)
        {
            RoleCode = "Privilage";
            Price = 150.0M;
        }
    }
}
