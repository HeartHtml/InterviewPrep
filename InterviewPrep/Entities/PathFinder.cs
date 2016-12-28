using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Entities
{
    public class PathFinder
    {
        public static List<Tuple<int, int>> FindPath(int[][] matrix)
        {
            List<Tuple<int, int>> path = null;

            if (matrix.Length > 0)
            {
                Stack<Tuple<int, int>> pathKeeper = new Stack<Tuple<int, int>>(matrix.Length);

                int xIndex = 0;

                int yIndex = 0;

                if (matrix[0][0] == 1)
                {
                    path = new List<Tuple<int, int>>(matrix.Length) { new Tuple<int, int>(0, 0)};

                    while (true)
                    {
                        bool moveDown = false;

                        if (CanMoveDown(xIndex, yIndex, matrix))
                        {
                            moveDown = true;

                            pathKeeper.Push(new Tuple<int, int>(xIndex + 1, yIndex));
                        }

                        if (CanMoveRight(xIndex, yIndex, matrix))
                        {
                            yIndex++;

                            Tuple<int, int> validPoint = new Tuple<int, int>(xIndex, yIndex);

                            path.Add(validPoint);

                            if (xIndex == matrix.Length - 1 && yIndex == matrix.Length - 1)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (xIndex == matrix.Length - 1 && yIndex == matrix.Length - 1)
                            {
                                break;
                            }

                            if (!moveDown && path.Count > 0)
                            {
                                path.RemoveAt(path.Count - 1);
                            }

                            Tuple<int, int> nextPotentialPoint = null;

                            if (pathKeeper.Count > 0)
                            {
                                nextPotentialPoint = pathKeeper.Pop();
                            }

                            if (nextPotentialPoint == null)
                            {
                                path = null;

                                break;
                            }

                            xIndex = nextPotentialPoint.Item1;

                            yIndex = nextPotentialPoint.Item2;

                            path.Add(new Tuple<int, int>(xIndex, yIndex));
                        }
                    }
                }
            }

            return path;
        }

        private static bool CanMoveRight(int x, int y, int[][] matrix)
        {
            if (y + 1 < matrix.Length)
            {
                int nextValue = matrix[x][y + 1];

                return nextValue == 1;
            }
            return false;
        }

        private static bool CanMoveDown(int x, int y, int[][] matrix)
        {
            if (x + 1 < matrix.Length)
            {
                int nextValue = matrix[x + 1][y];

                return nextValue == 1;
            }
            return false;
        }
    }
}
