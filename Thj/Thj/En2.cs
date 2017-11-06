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
    public partial class En2 : MetroFramework.Forms.MetroForm
    {

        private String Algo_name;

        public En2()
        {
            InitializeComponent();
            panelChange();
        }

        public En2(String Algo_name)
        {
            InitializeComponent();
            panelChange();
            this.Algo_name = Algo_name;
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


        String Profile = "";
        public String Nash(decimal[,] jr1, decimal[,] jr2, String str)
        {


            if (str.Equals("Pure"))
            {
                int s1 = 2,s2=2;
                int col_ = 0, line_ = 0;
                int[,] pile1 = new int[s1 * s2, s1 * s2];
                int[,] pile2 = new int[s1 * s2, s1 * s2];
                String[,] St = new String[s1, s2];
                St[0, 0] = "1";
                St[0, 1] = "2";
                St[1, 0] = "3";
                St[1, 1] = "4";

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
                        if (pile1[0,i] == pile2[0,j] && pile1[1,i] == pile2[1,j])
                        {
                            x = pile2[0,j];
                            y = pile2[1,j];

                            //Profile = Profile +"-("+ jr1[x,y]+"," + +jr2[x, y]+") Que Veut dire les Strategie:"+ St[x, y] + "\n";
                            Profile = Profile+St[x, y];
                        }

                      }
                 }
                if (Profile.Equals(""))
                      Profile = "iL n'Existe pas un EN dans Ce jeu";
               
            }
            else// Handle The Mixed 
            {
                String p = "", pp = "", q = "", qq = "";
                Boolean Existe1 = false, Existe2 = false;
                decimal a, b, a2, b2;

                a = (jr1[0,0] - jr1[1,0]) - (jr1[0,1] - jr1[1,1]);
                b = jr1[1,0] - jr1[1,1];
                /*
                if (a != 0)
                {
                    Existe1 = true;
                    if (a < 0 && b > 0)
                    {
                        a *= -1;
                        q  = "" +b+ "/" +a;
                        decimal s = a - (b);
                        qq = "" + s + "/" + a;
                    }
                    else
                    {
                        if (a > 0 && b < 0)
                        {
                            b *= -1;
                            q = "" + b + "/" + a;

                            decimal s = a + (b);
                            qq = "" + s + "/" + a;
                        }
                    }
                   


                }
                */
                b *= -1;
                if (a * b > 0 && b / a < 1)
                {
                    Existe1 = true;

                    b = Math.Abs(b);
                    a = Math.Abs(a);


                    q = "" + b + "/" + a;
                    decimal s = a - (b);
                    qq = "" + s + "/" + a;
                }
                else
                {
                    Profile = "L equilibre de nash n'existe pas dans ce jeu ";
                }


                a2 = (jr2[0,0] - jr2[1,0]) - (jr2[0,1] - jr2[1,1]);
                b2 = jr2[1,0] - jr2[1,1];

                if (a2 != 0)
                {
                    
                    b2 *= -1;
                    if(a2*b2 >0 && b2/a2 <1)
                    {
                        Existe2 = true;

                        b2 = Math.Abs(b2);
                        a2 = Math.Abs(a2);


                        p = "" + b2 + "/" + a2;
                        decimal s = a2 - (b2);
                        pp = "" + s + "/" + a2;
                    }

                    /*
                     if (a2 < 0 && b2 > 0)
                    {
                        a2 *= -1;
                        p = "" + b2 + "/" + a2;
                        decimal s = a2 - (b2);
                        pp = "" + s + "/" + a2;
                    }
                    else
                    {
                        if (a2 > 0 && b2 < 0)
                        {
                            b2 *= -1;
                            p = "" + b2 + "/" + a2;

                            decimal s = a2 + (b2);
                            pp = "" + s + "/" + a2;
                        }
                    }
                    */

                }
                {
                    Profile = "L equilibre de nash n'existe pas dans ce jeu ";
                }


                if (Existe1 && Existe2)
                {
                    Profile = "True";
                    label1.Text =q;
                    label2.Text =qq;
                    label3.Text =p;
                    label4.Text =pp;
                }
                    
            }

            return Profile;
        }

        public String Dominante(decimal[,] jr1, decimal[,] jr2)
        {
            String[,] St = new String[2, 2];
            St[0, 0] = "(A1,B1)";
            St[0, 1] = "(A1,B2)";
            St[1, 0] = "(A2,B1)";
            St[1, 1] = "(A2,B2)";
            //Pure Dominante : 
            int line = -1;
            int col  = -1;
            // Cheking line by line  : 
            if (jr1[0, 0] > jr1[1, 0] && jr1[0, 1] > jr1[1, 1])
            {
                line = 0;
                if (jr2[line, 0] > jr2[line, 1])
                {
                     //Profile = "la Strategie Dominante est : (" + jr1[line, 0] + "," + jr2[line, 0] + ")  Que Veut dire les Strategie:" + St[line, 0] + "\n";
                     Profile = "1";
                }
                else
                {
                    if (jr2[line, 0] < jr2[line, 1])
                    {
                        //Profile = "la Strategie Dominante est : (" + jr1[line, 1] + "," + jr2[line, 1] + ")  Que Veut dire les Strategie:" + St[line, 1] + "\n";
                        Profile = "2";
                    }
                }
            }
            else
            {

                if (jr1[0, 0] < jr1[1, 0] && jr1[0, 1] < jr1[1, 1])
                {
                    line = 1;


                    line = 1;
                    if (jr2[line, 0] > jr2[line, 1])
                    {
                        Profile = "3";
                        //Profile = "la Strategie Dominante est : (" + jr1[line, 0] + "," + jr2[line, 0] + ")  Que Veut dire les Strategie:" + St[line, 0] + "\n";
                    }
                    else
                    {
                        if (jr2[line, 0] < jr2[line, 1])
                        {
                             Profile = "4";
                            //Profile = "la Strategie Dominante est : (" + jr1[line, 1] + "," + jr2[line, 1] + ")  Que Veut dire les Strategie:" + St[line, 1] + "\n";
                        }
                    }

                }
            }

            // Cheking line by Column by Column  :

            if (jr2[0, 0] > jr2[0, 1] && jr2[1, 0] > jr2[1, 1])
            {
                col = 0;
                if (jr1[0, col] > jr1[1, col])
                {
                    //Profile = "la Strategie Dominante est : (" + jr1[0, col] + "," + jr2[0, col] + ")  Que Veut dire les Strategie:" + St[0, col] + "\n";
                    Profile = "1";
                }
                else
                {
                    if (jr1[0, col] < jr1[1, col])
                    {
                        // Profile = "la Strategie Dominante est : (" + jr1[1, col] + "," + jr2[1, col] + ")  Que Veut dire les Strategie:" + St[0, col] + "\n";
                        Profile = "3";
                    }
                }
            }
            else
            {
                if (jr2[0, 0] < jr2[0, 1] && jr2[1, 0] < jr2[1, 1])
                {
                    col = 1;
                    if (jr1[0, col] > jr1[1, col])
                    {
                        //Profile = "la Strategie Dominante est : (" + jr1[0, col] + "," + jr2[0, col] + ")  Que Veut dire les Strategie:" + St[0, col] + "\n";
                        Profile = "2";
                    }
                    else
                    {
                        if (jr1[0, col] < jr1[1, col])
                        {
                            //Profile = "la Strategie Dominante est : (" + jr1[1, col] + "," + jr2[1, col] + ")  Que Veut dire les Strategie:" + St[0, col] + "\n";
                            Profile = "4";
                        }
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



            decimal[,] mat_joueur1 = new decimal[2, 2];
            decimal[,] mat_joueur2 = new decimal[2, 2];
            //intilize the two matrices : 

            //Matrice 1 :
            mat_joueur1[0, 0] = val0_0.Value; mat_joueur1[0, 1] = val0_1.Value;
            mat_joueur1[1, 0] = val1_0.Value; mat_joueur1[1, 1] = val1_1.Value; 





            //Marice 2 : 
            
            mat_joueur2[0, 0] = val20_0.Value; mat_joueur2[0, 1] = val20_1.Value; 
            mat_joueur2[1, 0] = val21_0.Value; mat_joueur2[1, 1] = val21_1.Value;


            String mat1 = "\n", mat2 = "\n";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                    mat1 = mat1 + "mat_joueur1[" + i + "," + j + "] = " + mat_joueur1[i, j] + "  ";

                mat1 = mat1 + "\n";
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                    mat2 = mat2 + "mat_joueur2[" + i + "," + j + "] = " + mat_joueur2[i, j] + "  ";

                mat2 = mat2 + "\n";
            }
            
            if (Algo_name == "Dominante")
            {
                Dominante(mat_joueur1, mat_joueur2);

                if (Profile.Equals(""))
                    MessageBox.Show("il n'existe pas une strategie Dominante dans ce jeu");
                else
                {
                    switch(Profile)
                    {
                        case "1":
                            panel1.BackColor = Color.Aqua;
                        break;
                        case "2":
                            panel2.BackColor = Color.Aqua;
                        break;
                        case "3":
                            panel3.BackColor = Color.Aqua;
                        break;
                        case "4":
                            panel4.BackColor = Color.Aqua;
                        break;

                    }
                }
            }
            else
            {
                Nash(mat_joueur1, mat_joueur2, Methode);

                if (Methode.Equals("Pure"))
                {
                    if (Profile.Equals(""))
                    {
                        MessageBox.Show("\niL n'Existe pas un EN dans Ce jeu:\n");
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

                            }

                        }

                    }

                }

                else//Mixed
                {
                    if(!Profile.Equals("True"))
                    MessageBox.Show("\n Le resultat est :\n" + Profile);
                }
            }
                

            //MessageBox.Show("La matrice de premier joueur est :" + mat1 + "\nla matrice de deuxieme joueur est :" + mat2+"\n Le resultat est :\n"+Profile);
        }

        private void val21_0_ValueChanged(object sender, EventArgs e)
        {

        }

        private void val1_0_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
