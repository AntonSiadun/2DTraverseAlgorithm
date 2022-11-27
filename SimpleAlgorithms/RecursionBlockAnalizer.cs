using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAlgorithms
{
    public class RecursionBlockAnalizer<T> : IBlockAnalizer
    {
        private readonly IMatrix<T> _field;

        public RecursionBlockAnalizer(IMatrix<T> field)
        {
            if (field == null)
                throw new NullReferenceException("Cannot initialize a block analizer: field is empty.");

            _field = field;
        }

        public List<List<Vector2Int>> GetAllBlocks()
        {
            var verified = new List<Vector2Int>();
            List<List<Vector2Int>> result = new List<List<Vector2Int>>();

            for(int i = 0; i < _field.Height; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    var position = new Vector2Int(i, j);

                    if (verified.Contains(position))
                        continue;

                    var block = GetIncludedBlock(position);
                    result.Add(block.ToList());

                    verified.AddRange(block.ToList());
                }
            }
            return result;
        }

        public HashSet<Vector2Int> GetIncludedBlock(Vector2Int position)
        {
            var result = new HashSet<Vector2Int>();

            CheckAmbient(result, position);

            return result;
        }

        private void CheckAmbient(HashSet<Vector2Int> list,Vector2Int position)
        {
            list.Add(position);

            CheckDirection(list, position, new Vector2Int(0, 1));
            CheckDirection(list, position, new Vector2Int(1, 0));
            CheckDirection(list, position, new Vector2Int(0, -1));
            CheckDirection(list, position, new Vector2Int(-1, 0));
        }

        private void CheckDirection(HashSet<Vector2Int> list, Vector2Int position, Vector2Int direction)
        {
            try
            {
                var neigbourPosition = position + direction;

                var targetItem = _field[position];
                var neigbourItem = _field[neigbourPosition];

                if (targetItem.Equals(neigbourItem) && !list.Contains(neigbourPosition))
                {
                    CheckAmbient(list,neigbourPosition);
                }
            }
            catch
            {
                Console.WriteLine("Cannot check from position: {0} in direction: {1}.", position, direction);
            }

        }

        public bool IsIncluded(Vector2Int position)
        {
            return GetIncludedBlock(position).Count > 1;
        }
    }
}
