using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlareTest.Model;
using FlareTest.Resources;

namespace FlareTest.Operations
{
    public class ShapesHandler
    {
        private Grid _grid;
        private List<Rectangle> _rectangles;
        private string Message = "";
        public ShapesHandler(Grid grid, List<Rectangle> rectangles)
        {
            _grid = grid;
            rectangles.RemoveAll(x => (x.X == 0 && x.Y == 0 && x.Height == 0 && x.Width == 0));
            _rectangles = rectangles;
        }
        /// <summary>
        /// publically available to validate the drawing
        /// </summary>
        /// <returns>returns the reusult of the drawing</returns>
        public string ValidateGrid()
        {
            try
            {
                if (!RectangleCrossedGrid())
                {
                    foreach (List<Rectangle> UniquePair in GetUniquePairsRectangles())
                    {
                        if (RectanglesOverlapped(UniquePair))
                        {
                            Message = Messages.OverLappingRectangles;
                            break;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Message = "Please check the input values, We are facing issue while processing your inputs.";
            }
            return Message == "" ? String.Format(Messages.ValidRectangles, _rectangles.Count().ToString()) : Message;
        }
        /// <summary>
        /// we will loop thorugh each rectangle and check borders against Grid borders
        /// </summary>
        public bool RectangleCrossedGrid()
        {
            bool result = false;
            foreach (Rectangle rect in _rectangles)
            {
                if (_grid.Height < rect.Height + rect.Y || _grid.Width < rect.X + rect.Width)
                {
                    Message = Messages.RectanlgeExtended;
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// the list containes 2 rectangles to cross check the overlapping
        /// </summary>
        /// <param name="rectangles">the list containes 2 rectangles to cross check the overlapping</param>
        public bool RectanglesOverlapped(List<Rectangle> rectangles)
        {
            if ((rectangles[0].Y + rectangles[0].Height <= rectangles[1].Y || rectangles[1].Y + rectangles[1].Height <= rectangles[0].Y) ||
                (rectangles[0].X + rectangles[0].Width <= rectangles[1].X || rectangles[1].X + rectangles[1].Width <= rectangles[0].X))
            {
                return false;
            }
            return true;
        }
        private List<List<Rectangle>> GetUniquePairsRectangles()
        {
            return _rectangles.SelectMany((first, i) => _rectangles.Skip(i + 1).Select(second => new List<Rectangle>() { first, second })).ToList();
        }

    }
}
