using System.Collections.Generic;

namespace SimpleAlgorithms
{
    public interface IBlockAnalizer
    {
        //Finding block of objects in field
        public HashSet<Vector2Int>[] GetAllBlocks();
        public HashSet<Vector2Int> GetIncludedBlock(Vector2Int position);
        //Check, that object is included in some block
        public bool IsIncluded(Vector2Int position);
    }
}
