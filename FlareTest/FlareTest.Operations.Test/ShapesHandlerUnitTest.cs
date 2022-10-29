using FlareTest.Model;

namespace FlareTest.Operations.Test
{
    [TestClass]
    public class ShapesHandlerUnitTest
    {
        private ShapesHandler _shapesHandler;
        MockData CorrectData = new MockData("Correct");
        MockData OverlapData = new MockData("Overlap");
        MockData ExtendedData = new MockData("Extended");
        string expectedCorrect = "3 valid rectangle(s) on a grid";
        string expectedOverLap = "Overlapping rectangles";
        string expectedExtend = "Rectangle extending beyond grid";
        string result = "";

        [TestMethod]
        public void TestValidateGraphValid()
        {
            _shapesHandler = new ShapesHandler(CorrectData._grid, CorrectData._rectangles);
            result = _shapesHandler.ValidateGrid();
            Assert.AreEqual(expectedCorrect, result);
        }
        [TestMethod]
        public void TestValidateGraphOverLap()
        {
            _shapesHandler = new ShapesHandler(OverlapData._grid, OverlapData._rectangles);
            result = _shapesHandler.ValidateGrid();
            Assert.AreEqual(expectedOverLap, result);
        }
        [TestMethod]
        public void TestValidateGraphExtended()
        {
            _shapesHandler = new ShapesHandler(ExtendedData._grid, ExtendedData._rectangles);
            result = _shapesHandler.ValidateGrid();
            Assert.AreEqual(expectedExtend, result);
        }

        [TestMethod]
        public void TestRectanglesOverlapped()
        {
            _shapesHandler = new ShapesHandler(ExtendedData._grid, ExtendedData._rectangles);
            Assert.AreEqual(true, _shapesHandler.RectanglesOverlapped(OverlapData._rectangles.GetRange(0, 2)));
        }
        [TestMethod]
        public void TestRectangleCrossedGrid()
        {
            _shapesHandler = new ShapesHandler(ExtendedData._grid, ExtendedData._rectangles);
            Assert.AreEqual(true, _shapesHandler.RectangleCrossedGrid());
        }
    }
    public class MockData
    {
        internal List<Rectangle> _rectangles { get; set; }
        internal Grid _grid { get; set; }
        public MockData(string type)
        {
            _grid = new Grid() { X = 0, Y = 0, Height = 25, Width = 25 };
            switch (type)
            {
                case "Overlap":
                    _rectangles = OverlapData();
                    break;
                case "Extended":
                    _rectangles = ExtendedData();
                    break;
                default:
                    _rectangles = CorrectData();
                    break;
            }
        }
        internal List<Rectangle> CorrectData()
        {
            return new List<Rectangle>()
            {
                new Rectangle()
                {
                    X=1,Y=1,Width=5,Height=5
                },
                 new Rectangle()
                {
                    X=7,Y=7,Width=3,Height=3
                },
                  new Rectangle()
                {
                    X=12,Y=12,Width=9,Height=9
                },
            };
        }
        internal List<Rectangle> OverlapData()
        {
            return new List<Rectangle>()
            {
                new Rectangle()
                {
                    X=1,Y=1,Width=5,Height=5
                },
                 new Rectangle()
                {
                    X=3,Y=2,Width=10,Height=10
                },
                  new Rectangle()
                {
                    X=12,Y=12,Width=9,Height=9
                },
            };
        }
        internal List<Rectangle> ExtendedData()
        {
            return new List<Rectangle>()
            {
                new Rectangle()
                {
                    X=1,Y=1,Width=5,Height=55
                },
                 new Rectangle()
                {
                    X=7,Y=7,Width=3,Height=3
                },
                  new Rectangle()
                {
                    X=12,Y=12,Width=9,Height=9
                },
            };
        }
    }
}
