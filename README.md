# MeshSimplifier
![NuGet Downloads](https://img.shields.io/nuget/dt/Sowa705.MeshSimplifier?color=green&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FSowa705.MeshSimplifier)


Trimmed down fork of the [UnityMeshSimplifier](https://github.com/Whinarn/UnityMeshSimplifier) Library adapted for modern non-Unity .NET 9+ projects

## Basic usage

```csharp
using MeshSimplifier;

// load your 3D model into a Mesh object
Mesh mesh = new Mesh();
mesh.vertices = ...;
mesh.triangles = ...;
mesh.submeshes = [new SubMesh(0,mesh.triangles.Length)];

MeshSimplifier simplifier = new MeshSimplifier();

simplifier.Initialize(mesh);
simplifier.SimplifyMesh(0.5f);

var optimizedMesh = simplifier.ToMesh();
```

## Removed features

- Unity integration
- BlendShapes
- BoneWeights (may be re-added in the future)
- 3D and 4D UVs (may be re-added in the future)

## License

This project is licensed as MIT as stated in LICENSE.md, huge thanks to the UnityMeshSimplifer contributors and Fast Quadric Mesh Simplification team
