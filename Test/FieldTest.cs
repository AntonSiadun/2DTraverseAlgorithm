using NUnit.Framework;
using System;
using SimpleAlgorithms;

namespace Test
{
    [TestFixture()]
    public class FieldTest
    {
        //Correct inititalization
        [Test]
        public void Initialization_StartWidth_MustBeEqualToFieldWidth()
        {
            var width = 10;
            var field = new Field<int>(1, width);
            var array = field.GetArray();

            Assert.AreEqual(width, array.GetLength(1));
        }

        [Test]
        public void Initialization_StartHeight_MustBeEqualToFieldHeight()
        {
            var height = 10;
            var field = new Field<int>(height, 1);
            var array = field.GetArray();

            Assert.AreEqual(height, array.GetLength(0));
        }

        [Test]
        public void Initialization_NonPositiveWidth_GeneratesException()
        {
            var width = -1;

            Assert.Throws<ArgumentException>( () => new Field<int>(1, width) );
        }

        [Test]
        public void Initialization_NonPositiveHeight_GeneratesException()
        {
            var height = -1;

            Assert.Throws<ArgumentException>(() => new Field<int>(height, 1));
        }

        [Test]
        public void Initialization_WithArray_ArrayIsTheSame()
        {
            int[,] array = new int[1, 3] { { 1, 2, 3 } };

            var field = new Field<int>(array);

            Assert.AreEqual(array[0, 0], field.GetArray()[0, 0]);
        }

        //Item reading
        [Test]
        public void Reading_GetWidth_ReturnCorrectValue()
        {
            var width = 10;
            var field = new Field<int>(1, width);

            Assert.AreEqual(width, field.Width);
        }

        [Test]
        public void Reading_GetHeight_ReturnCorrectValue()
        {
            var height = 10;
            var field = new Field<int>(height, 1);

            Assert.AreEqual(height, field.Height);
        }

        [Test]
        public void Reading_PositionIsOutOfRange_ThrowsException()
        {
            var width = 10;
            var height = 10;
            var rowInPosition = 11;
            var colInPosition = -1;
            var field = new Field<int>(height, width);
            int result;

            Assert.Throws<IndexOutOfRangeException>(() =>
                        result = field[new Vector2Int(rowInPosition, colInPosition)]);
        }

        //Item saving
        [Test]
        public void Saving_PositionIsOutOfRange_ThrowsException()
        {
            var width = 10;
            var height = 10;
            var rowInPosition = 11;
            var colInPosition = 5;
            var field = new Field<int>(height, width);

            Assert.Throws<IndexOutOfRangeException>( () =>
                        field[new Vector2Int(rowInPosition,colInPosition)] = 0);
        }

        [Test]
        public void Saving_NegativePosition_ThrowsException()
        {
            var width = 10;
            var height = 10;
            var rowInPosition = 5;
            var colInPosition = -1;
            var field = new Field<int>(height, width);

            Assert.Throws<IndexOutOfRangeException>(() =>
                        field[new Vector2Int(rowInPosition, colInPosition)] = 0);
        }

        [Test]
        public void Saving_SetElement_IsEqualToFirst()
        {
            var width = 10;
            var height = 10;
            var rowInPosition = 5;
            var colInPosition = 4;
            var field = new Field<int>(height, width);
            var value = 3;

            field[new Vector2Int(rowInPosition, colInPosition)] = value;
            var array = field.GetArray();

            Assert.AreEqual(value, array[rowInPosition, colInPosition]);
        }

        //Array
        [Test]
        public void Array_GetCopy_SizesAreEquals()
        {
            var width = 2;
            var height = 3;
            var field = new Field<int>(height, width);

            var array = field.GetArray();

            Assert.AreEqual(width, array.GetLength(1));
            Assert.AreEqual(height, array.GetLength(0));
        }

        [Test]
        public void Array_GetCopyWithItem_ItemSavedAfterCoping()
        {
            var width = 2;
            var height = 3;
            var field = new Field<int>(height, width);
            var rowPosition = 1;
            var colPosition = 0;
            var value = 6;

            field[new Vector2Int(rowPosition, colPosition)] = value;
            var array = field.GetArray();

            Assert.AreEqual(value, array[rowPosition, colPosition]);
        }
    }
}
