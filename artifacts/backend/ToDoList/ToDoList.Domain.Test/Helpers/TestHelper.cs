
using AutoFixture;
using AutoFixture.Kernel;
using ToDoList.Domain.Entities;
namespace ToDoList.Domain.Test.Helpers
{
    internal static class TestHelper
    {
        public static Fixture GetFixture()
        {
            Fixture entityfixture = new Fixture();
            // Remove the ThrowingRecursionBehavior
            entityfixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => entityfixture.Behaviors.Remove(b));
            // Add the OmitOnRecursionBehavior
            entityfixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return entityfixture;
        }
    }
}
