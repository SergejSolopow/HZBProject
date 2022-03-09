using BeamlineX.Common.Extensions;
using BeamlineX.CommonTests.Model;

using FluentAssertions;

using System;
using System.Linq.Expressions;

using Xunit;

namespace BeamlineX.CommonTests.Extensions
{
    public class ExpressionExtensionsTests
    {
        [Fact(DisplayName = "GetPropertyName should return PropertyName from Expression")]
        public void GetPropertyNameTest()
        {
            Expression<Func<ATest, object>> expression = t => t.Name;

            string propertyName = expression.GetPropertyName();
            propertyName.Should().BeEquivalentTo(nameof(ATest.Name));
        }
    }
}
