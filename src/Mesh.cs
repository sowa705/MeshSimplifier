using System.Numerics;

namespace MeshSimplifier;

public class Mesh
{
    public Vector3[] vertices;
    public Vector3[] normals;
    public Vector4[] tangents;
    public Vector2[] uvs;
    public Vector4[] colors;
    public int[] triangles;

    public int subMeshCount;
    public int vertexCount => vertices.Length;

    public int[] GetTriangles(int submeshIndex)
    {
        return [];
    }

    public void GetUVs(int channel, List<Vector4> uvList)
    {
    }

    public void GetUVs(int channel, List<Vector3> uvList)
    {
    }

    public void GetUVs(int channel, List<Vector2> uvList)
    {
    }
}
