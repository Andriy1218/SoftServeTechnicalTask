using SoftServerTechnicalTask.Domain.BuildingBlocks;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class User : Entity
    {
        public string Login { get; private set; }
        public int NameIdentifier { get; private set; }

        public User(string name, string login, int nameIdentifier)
        {
            Name = name;
            Login = login;
            NameIdentifier = nameIdentifier;
        }

        private User()
        {
            
        }
    }
}
