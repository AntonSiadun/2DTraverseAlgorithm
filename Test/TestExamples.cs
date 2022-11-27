using System.Collections.Generic;
using Algorithms;

namespace Test
{
    public class TestExamples
    {
        public readonly Dictionary<int[,], List<Vector2Int>> Examples;

        public TestExamples()
        {
            Examples = new Dictionary<int[,], List<Vector2Int>>();

            Examples.Add(new int[1, 3] { { 1, 1, 1 } },
                new List<Vector2Int> { new Vector2Int(0, 0),
                new Vector2Int(0, 1), new Vector2Int(0, 2) });

            Examples.Add(new int[2, 3] { { 1, 1, 1 }, { 0, 1, 2 } },
                new List<Vector2Int> { new Vector2Int(0, 0),
                new Vector2Int(0, 1), new Vector2Int(0, 2),
                new Vector2Int(1, 1)});

            Examples.Add(new int[3, 3] { { 3, 1, 0 }, { 1, 1, 1 }, { 0, 1, 2 } },
                new List<Vector2Int> { new Vector2Int(0, 1),
                new Vector2Int(1, 0), new Vector2Int(1, 1),
                new Vector2Int(1, 2), new Vector2Int(2, 1)});

            Examples.Add(new int[3, 3] { { 1, 0, 2 }, { 0, 0, 3 }, { 0, 1, 1 } },
                new List<Vector2Int> { new Vector2Int(0, 1),
                new Vector2Int(1, 1), new Vector2Int(1, 0),
                new Vector2Int(2, 0)});

            Examples.Add(new int[3, 3] { { 1, 0, 0 }, { 1, 0, 0 }, { 0, 1, 1 } },
                new List<Vector2Int> { new Vector2Int(0, 1),
                new Vector2Int(1, 1), new Vector2Int(1, 2),
                new Vector2Int(0, 2)});

            Examples.Add(new int[4, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 2, 2, 1 }, { 0, 1, 1 } },
                new List<Vector2Int> { new Vector2Int(0, 1),
                new Vector2Int(1, 0), new Vector2Int(1, 1),
                new Vector2Int(1, 2), new Vector2Int(2, 2),
                new Vector2Int(3, 2), new Vector2Int(3, 1)});
        }
    }
}
