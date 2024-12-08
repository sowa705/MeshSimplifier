using Xunit;
using Xunit.Abstractions;

namespace MeshSimplifier.Tests;

public class MeshSimplifierTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public MeshSimplifierTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        var initialMesh = ObjFile.ReadFromFile("../../../../../assets/a320.obj");

        _testOutputHelper.WriteLine($"Pre simplification {initialMesh.vertexCount} verts, {initialMesh.triangles.Length/3} tris");

        var simplifier = new MeshSimplifier(initialMesh);

        simplifier.SimplifyMesh(0.2f);

        var simplifiedMesh = simplifier.GetMesh();

        _testOutputHelper.WriteLine($"Post simplification {simplifiedMesh.vertexCount} verts, {simplifiedMesh.triangles.Length/3} tris (ratio {(float)simplifiedMesh.vertexCount/initialMesh.vertexCount:0.00})");

        ObjFile.WriteToFile(simplifiedMesh,"a320_simplified.obj");
    }
}
