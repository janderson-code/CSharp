
using ProjetoAnime.Anime.API;

namespace Architecture.Test;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(TestName = "Teste Core não pode ter dependência")]
    public void Core_Should_Not_haveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(CoreAssembly).Assembly;

        Type type = typeof(ArchitectureTestsNameSpace);

        var properties = type
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
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

    [TestCase(TestName = "ApiAnimeDeveTerDependenciaCore")]
    public void AnimeAPI_Should_haveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(AnimeAPIAssemblyReference).Assembly;

        string? nameSpace = assembly.GetType().Namespace;

        Type type = typeof(ArchitectureTestsNameSpace);

        var properties = type
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
            .Where(p => p.FieldType == typeof(string))
            .Select(p => p.GetValue(null) as string)
            .ToArray();

        // Act
        var testResult = Types
                     .InAssembly(assembly)
                     .That()
                     .HaveNameEndingWith("Core")
                     .And()
                     .HaveNameEndingWith("Core.API")
                     .Should()
                     .HaveDependencyOn(nameSpace)
                     .And()
                     .NotHaveDependencyOnAll(properties)
                     .GetResult();

        // Assert
        var result = testResult.IsSuccessful;

        Assert.IsTrue(result);
    }
}