using System;
using NUnit.Framework;
using SimpleAlgorithms;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestFixture()]
    public class RecursionBlockAnalizerTest
    {
        private Dictionary<int[,], List<Vector2Int>> _examples;

        [SetUp]
        public void InitializeExamples()
        {
            _examples = new TestExamples().Examples;
        }

        //Inititalization
        [Test]
        public void Initialization_EmptyField_ThrowException()
        {
            Field<int> field = null;

            Assert.Throws<NullReferenceException>( () => { var analizer = new RecursionBlockAnalizer<int>(field); });
        }

        //Finding (target position (0, 1))
        [Test]
        public void Finding_FieldContainsBlockInPosition_ReturnBlock()
        {
            foreach (var pair in _examples)
            {
                var field = new Field<int>(pair.Key);
                var analizer = new RecursionBlockAnalizer<int>(field);
                Vector2Int targetPosition = new Vector2Int(0, 1);

                var calculatedBlock = analizer.GetIncludedBlock(targetPosition).ToList();

                Assert.IsTrue(pair.Value.Except(calculatedBlock).Count() == 0);
            }
        }

        //Checking
        [Test]
        public void Checking_IsInBlock_ReturnTrue()
        {
            var field = new Field<int>(_examples.ElementAt(1).Key);
            var analizer = new RecursionBlockAnalizer<int>(field);
            Vector2Int targetPosition = new Vector2Int(0, 0);

            Assert.IsTrue( analizer.IsIncluded(targetPosition));
        }

        [Test]
        public void Checking_IsNotInBlock_ReturnFalse()
        {
            var field = new Field<int>(_examples.ElementAt(1).Key);
            var analizer = new RecursionBlockAnalizer<int>(field);
            Vector2Int targetPosition = new Vector2Int(1, 0);

            Assert.IsFalse(analizer.IsIncluded(targetPosition));
        }
    }
}
