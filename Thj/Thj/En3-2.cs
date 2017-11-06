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
    public partial class En3_2 : MetroFramework.Forms.MetroForm
    {
        public En3_2()
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
        public String Nash1(decimal[,] jr1, decimal[,] jr2, String str)
        {


            if (str.Equals("Pure"))
            {

                int s1 = 3, s2 = 2;
                int col_ = 0, line_ = 0;
                int[,] pile1 = new int[s1 * s2, s1 * s2];
                int[,] pile2 = new int[s1 * s2, s1 * s2];
                String[,] St = new String[s1, s2];
                St[0, 0] = "1";
                St[0, 1] = "2";
                St[1, 0] = "3";

                St[1, 1] = "4";
                St[2, 0] = "5";
                St[2, 1] = "6";



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
                /*****************************************/
                //first Case : A(x1,x2,0) B(y1,y2):
                String q = "", qq = "";
                Boolean Exist2;
                decimal r2, r, a, b, a2, b2;
                Boolean Exist;
                Profile = "";

                for (int i = 0; i < 3; i++)
                {
                    int xx, yy;
                    Exist =  false;
                    Exist2 = false;
                    

                    if (i != 2)
                    {
                        xx = i;
                        yy = i + 1;
                    }
                    else
                    {
                        xx = 0;
                        yy = 2;
                    }

                    a = (jr2[xx, 0] - jr2[xx, 1]) - (jr2[yy, 0] - jr2[yy, 1]);
                    b = jr2[xx, 1] - jr2[yy, 1];

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
                                    //Profile = "-Strategie Mixte de 1ere Joueur: ( " + q + " , " + qq + " , 0 )";
                                    break;

                                case 1:
                                     Profile = Profile + "\n  -(0 , X2 , X3) On a la Strategie Mixte de 1ere Joueur: ( 0, " + q + " , " + qq + " )";
                                    //Profile = "-Strategie Mixte de 1ere Joueur: ( 0, " + q + " , " + qq + " )";
                                    break;

                                case 2:
                                    Profile = Profile + "\n -(X1 , 0 , X3) On a la Strategie Mixte de 1ere Joueur: ( " + q + " , 0 ," + qq + " )";
                                    //Profile = "-Strategie Mixte de 1ere Joueur: ( " + q + " , 0 ," + qq + " )";
                                    break;

                            }

                        }

                    }
                   

                    if (Exist)
                    {


                        a2 = (jr1[xx, 0] - jr1[xx, 1]) - (jr1[yy, 0] - jr1[yy, 1]);
                        b2 = jr1[xx, 1] - jr1[yy, 1];

                        if (a2 != 0)
                        {
                            r2 = (-b2) / a2;
                            if (r2 < 1)
                            {
                                Exist2 = true;
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


            decimal[,] mat_joueur1 = new decimal[3, 2];
            decimal[,] mat_joueur2 = new decimal[3, 2];
            //intilize the two matrices : 

            //Matrice 1 :
            mat_joueur1[0, 0] = val0_0.Value; mat_joueur1[0, 1] = val0_1.Value;
            mat_joueur1[1, 0] = val1_0.Value; mat_joueur1[1, 1] = val1_1.Value;
            mat_joueur1[2, 0] = val2_0.Value; mat_joueur1[2, 1] = val2_1.Value;




            //Marice 2 : 
            //Matrice 1 :
            mat_joueur2[0, 0] = val20_0.Value; mat_joueur2[0, 1] = val20_1.Value;
            mat_joueur2[1, 0] = val21_0.Value; mat_joueur2[1, 1] = val21_1.Value;
            mat_joueur2[2, 0] = val22_0.Value; mat_joueur2[2, 1] = val22_1.Value;

            
           
            String mat1 = "\n", mat2 = "\n";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                    mat1 = mat1 + " mat_joueur1[" + i + "," + j + "] = " + mat_joueur1[i, j] + "  ";

                mat1 = mat1 + "\n";
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                    mat2 = mat2 + " mat_joueur2[" + i + "," + j + "] = " + mat_joueur2[i, j] + "  ";

                mat2 = mat2 + "\n";
            }
            Nash1(mat_joueur1, mat_joueur2, Methode);

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




        }

       
    }

}