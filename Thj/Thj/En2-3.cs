using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace Thj
{
    public partial class En2_3 : MetroFramework.Forms.MetroForm
    {
        public En2_3()
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

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void En2_3_Load(object sender, EventArgs e)
        {

        }


        String Profile = "";
        public String Nash(decimal[,] jr1, decimal[,] jr2, String str)
        {
            

            if (str.Equals("Pure"))
            {
                int s1 = 2, s2 = 3;
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
                            //3System.out.println("("+x+","+y+")");
                            //System.out.println("(" + jr1[x][y] + "," + jr2[x,y] + ")");
                            Profile = Profile + St[x, y];
                        }

                    }
                }
                if (Profile.Equals(""))
                    Profile = "iL n'Existe pas un EN dans Ce jeu";
            }
            else// Handle The Mixed 
            {
                String q = "", qq = "";
                decimal r2, r, a, b, a2, b2;
                Boolean Exist;
                Profile = "";

                for (int i = 0; i < 3; i++)
                {
                    int xx, yy;
                    Exist = false;
                   
                    

                    if (i != 2) // (0,1) and (1,2)
                    {
                        xx = i;
                        yy = i + 1;
                    }
                    else
                    {
                        xx = 0;
                        yy = 2;
                    }

                    a = (jr1[0,xx] - jr1[0,yy]) - (jr1[1,xx] - jr1[1,yy]);
                    b = jr1[0,yy] - jr1[1,yy];

                    if (a != 0)
                    {


                        r = (-b) / a;
                        if (r < 1 && r > 0)
                        {
                            Exist = true;
                            decimal s = a - (-b);

                            if (a < 0)
                                a = a * -1;

                            if (b < 0)
                                b = b * -1;

                            if (s < 0)
                                s = s * -1;

                            q = "" + b + "/" + a;
                            qq = "" + s + "/" + a;

                            switch (i)
                            {
                                case 0:
                                    Profile = Profile + "\n -(X1 , X2 , 0) On a la Strategie Mixte de 1ere Joueur est : ( " + q + " , " + qq + " , 0 )";
                                break;

                                case 1:
                                    Profile = Profile + "\n  -(0 , X2 , X3) On a la Strategie Mixte de 1ere Joueur: ( 0, " + q + " , " + qq + " )";
                                    break;

                                case 2:
                                    Profile = Profile + "\n -(X1 , 0 , X3) On a la Strategie Mixte de 1ere Joueur: ( " + q + " , 0 ," + qq + " )";
                                break;
                            }

                        }

                    }
                   

                    if (Exist)
                    {


                        a2 = (jr2[0,xx] - jr2[1,xx]) - (jr2[0,yy] - jr2[1,yy]);
                        b2 = jr2[1,xx] - jr2[1,yy];

                        if (a != 0)
                        {
                            r2 = (-b2) / a2;
                            if (r2 < 1)
                            {
                               
                                decimal s = a2 - (-b2);
                                q = "" + -b2 + "/" + a2;
                                qq = "" + s + "/" + a2;
                                Profile = Profile + "\n-(Q , 1-Q) On La Strategie Mixte de 2eme Joueur: (" + q + "," + qq + ")";
                            }
                            else
                            {
                                Profile = Profile + "\n Dans Ce Cas N ' existe pas un EN";
                            }
                        }
                    }
                    else
                    {
                        Profile = Profile + "\n Dans Ce Cas N ' existe pas un EN";
                    }


                }

            }

            return Profile;
        }














        private void metroTile1_Click(object sender, EventArgs e)
        {

            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel5.BackColor = Color.White;
            panel6.BackColor = Color.White;

            decimal[,] mat_joueur1 = new decimal[2, 3];
            decimal[,] mat_joueur2 = new decimal[2, 3];
            //intilize the two matrices : 

            //Matrice 1 :
            mat_joueur1[0, 0] = val0_0.Value; mat_joueur1[0, 1] = val0_1.Value; mat_joueur1[0, 2] = val0_2.Value;
            mat_joueur1[1, 0] = val1_0.Value; mat_joueur1[1, 1] = val1_1.Value; mat_joueur1[1, 2] = val1_2.Value;
          




            //Marice 2 : 
           
            mat_joueur2[0, 0] = val20_0.Value; mat_joueur2[0, 1] = val20_1.Value; mat_joueur2[0, 2] = val20_2.Value;
            mat_joueur2[1, 0] = val21_0.Value; mat_joueur2[1, 1] = val21_1.Value; mat_joueur2[1, 2] = val21_2.Value;


            Nash(mat_joueur1, mat_joueur2, Methode);
            /***************************************************************************************************************/
            if (Methode.Equals("Pure"))
            {
                if (Profile.Equals(""))
                {
                    MessageBox.Show("\n iL n'Existe pas un Equilibre de Nash dans Ce jeu\n");
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



                        }

                    }

                }

            }

            else//Mixed
            {
                MessageBox.Show("\n Le resultat est :\n" + Profile);
            }
            /******************************************************************************************************************/
            //MessageBox.Show("La Solution Est : " + Profile);
            /*

            String mat1 = "", mat2 = "";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                    mat1 = mat1 + " mat_joueur1[" + i + "," + j + "] = " + mat_joueur1[i, j] + "\t";

                mat1 = mat1 + "\n";
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j <3; j++)
                    mat2 = mat2 + " mat_joueur2[" + i + "," + j + "] = " + mat_joueur2[i, j] + "\t";

                mat2 = mat2 + "\n";
            }

            MessageBox.Show("La matrice de premier joueur est :" + mat1 + "\nla matrice de deuxieme joueur est :" + mat2);
            
            */
        }


    }
}
