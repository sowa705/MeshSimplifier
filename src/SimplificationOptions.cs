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

using System;
using System.Runtime.InteropServices;

namespace MeshSimplifier
{
    /// <summary>
    /// Options for mesh simplification.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Auto)]
    public struct SimplificationOptions
    {
        /// <summary>
        /// If the border edges should be preserved.
        /// Default value: false
        /// </summary>
        public bool PreserveBorderEdges = false;
        /// <summary>
        /// If the UV seam edges should be preserved.
        /// Default value: false
        /// </summary>
        public bool PreserveUVSeamEdges = false;
        /// <summary>
        /// If the UV foldover edges should be preserved.
        /// Default value: false
        /// </summary>
        public bool PreserveUVFoldoverEdges = false;
        /// <summary>
        /// If the discrete curvature of the mesh surface be taken into account during simplification. Taking surface curvature into account can result in good quality mesh simplification, but it can slow the simplification process significantly.
        /// Default value: false
        /// </summary>
        public bool PreserveSurfaceCurvature = false;
        /// <summary>
        /// If a feature for smarter vertex linking should be enabled, reducing artifacts in the
        /// decimated result at the cost of a slightly more expensive initialization by treating vertices at
        /// the same position as the same vertex while separating the attributes.
        /// Default value: true
        /// </summary>
        public bool EnableSmartLink = true;
        /// <summary>
        /// The maximum distance between two vertices in order to link them.
        /// Note that this value is only used if EnableSmartLink is true.
        /// Default value: double.Epsilon
        /// </summary>
        public double VertexLinkDistance = double.Epsilon;
        /// <summary>
        /// The maximum iteration count. Higher number is more expensive but can bring you closer to your target quality.
        /// Sometimes a lower maximum count might be desired in order to lower the performance cost.
        /// Default value: 100
        /// </summary>
        public int MaxIterationCount = 100;
        /// <summary>
        /// The agressiveness of the mesh simplification. Higher number equals higher quality, but more expensive to run.
        /// Default value: 7.0
        /// </summary>
        public double Agressiveness = 7.0;
        /// <summary>
        /// If a manual UV component count should be used (set by UVComponentCount), instead of the automatic detection.
        /// Default value: false
        /// </summary>
        public bool ManualUVComponentCount = false;

        /// <summary>
        /// The UV component count. The same UV component count will be used on all UV channels.
        /// Default value: 2
        /// </summary>
        public int UVComponentCount = 2;

        public SimplificationOptions()
        {
        }
    }
}
