using BeamlineX.Domain;

namespace BeamlineX.Repositories.EntityConfigurations
{
    internal class CustomerConfiguration : EntityConfiguration<Customer>
    {
        public override void Configure()
        {
            SetName(e => e.Name);
            HasIndex(e => e.Name);

            SetManyToOneRelation(c => c.Documents, d => d.Customer, d => d.CustomerId);
        }
    }
}
