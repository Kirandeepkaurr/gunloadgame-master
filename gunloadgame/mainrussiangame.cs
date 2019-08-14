using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gunloadgame
{
    
    public partial class mainrussiangame : Form
    {
        public mainrussiangame()
        {
            
            InitializeComponent();
            shootbulletebutton.Enabled = false;
            awaybulleteshoot.Enabled = false;
            Gunspinbtn.Enabled = false;





        }
        chamergun chamberobj = new chamergun();
        Random spin = new Random();
       

       
        private void buttonlodebtn_Click(object sender, EventArgs e)//coding for gun load
        {
            Gunspinbtn.Enabled = true;
            



            videopicture.Image = gunloadgame.Properties.Resources.load;//coding for gif file
            System.IO.Stream str = gunloadgame.Properties.Resources.shoot1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);//coding for sound of gun load
            snd.Play();
            buttonlodebtn.Enabled = false;


        }

        private void Gunspinbtn_Click(object sender, EventArgs e) //coding for spin the chamber
        {
            chamberobj.spinner = spin.Next(1, 6);
            shootbulletebutton.Enabled = true;
            awaybulleteshoot.Enabled = true;
            videopicture.Image = gunloadgame.Properties.Resources.spin;//coding for gif file
            System.IO.Stream str = gunloadgame.Properties.Resources.shoot1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);//coding for sound
            snd.Play();
            Gunspinbtn.Enabled = false;
            chamberobj.SW = 2;


        }

        private void shootbulletebutton_Click(object sender, EventArgs e)
        {
                videopicture.Image = gunloadgame.Properties.Resources.shoot;//coding for gif file
                System.IO.Stream str = gunloadgame.Properties.Resources.shoot1;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);//coding for sound
                snd.Play();

                int awaybullete = shotbtn();
                if (awaybullete == 1)
                {
                    MessageBox.Show("you loose"); //coding for message box 
                    Gunspinbtn.Enabled = false;
                    shootbulletebutton.Enabled = false;
                    buttonlodebtn.Enabled = false;
                    awaybulleteshoot.Enabled = false;

                }
                if (awaybullete == 2)
                {


                    chamberobj.shotleft = chamberobj.shotleft - 1;
                    chamberobj.spinner = spincham(chamberobj.spinner);
                    MessageBox.Show("no shot");
                }
            
        

        }

        private void awaybulleteshoot_Click(object sender, EventArgs e)
        {
            videopicture.Image = gunloadgame.Properties.Resources.shoot;//coding for gif file
            System.IO.Stream str = gunloadgame.Properties.Resources.shoot1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);//for sound
            snd.Play();
            int win = chamberobj.Winner();
            if (win == 1)//first shot away fire
            {

                MessageBox.Show("score 10 you win");
                Gunspinbtn.Enabled = false;
                shootbulletebutton.Enabled = false;
                buttonlodebtn.Enabled = false;
                awaybulleteshoot.Enabled = false;

            }
            if (win == 2)//second shot away fire
            {
                MessageBox.Show("score 5 you win(2nd fire)");
                Gunspinbtn.Enabled = false;
                shootbulletebutton.Enabled = false;
                buttonlodebtn.Enabled = false;
                awaybulleteshoot.Enabled = false;

            }
            if (win == 0)
            {

                MessageBox.Show("no shot");
                chamberobj.shotleft = chamberobj.shotleft - 2;
            }
            if (chamberobj.shotleft == 0)
            {

                MessageBox.Show("loose");
                Gunspinbtn.Enabled = false;
                shootbulletebutton.Enabled = false;
                buttonlodebtn.Enabled = false;
                awaybulleteshoot.Enabled = false;



            }
        }
        public int shotbtn()
        {
            if (chamberobj.shotleft > 0 && chamberobj.spinner == 1)//gun shot if bullete is there in chamber
            {

                chamberobj.gunload = 1;




            }
            else if (chamberobj.shotleft > 0 && chamberobj.spinner != 1)
            {
                chamberobj.gunload = 2;

            }
            return chamberobj.gunload;
        }
        public int spincham(int spinskip)//skips the bullete if its in the 6 its shift it to oneS
        {
            if (spinskip == 6)
            {
                spinskip = 1;
            }
            else
            {
                spinskip++;
            }
            return spinskip;
        }
        private void playagaingame_Click(object sender, EventArgs e)
        {
            (new mainrussiangame()).Show();
            this.Hide();
        }
    }
}
