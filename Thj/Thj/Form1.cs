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
    public partial class mainForm : MetroFramework.Forms.MetroForm
    {
        public mainForm()
        {
            InitializeComponent();
        }

        int S1, S2;
        
        private void metroTile1_Click(object sender, EventArgs e)
        {
            int r1 = S1 - S2;

          

            if (radioButton5.Checked)
            {
                En2 form7 = new En2("Dominante");
                form7.Show();
            }
           else
            {
                switch (r1)
                {
                    case -1://S1 = 2; S2=3;
                        {
                            En2_3 form1 = new En2_3();
                            form1.Show();
                        }
                        break;

                    case 0://S1 = 2; S2=2; Or //S1 = 3; S2=3;
                        if (S1 == 2)
                        {
                            En2 form3 = new En2();
                            form3.Show();
                        }
                        else
                        {
                            En form4 = new En();
                            form4.Show();
                        }
                        break;

                    case 1://S1 = 3; S2=2;
                        {
                            En3_2 form2 = new En3_2();
                            form2.Show();
                        }
                        break;
                }
            }
           
            /*
            

            Boolean go = true;
            int s1, s2 , r;   
                

            if(checkBox5.Checked && (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked) )
            {
                go = false;
                MessageBox.Show("Choisis Une Seule Methode (Nash ou Bien Dominance)");
            }
            else
            {
                go = true;
            }

            if ( (checkBox1.Checked && checkBox2.Checked ) || ( checkBox3.Checked && checkBox4.Checked) )
            {
                go = false;
                MessageBox.Show("Chacune de Joueur Admet soit deux Strategie Ou bien trois il ne peut pas avoir deux et trois en méme Temps");
            }
            else
            {
                go = true;
            }

            s1 = 0;s2 = 0;
            
            if (checkBox1.Checked)
                s1 = 2;
            else
                s1 = 3;
            if (checkBox4.Checked)
                s2 = 3;
            else
                s2 = 2;

            r = s1 - s2;

            if (checkBox5.Checked)
            {
                En2 form = new En2("Dominante");
                form.Show();
             }
            switch(r)
            {
                case -1: //s1 = 2 , s2 =3
                    {
                        En2_3 form1 = new En2_3();
                        form1.Show();
                    }
                   
                    break;

                case 0:  //s1 = 2 , s2 =3
                    if(s1 == 2 )
                    {
                        En2 form3 = new En2();
                        form3.Show();
                    }
                    else
                    {
                        En form4 = new En();
                        form4.Show();
                    }
                break;

                case 1:  //s1 = 3 , s2 =2
                    En3_2 form2 = new En3_2();
                    form2.Show();
                break;
            }
            */


            //MessageBox.Show("s1 = "+s1+" -s2 = "+s2);
            /*
            En form = new En();
            form.Show();
            this.Hide();
            */
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if(this.radioButton5.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                
            }
            
            /*
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked)
                radioButton1.Checked = false;
            */
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(this.radioButton3.Checked)
            {
                radioButton5.Checked = false;
                S2 = 2;
            }
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked)
            {
                radioButton5.Checked = false;
                S2 = 3;
            }
                
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                radioButton5.Checked = false;
                S1 = 2;
            }
                
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                radioButton5.Checked = false;
                S1 = 3;

            }
                
        }
    }
}
