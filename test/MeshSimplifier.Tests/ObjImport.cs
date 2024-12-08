using System.Globalization;
using System.Numerics;

namespace MeshSimplifier.Tests;

public class ObjFile
{
    public static Mesh ReadFromFile(string path)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        using var reader = new StreamReader(path);

        List<Vector3> vertices = new();
        List<Vector3> normals = new();
        List<Vector2> uvs = new();
        List<int> indices = new();
        List<SubMesh> subMeshes = new();

        SubMesh currentSubMesh = null;
        int subMeshStartIndex = 0;

        while (reader.ReadLine() is { } line)
        {
            if (line.StartsWith("v "))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var x = float.Parse(parts[1]);
                var y = float.Parse(parts[2]);
                var z = float.Parse(parts[3]);
                vertices.Add(new Vector3(x, y, z));
            }
            else if (line.StartsWith("vn "))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var x = float.Parse(parts[1]);
                var y = float.Parse(parts[2]);
                var z = float.Parse(parts[3]);
                normals.Add(new Vector3(x, y, z));
            }
            else if (line.StartsWith("vt "))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var u = float.Parse(parts[1]);
                var v = float.Parse(parts[2]);
                uvs.Add(new Vector2(u, v));
            }
            else if (line.StartsWith("f "))
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in parts[1..])
                {
                    var faceParts = part.Split('/');
                    indices.Add(int.Parse(faceParts[0]) - 1); // Vertex index
                }
            }
            else if (line.StartsWith("o "))
            {
                // Close the previous submesh if any
                if (currentSubMesh != null)
                {
                    currentSubMesh.indexCount = indices.Count - subMeshStartIndex;
                    subMeshes.Add(currentSubMesh);
                }

                // Start a new submesh
                currentSubMesh = new SubMesh(indices.Count, 0);
                subMeshStartIndex = indices.Count;
            }
        }

        // Add the last submesh if any
        if (currentSubMesh != null)
        {
            currentSubMesh.indexCount = indices.Count - subMeshStartIndex;
            subMeshes.Add(currentSubMesh);
        }

        return new Mesh
        {
            vertices = vertices.ToArray(),
            normals = normals.ToArray(),
            textureCoordinates = [uvs.ToArray()],
            triangles = indices.ToArray(),
            subMeshes = subMeshes.ToArray()
        };
    }

    public static void WriteToFile(Mesh mesh, string path)
    {
        using var writer = new StreamWriter(path);

        // set cuurent culture to en-US to ensure correct decimal separator

        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        foreach (var vertex in mesh.vertices)
        {
            writer.WriteLine($"v {vertex.X} {vertex.Y} {vertex.Z}");
        }

        if (mesh.normals != null)
        {
            foreach (var normal in mesh.normals)
            {
                writer.WriteLine($"vn {normal.X} {normal.Y} {normal.Z}");
            }
        }

        if (mesh.textureCoordinates != null)
        {
            foreach (var uv in mesh.textureCoordinates)
            {
                writer.WriteLine($"vt {uv[0].X} {uv[0].Y}");
            }
        }

        foreach (var subMesh in mesh.subMeshes)
        {
            writer.WriteLine($"o {"SubMesh"}");

            for (int i = subMesh.startIndex; i < subMesh.startIndex + subMesh.indexCount; i += 3)
            {
                writer.WriteLine($"f {mesh.triangles[i] + 1} {mesh.triangles[i + 1] + 1} {mesh.triangles[i + 2] + 1}");
            }
        }
    }
}
