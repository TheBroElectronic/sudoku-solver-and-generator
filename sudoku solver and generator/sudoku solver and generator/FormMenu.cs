using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku_solver_and_generator
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowMatrix(false, true, false);
        }

        int[,] sudoin = new int[,]{
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}};
        int[,] matrAux = new int[9, 9];
        SolverBackTracking bk = new SolverBackTracking();
        
        private void genBtn_Click(object sender, EventArgs e)
        {
            solveBtn.Enabled = true;
            bk.GenSudoku(sudoin);
            ShowMatrix(true,true,true);
            solveBtn.Enabled = true;
            matrAux = clone(sudoin);
        }//call the generator

        private void checkBtn_Click(object sender, EventArgs e)
        {
            bool check = true;
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (bk.Validate(sudoin, y, x, sudoin[y, x]) || sudoin[y, x]==0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == false) break;
            }
            if (check) MessageBox.Show("Correct!");
            else MessageBox.Show("Fail!");
        }//check solution

        private void solveBtn_Click(object sender, EventArgs e)
        {
            sudoin = matrAux;
            if (bk.BackTrackSolve1(sudoin)) ShowMatrix(false,false,false);
            else MessageBox.Show("imposible to solve");
        }//call the solver

        /// /////////////// ///
        //TOOLS AND FUNCTIONS//
        /// /////////////// ///
        //clone matrix
        int[,] clone(int[,] map)
        {
            int[,] aux = new int[9, 9];
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                    aux[y, x] = map[y, x];
            return aux;
        } 
        //show matrix in the buttons
        void ShowMatrix(bool b = false, bool ntPlay = false,bool env = true)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if ((y > 2 && 6 > y) && (x<3 || x>5) || (x > 2 && 6 > x) && (y < 3 || y > 5))
                        SwitchButton(y, x, false, true, ntPlay, env, true);
                    else SwitchButton(y, x, false, true, ntPlay, env, false);
                    if(b && sudoin[y, x] != 0)
                        SwitchButton(y, x, true);
                }
            }
        }
        //Buttons control
        void SwitchButton(int y, int x, bool paint, bool prnt = false, bool ntPlay = false, bool env = true, bool green = false)
        {
            System.Windows.Forms.Button[,] xd = {
                { button1, button2, button3, button4, button5, button6, button7, button8, button9 },
                { button10,button11,button12,button13,button14,button15,button16,button17,button18},
                { button19,button20,button21,button22,button23,button24,button25,button26,button27},
                { button28,button29,button30,button31,button32,button33,button34,button35,button36},
                { button37,button38,button39,button40,button41,button42,button43,button44,button45},
                { button46,button47,button48,button49,button50,button51,button52,button53,button54},
                { button55,button56,button57,button58,button59,button60,button61,button62,button63},
                { button64,button65,button66,button67,button68,button69,button70,button71,button72},
                { button73,button74,button75,button76,button77,button78,button79,button80,button81}};

            if (paint)
            {
                xd[y, x].BackColor = Color.Aqua;
                xd[y, x].Text = sudoin[y, x].ToString();
                xd[y, x].Enabled = false;
            }
            else
            {
                if (ntPlay)
                {
                    if (!green) xd[y, x].BackColor = Color.White;
                    else xd[y, x].BackColor = Color.Lime;
                    xd[y, x].Enabled = true;
                }
                if (!env) xd[y, x].Enabled = false;
                if (!prnt) sudoin[y, x] += 1;
                if (sudoin[y, x] > 9) sudoin[y, x] = 0;
                xd[y, x].Text = sudoin[y, x].ToString();
            }
        }
        
        
        /// ////////////////////////////////////////////////////////////////////// ///    
        //buttons matrix (omg)
        private void button1_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 0, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 1, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 2, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 3, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 4, false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 5, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 6, false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 7, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SwitchButton(0, 8, false);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 0, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 1, false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 2, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 3, false);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 4, false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 5, false);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 6, false);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 7, false);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SwitchButton(1, 8, false);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 0, false);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 1, false);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 2, false);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 3, false);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 4, false);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 5, false);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 6, false);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 7, false);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            SwitchButton(2, 8, false);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 0, false);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 1, false);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 2, false);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 3, false);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 4, false);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 5, false);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 6, false);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 7, false);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            SwitchButton(3, 8, false);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 0, false);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 1, false);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 2, false);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 3, false);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 4, false);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 5, false);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 6, false);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 7, false);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            SwitchButton(4, 8, false);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 0, false);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 1, false);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 2, false);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 3, false);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 4, false);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 5, false);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 6, false);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 7, false);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            SwitchButton(5, 8, false);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 0, false);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 1, false);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 2, false);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 3, false);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 4, false);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 5, false);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 6, false);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 7, false);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            SwitchButton(6, 8, false);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 0, false);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 1, false);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 2, false);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 3, false);
        }

        private void button68_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 4, false);
        }

        private void button69_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 5, false);
        }

        private void button70_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 6, false);
        }

        private void button71_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 7, false);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            SwitchButton(7, 8, false);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 0, false);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 1, false);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 2, false);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 3, false);
        }

        private void button77_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 4, false);
        }

        private void button78_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 5, false);
        }

        private void button79_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 6, false);
        }

        private void button80_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 7, false);
        }

        private void button81_Click(object sender, EventArgs e)
        {
            SwitchButton(8, 8, false);
        }
    }
}