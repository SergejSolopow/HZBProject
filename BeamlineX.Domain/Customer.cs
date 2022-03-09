using BeamlineX.Domain.Documents;

namespace BeamlineX.Domain
{
    public class Customer : Entity
    {
        public string Name { get; private set; }

        public string FirstName { get; private set; }

        public virtual ICollection<Document> Documents { get; private set; } = new List<Document>();

        public Customer(string name)
        {
            Name = name;
            Documents = new List<Document>();
            FirstName = name;
        }
    }
}
