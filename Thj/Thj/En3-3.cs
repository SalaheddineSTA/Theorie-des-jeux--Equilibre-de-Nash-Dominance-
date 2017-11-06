using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thj
{
    public partial class En : MetroFramework.Forms.MetroForm
    {
        public En()
        {
            InitializeComponent();
            panelChange();


        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            panelChange();
        }

        String Methode = "Pure";
        public void panelChange()
        {
            
            if (metroToggle1.Checked)
            {
                Methode = "Pure";
                metroLabel1.Text = "Strategie Pure";
            }
            else
            {
                
                Methode = "Mixed";
                metroLabel1.Text = "Strategie Mixed";
            }
            
        }

        public void reset()
        {
           
        }

        String Profile = "";
        public void mixed_nash(decimal[,] jr1 , decimal[,] jr2 , String str)
        {


            if (str.Equals("Pure"))
            {
                int s1 = 3, s2 = 3;
                int col_ = 0, line_ = 0;
                int[,] pile1 = new int[s1 * s2, s1 * s2];
                int[,] pile2 = new int[s1 * s2, s1 * s2];
                String[,] St = new String[s1, s2];
                St[0, 0] = "1";
                St[0, 1] = "2";
                St[0, 2] = "3";

                St[1, 0] = "4";
                St[1, 1] = "5";
                St[1, 2] = "6";

                St[2, 0] = "7";
                St[2, 1] = "8";
                St[2, 2] = "9";

                // Profile = "EN Trouvés Dans Ce jeu en Strategie Pure sont:\n";
                Profile = "";
                for (int j = 0; j < s2; j++)
                {
                    int x, y;
                    decimal max = -10;

                    for (int i = 0; i < s1; i++)
                    {
                        if (max < jr1[i, j])
                        {
                            max = jr1[i, j];
                        }
                    }

                    for (int i = 0; i < s1; i++)
                    {
                        if (jr1[i, j] == max)
                        {
                            max = jr1[i, j];
                            x = i;
                            y = j;
                            pile1[0, col_] = x;
                            pile1[1, col_] = y;
                            col_++;
                        }
                    }
                }

                for (int i = 0; i < s1; i++)
                {
                    int x, y;
                    decimal max = -10;
                    for (int j = 0; j < s2; j++)
                    {
                        if (max < jr2[i, j])
                        {
                            max = jr2[i, j];

                        }
                    }

                    for (int j = 0; j < s2; j++)
                    {
                        if (max == jr2[i, j])
                        {
                            max = jr2[i, j];
                            x = i;
                            y = j;
                            pile2[0, line_] = x;
                            pile2[1, line_] = y;
                            line_++;
                        }
                    }
                }

                for (int i = 0; i < col_; i++)
                {
                    int x, y;
                    for (int j = 0; j < line_; j++)
                    {
                        if (pile1[0, i] == pile2[0, j] && pile1[1, i] == pile2[1, j])
                        {
                            x = pile2[0, j];
                            y = pile2[1, j];
                            Profile = Profile + St[x, y];
                        }

                    }
                }
                if (Profile.Equals(""))
                    Profile = "iL n'Existe pas un EN dans Ce jeu";
            }
            else
            {
                Profile = "Not Yet x)";
                decimal a, b, c, a1, b1, c1;
                decimal _a, _b, _c, _a1, _b1, _c1;
                String q1="", q2 = "", q3 = "", p1 = "", p2 = "", p3 = "";

                Boolean exist1 = false, 
                        exist2 = false;

                a = (jr1[0, 0] - jr1[0, 2]) - (jr1[2, 0] - jr1[2, 2]);
                b = (jr1[0, 1] - jr1[0, 2]) - (jr1[2, 1] - jr1[2, 2]);
                c = jr1[0, 2] - jr1[2, 2];

                a1 = (jr1[1, 0] - jr1[1, 2]) - (jr1[2, 0] - jr1[2, 2]);
                b1 = (jr1[1, 1] - jr1[1, 2]) - (jr1[2, 1] - jr1[2, 2]);
                c1 = jr1[1, 2]  - jr1[2, 2];


                // Resloustion de systeme : 
                // a(q1)+b(q2)+c =0  
                // a1(q1)+b1(q2)+c1=0

                decimal Dx, Dy, Dc;
                Dx = b * c1 - c * b1;
                Dy = a * c1 - c * a1;
                Dc = a * b1 - b * a1;
                if(Dc !=0)
                {
                    Dy *= -1;
                    if ( (Dx * Dc > 0) && (Dy * Dc > 0) &&  (Dx/Dc < 1) && (Dy/Dc < 1) )
                         exist1 = true;
                    if (exist1)
                    {
                        Dx = Math.Abs(Dx);
                        Dy = Math.Abs(Dy);
                        Dc = Math.Abs(Dc);

                        q1 = "" + Dx + "/" + Dc;
                        q2 = "" + Dy + "/" + Dc;
                        decimal r= Dc - (Dx + Dy);
                        q3= "" + r + "/" + Dc;
                    }
                    



                }
                 
                //***********************

                _a = (jr2[0, 0] - jr2[2, 0])  - (jr2[0, 2] - jr2[2, 2]);
                _b = (jr2[1, 0] - jr2[2, 0])  - (jr2[1, 2] - jr2[2, 2]);
                _c = jr2[2, 0] - jr2[2, 2];

                _a1 = (jr2[0, 1] - jr2[2, 1]) - (jr2[0, 2] - jr2[2, 2]); 
                _b1 = (jr2[1, 1] - jr2[2, 1]) - (jr2[1, 2] - jr2[2, 2]);
                _c1 =  jr2[2, 1] - jr2[2, 2];


                decimal Dx1, Dy1, Dc1;
                Dx1 = _b * _c1 - _c * _b1;
                Dy1 = _a * _c1 - _c * _a1;
                Dc1 = _a * _b1 - _b * _a1;
                if (Dc1 != 0)
                {
                    Dy1 *= -1;
                    if ((Dx1 * Dc1 > 0) && (Dy1 * Dc1 > 0) && (Dx1 / Dc1 < 1) && (Dy1 / Dc1 < 1))
                        exist2= true;
                    if (exist2)
                    {
                        Dx1 = Math.Abs(Dx1);
                        Dy1 = Math.Abs(Dy1);
                        Dc1 = Math.Abs(Dc1);

                        p1 = "" + Dx1 + "/" + Dc1;
                        p2 = "" + Dy1 + "/" + Dc1;
                        decimal r = Dc1 - (Dx1 + Dy1);
                        p3 = "" + r + "/" + Dc1;
                    }




                }
                if(exist1 && exist2)
                {
                    label1.Text =q1;
                    label2.Text =q2;
                    label3.Text =q3;

                    label4.Text =p1;
                    label5.Text =p2;
                    label6.Text =p3;
                }
                else
                {
                    Profile = "il n'existe pas un equilibre de nash dans ce jeu";
                }
                // Profile = "-l'equation :\n" + a + "( q1 )" + b + "( q2 )" + c + "=0\n" + a1 + "( q1 )" + b1 + "( q2 )" + c1 + "=0";
                //Profile = Profile+"\n for the Second player \n- l'equation :\n" + _a + "( p1 )" + _b + "( p2 )" + _c + "=0\n" + _a1 + "( p1 )" + _b1 + "( p2 )" + _c1 + "=0";
                //Profile = Profile + "\n The result is :\nQ1=" +q1+ ";  Q2=" + q2 + ";  Q3=" + q3;
                //Profile = Profile + "\n The result is :\nP1=" + p1 + ";  P2=" +p2 + ";  P3=" + p3;
            }

        }






















        private void metroTile1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel5.BackColor = Color.White;
            panel6.BackColor = Color.White;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
            panel9.BackColor = Color.White;
            //val0_0

            decimal[,] mat_joueur1 = new decimal[3, 3];
            decimal[,] mat_joueur2 = new decimal[3, 3];
            //intilize the two matrices : 

            //Matrice 1 :
            mat_joueur1[0, 0] = val0_0.Value;  mat_joueur1[0, 1] = val0_1.Value; mat_joueur1[0, 2]  = val0_2.Value;
            mat_joueur1[1, 0] = val1_0.Value;  mat_joueur1[1, 1] = val1_1.Value; mat_joueur1[1, 2]  = val1_2.Value;
            mat_joueur1[2, 0] = val2_0.Value;  mat_joueur1[2, 1] = val2_1.Value; mat_joueur1[2, 2]  = val2_2.Value;




            //Marice 2 : 
            //Matrice 1 :
            mat_joueur2[0, 0] = val20_0.Value; mat_joueur2[0, 1] = val20_1.Value; mat_joueur2[0, 2] = val20_2.Value;
            mat_joueur2[1, 0] = val21_0.Value; mat_joueur2[1, 1] = val21_1.Value; mat_joueur2[1, 2] = val21_2.Value;
            mat_joueur2[2, 0] = val22_0.Value; mat_joueur2[2, 1] = val22_1.Value; mat_joueur2[2, 2] = val22_2.Value;

            String mat1 = "\n", mat2 = "\n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    mat1 = mat1 + " mat_joueur1[" + i + "," + j + "] = " + mat_joueur1[i, j] + "\t";

                mat1 = mat1 + "\n";
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    mat2 = mat2 + " mat_joueur2[" + i + "," + j + "] = " + mat_joueur2[i, j] + "\t";

                mat2 = mat2 + "\n";
            }

            //MessageBox.Show("La strategie est : "+Methode+"\nLa matrice de premier joueur est :" + mat1 + "\nla matrice de deuxieme joueur est :" + mat2 + "\nLa Solution Est : " + Profile);

            mixed_nash(mat_joueur1, mat_joueur2, Methode);

            if (Methode.Equals("Pure"))
            {
                if (Profile.Equals(""))
                {
                    MessageBox.Show("\n iL n'Existe pas un EN dans Ce jeu\n");
                }
                else
                {
                    int max = Profile.Length;

                    // MessageBox.Show("Profile is : " + Profile + "\nlengnt is: " + max);

                    for (int i = 0; i < max; i++)
                    {
                        char str = Profile[i];
                        //Console.WriteLine(str);

                        switch (str)
                        {
                            case '1':
                                panel1.BackColor = Color.Aqua;
                            break;

                            case '2':
                                panel2.BackColor = Color.Aqua;
                            break;

                            case '3':
                                panel3.BackColor = Color.Aqua;
                            break;

                            case '4':
                                panel4.BackColor = Color.Aqua;
                            break;

                            case '5':
                                panel5.BackColor = Color.Aqua;
                            break;

                            case '6':
                                panel6.BackColor = Color.Aqua;
                            break;

                            case '7':
                                panel7.BackColor = Color.Aqua;
                            break;

                            case '8':
                                panel8.BackColor = Color.Aqua;
                            break;

                            case '9':
                                panel9.BackColor = Color.Aqua;
                            break;
                            

                        }

                    }

                }

            }

            else//Mixed
            {
                MessageBox.Show("\n Le resultat est :\n" + Profile);
            }



        }
    }
}
