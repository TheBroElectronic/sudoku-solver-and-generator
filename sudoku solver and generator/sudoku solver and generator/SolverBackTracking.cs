using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_solver_and_generator
{
    class SolverBackTracking
    {
        public bool Validate(int[,] map, int ypos, int xpos, int num)
        {
            //revisar por y
            for (int y = 0; y < 9; y++)
                if (map[y, xpos] == num && y != ypos)
                    return false;
            //revisar por x
            for (int x = 0; x < 9; x++)
                if (map[ypos, x] == num && x != xpos)
                    return false;

            //funcion para calcular por cuadriculas
            int sqrt = (int)Math.Sqrt(map.GetLength(0));
            int boxRowStart = ypos - ypos % sqrt;
            int boxColStart = xpos - xpos % sqrt;

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
            {
                for (int d = boxColStart; d < boxColStart + sqrt; d++)
                {
                    if (map[r, d] == num && r != ypos && d != xpos)
                    {
                        return false;
                    }
                }
            }
            return true;
        }//validar el numero escogido (bool)

        public void GenSudoku(int[,] map)
        {
            Random ran = new Random();
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    map[y, x] = 0;
                    if (ran.Next(1,5) == 3)
                    {
                        int aux = ran.Next(1, 9);
                        if (Validate(map, y, x, aux))
                            map[y, x] = aux;
                    }
                }
            }
        }

        public bool BackTrackSolve1(int[,] map)
        {
            int columna=0, fila=0;
            bool Resolved = true;
            //buscar lugares que esten vacios (con 0)
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if(map[y,x] == 0)
                    {
                        fila = y;
                        columna = x;
                        Resolved = false;
                        break;
                    }
                }
                if (Resolved == false) break;
            }

            //si no hay espacios vacios esta resuelto
            if (Resolved)
                return true;

            // retroalimentacion
            for (int i = 1; i < 10; i++)
            {
                if (Validate(map, fila, columna, i))
                {
                    map[fila, columna] = i;
                    if (!BackTrackSolve1(map))
                        map[fila, columna] = 0;

                    else return true;
                }
            } 
            return Resolved;
        }

        //public bool BackTrackSolve2(int[,] map, int x, int y)
        //{
        //    bool result = true;

        //    return result;
        //}
    }
}
