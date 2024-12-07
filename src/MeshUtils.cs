/*
MIT License

Copyright(c) 2017-2020 Mattias Edlund

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#if UNITY_2018_2_OR_NEWER
#define UNITY_8UV_SUPPORT
#endif

using System;
using System.Collections.Generic;
using System.Numerics;

namespace MeshSimplifier
{
    /// <summary>
    /// Contains utility methods for meshes.
    /// </summary>
    public static class MeshUtils
    {
        /// <summary>
        /// The count of supported UV channels.
        /// </summary>
        public static readonly int UVChannelCount = 4;

        /// <summary>
        /// Returns the UV sets for a specific mesh.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <returns>The UV sets.</returns>
        public static IList<Vector4>[] GetMeshUVs(Mesh mesh)
        {
            if (mesh == null)
                throw new ArgumentNullException(nameof(mesh));

            var uvs = new IList<Vector4>[UVChannelCount];
            for (int channel = 0; channel < UVChannelCount; channel++)
            {
                uvs[channel] = GetMeshUVs(mesh, channel);
            }
            return uvs;
        }

        /// <summary>
        /// Returns the 2D UV list for a specific mesh and UV channel.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="channel">The UV channel.</param>
        /// <returns>The UV list.</returns>
        public static IList<Vector2> GetMeshUVs2D(Mesh mesh, int channel)
        {
            if (mesh == null)
                throw new ArgumentNullException(nameof(mesh));
            else if (channel < 0 || channel >= UVChannelCount)
                throw new ArgumentOutOfRangeException(nameof(channel));

            var uvList = new List<Vector2>(mesh.vertexCount);
            mesh.GetUVs(channel, uvList);
            return uvList;
        }

        /// <summary>
        /// Returns the 3D UV list for a specific mesh and UV channel.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="channel">The UV channel.</param>
        /// <returns>The UV list.</returns>
        public static IList<Vector3> GetMeshUVs3D(Mesh mesh, int channel)
        {
            if (mesh == null)
                throw new ArgumentNullException(nameof(mesh));
            else if (channel < 0 || channel >= UVChannelCount)
                throw new ArgumentOutOfRangeException(nameof(channel));

            var uvList = new List<Vector3>(mesh.vertexCount);
            mesh.GetUVs(channel, uvList);
            return uvList;
        }

        /// <summary>
        /// Returns the 4D UV list for a specific mesh and UV channel.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="channel">The UV channel.</param>
        /// <returns>The UV list.</returns>
        public static IList<Vector4> GetMeshUVs(Mesh mesh, int channel)
        {
            if (mesh == null)
                throw new ArgumentNullException(nameof(mesh));
            else if (channel < 0 || channel >= UVChannelCount)
                throw new ArgumentOutOfRangeException(nameof(channel));

            var uvList = new List<Vector4>(mesh.vertexCount);
            mesh.GetUVs(channel, uvList);
            return uvList;
        }

        /// <summary>
        /// Returns the number of used UV components in a UV set.
        /// </summary>
        /// <param name="uvs">The UV set.</param>
        /// <returns>The number of used UV components.</returns>
        public static int GetUsedUVComponents(IList<Vector4> uvs)
        {
            if (uvs == null || uvs.Count == 0)
                return 0;

            int usedComponents = 0;
            foreach (var uv in uvs)
            {
                if (usedComponents < 1 && uv.X != 0f)
                {
                    usedComponents = 1;
                }
                if (usedComponents < 2 && uv.Y != 0f)
                {
                    usedComponents = 2;
                }
                if (usedComponents < 3 && uv.Z != 0f)
                {
                    usedComponents = 3;
                }
                if (usedComponents < 4 && uv.W != 0f)
                {
                    usedComponents = 4;
                    break;
                }
            }

            return usedComponents;
        }

        /// <summary>
        /// Converts a list of 4D UVs into 2D.
        /// </summary>
        /// <param name="uvs">The list of UVs.</param>
        /// <returns>The array of 2D UVs.</returns>
        public static Vector2[] ConvertUVsTo2D(IList<Vector4> uvs)
        {
            if (uvs == null)
                return null;

            var uv2D = new Vector2[uvs.Count];
            for (int i = 0; i < uv2D.Length; i++)
            {
                var uv = uvs[i];
                uv2D[i] = new Vector2(uv.X, uv.Y);
            }
            return uv2D;
        }

        /// <summary>
        /// Converts a list of 4D UVs into 3D.
        /// </summary>
        /// <param name="uvs">The list of UVs.</param>
        /// <returns>The array of 3D UVs.</returns>
        public static Vector3[] ConvertUVsTo3D(IList<Vector4> uvs)
        {
            if (uvs == null)
                return null;

            var uv3D = new Vector3[uvs.Count];
            for (int i = 0; i < uv3D.Length; i++)
            {
                var uv = uvs[i];
                uv3D[i] = new Vector3(uv.X, uv.Y, uv.Z);
            }
            return uv3D;
        }
    }
}
