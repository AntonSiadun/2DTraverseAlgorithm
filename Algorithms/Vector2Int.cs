namespace Algorithms
{
    public struct Vector2Int
    {
        public readonly int Column;
        public readonly int Row;

        public Vector2Int(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public static Vector2Int operator +(Vector2Int vectorA, Vector2Int vectorB)
        {
            return new Vector2Int(vectorA.Row + vectorB.Row,
                                  vectorA.Column + vectorB.Column);
        }

        public static Vector2Int operator -(Vector2Int vectorA, Vector2Int vectorB)
        {
            return new Vector2Int(vectorA.Row - vectorB.Row,
                                  vectorA.Column - vectorB.Column);
        }

        public override string ToString()
        {
            return "row: "+Row+", column: "+Column;
        }
    }
}
