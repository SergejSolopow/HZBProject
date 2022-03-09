using BeamlineX.Common.Extensions;
using BeamlineX.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Linq.Expressions;

namespace BeamlineX.Repositories.EntityConfigurations
{
    internal abstract class EntityConfiguration<T> : IEntityConfiguration, IEntityTypeConfiguration<T>
        where T : Entity
    {
        private EntityTypeBuilder<T>? _builder;

        public EntityTypeBuilder<T> Builder => _builder;

        public abstract void Configure();

        public void Configure(EntityTypeBuilder<T> builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder), $"Argument darf nicht NULL sein!");

            builder.HasKey(e => e.Id);
            builder
                .Property(p => p.CreatedDate)
                .IsConcurrencyToken();
            builder
                .Property(p => p.UpdatedDate)
                .IsConcurrencyToken();

            Configure();
        }

        protected void SetAbbreviation(Expression<Func<T, string>> propertyExpression)
        {
            _builder?
                .Property(propertyExpression)
                .IsRequired()
                .HasMaxLength(20)
                .IsConcurrencyToken();
        }

        protected void SetName(Expression<Func<T, string>> propertyExpression)
        {
            _builder?
                .Property(propertyExpression)
                .IsRequired()
                .HasMaxLength(100)
                .IsConcurrencyToken();
        }

        protected void SetDescription(Expression<Func<T, string>> propertyExpression)
        {
            _builder?
                .Property(propertyExpression)
                .HasMaxLength(200);
        }

        protected void SetDateTime(Expression<Func<T, DateTime>> propertyExpression)
        {
            _builder?
                .Property(propertyExpression)
                .IsRequired();
        }

        protected void SetManyToOneRelation<TRelatedEntity>(
            Expression<Func<T, IEnumerable<TRelatedEntity>>> collectionExpression,
            Expression<Func<TRelatedEntity, T>> ralationExpression,
            Expression<Func<TRelatedEntity, object>> keyExpression,
            bool cascadeOnDelete = true,
            bool isRequired = true)
            where TRelatedEntity : class
        {
            if (collectionExpression is null)
            {
                throw new ArgumentNullException(nameof(collectionExpression));
            }

            if (ralationExpression is null)
            {
                throw new ArgumentNullException(nameof(ralationExpression));
            }

            if (keyExpression is null)
            {
                throw new ArgumentNullException(nameof(keyExpression));
            }

            ReferenceCollectionBuilder<T, TRelatedEntity> builder = _builder?
                .HasMany(collectionExpression)
                .WithOne(ralationExpression)
                .HasForeignKey(keyExpression)
                .HasConstraintName($"FK_{ keyExpression.GetPropertyName() }");

            if (cascadeOnDelete)
            {
                builder.OnDelete(DeleteBehavior.Cascade);
            }

            if (isRequired)
            {
                builder.IsRequired();
            }
        }

        protected void SetOneToOneRelation<TRelatedEntity>(
            Expression<Func<T, TRelatedEntity>> entityExpression,
            Expression<Func<TRelatedEntity, T>> ralationExpression,
            Expression<Func<TRelatedEntity, object>> keyExpression,
            bool cascadeOnDelete = true,
            bool isRequired = true)
            where TRelatedEntity : class
        {
            ReferenceReferenceBuilder<T, TRelatedEntity> builder = _builder
                .HasOne(entityExpression)
                .WithOne(ralationExpression)
                .HasForeignKey(keyExpression)
                .HasConstraintName($"FK_{ keyExpression.GetPropertyName() }");

            if (cascadeOnDelete)
            {
                builder.OnDelete(DeleteBehavior.Cascade);
            }

            builder.IsRequired(isRequired);
        }

        protected void SetOneToZeroRelation<TRelatedEntity>(
            Expression<Func<T, TRelatedEntity>> entityExpression,
            Expression<Func<TRelatedEntity, T>> ralationExpression,
            Expression<Func<TRelatedEntity, object>> keyExpression)
            where TRelatedEntity : class
        {
            _builder?
                .HasOne(entityExpression)
                .WithOne(ralationExpression)
                .HasForeignKey(keyExpression)
                .HasConstraintName($"FK_{ keyExpression.GetPropertyName() }");
        }

        protected void HasIndex(Expression<Func<T, object>> indexExpression, bool unique = true)
        {
            var indexBuilder = _builder?
                .HasIndex(indexExpression);

            if (unique)
                indexBuilder.IsUnique();
        }
    }
}
