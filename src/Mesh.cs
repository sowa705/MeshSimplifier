using System.Numerics;

namespace MeshSimplifier;

public class SubMesh
{
    public int startIndex;
    public int indexCount;

    public SubMesh(int subMeshOffset, int length)
    {
        startIndex = subMeshOffset;
        indexCount = length;
    }
}

public class Mesh
{
    public Vector3[] vertices;
    public Vector3[] normals;
    public Vector4[] tangents;
    public Vector2[][] textureCoordinates;
    public Vector4[] colors;
    public int[] triangles;
    public SubMesh[] subMeshes;

    public int subMeshCount => subMeshes.Length;
    public int vertexCount => vertices.Length;

    public int[] GetTriangles(int submeshIndex)
    {
        if (submeshIndex >= subMeshes.Length)
        {
            throw new ArgumentException("Submesh index out of range");
        }
        var subMesh = subMeshes[submeshIndex];
        return triangles.Skip(subMesh.startIndex).Take(subMesh.indexCount).ToArray();
    }

    public void GetUVs(int channel, List<Vector4> uvList)
    {
        throw new NotImplementedException();
    }

    public void GetUVs(int channel, List<Vector3> uvList)
    {
        throw new NotImplementedException();
    }

    public void GetUVs(int channel, List<Vector2> uvList)
    {
        if (channel>=textureCoordinates.Length)
        {
            throw new ArgumentException("Channel index out of range");
        }

        if (textureCoordinates[channel] is null)
        {
            throw new ArgumentException("Channel is null");
        }

        uvList.AddRange(textureCoordinates[channel]);
    }
}
