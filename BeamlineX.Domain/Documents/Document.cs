namespace BeamlineX.Domain.Documents
{
    public class Document : Entity
    {
        public Guid CustomerId { get; private set; }

        public virtual Customer? Customer { get; private set; }

        public string OriginalFileName { get; private set; }

        public Document()
        {
            CustomerId = Guid.Empty;
            Customer = null;
            OriginalFileName = string.Empty;
        }

        public Document(Customer customer, string originalFileName)
        {
            CustomerId = customer.Id;
            Customer = customer;
            OriginalFileName = originalFileName;
        }

        public string GetFilePath() => Path.Combine(CustomerId.ToString(), Id.ToString());
    }
}
