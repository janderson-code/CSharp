

using System.Reflection;

namespace Architecture.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Teste do Assembly do Core")]
        public void Core_Should_Not_haveDependencyOnOtherProjects()
        {
            // Arrange
            var assembly = typeof(CoreAssembly).Assembly;

            Type type = typeof(ArchitectureTests);

            var properties = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .Where(p => p.FieldType == typeof(string))
                .Select(p => p.GetValue(null) as string).ToArray();

            // Act
            var testResult = Types
                         .InAssembly(assembly)
                         .ShouldNot()
                         .HaveDependencyOnAll(properties)
                         .GetResult();


            // Assert

            var result = testResult.IsSuccessful;

            Assert.IsTrue(result);
        }
    }
}