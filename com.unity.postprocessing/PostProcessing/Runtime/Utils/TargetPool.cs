using System.Collections.Generic;

namespace UnityEngine.Rendering.PostProcessing
{
    class TargetPool
    {
        private const int MaxTargets = 100;

        readonly int[] m_Pool;
        int m_Current;

        internal TargetPool()
        {
            m_Pool = new int[MaxTargets];
            for (int i = 0; i < m_Pool.Length; ++i)
            {
                m_Pool[i] = Shader.PropertyToID("_TargetPool" + i);
            }
        }

        internal int Get()
        {
            int ret = Get(m_Current);
            ++m_Current;
            return ret;
        }

        int Get(int i)
        {
            return m_Pool[i % MaxTargets];
        }

        internal void Reset()
        {
            m_Current = 0;
        }
    }
}
