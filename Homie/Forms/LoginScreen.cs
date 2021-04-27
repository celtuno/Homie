using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homie.Models;
namespace Homie.Forms
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
            
        }
        public frmLoginScreen(bool tray)
        {
            InitializeComponent();
            
            trayIcon.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                
            try
            {
                UseWaitCursor = true;
                //Check login
                CheckLogin();
            
            }
             //Invalid login hendler
            catch (InvalidLogin loginError)
            {
                MessageBox.Show(loginError.Message, "Login error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            //Error handling for login
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error");
            }
            finally { UseWaitCursor = false; }
        }
        
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            //Check if timer is activated at startup and logout.
            TimerCheck();
            trayIcon.Visible = true;
            showLoginToolStripMenuItem.Enabled = true;

        }

        private void frmLoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
           //Exit gracefully
            Environment.Exit(1337);
        }


        private void LoadMain(bool userOk)//, bool timebit)
        {
            //Load main form , clear usernam/password field, hide login
            frmMain frmMain= new frmMain();// userOk, timebit);
            showLoginToolStripMenuItem.Enabled = false;
            
            txtUsername.Clear();
            txtPassword.Clear();
            this.Hide();
            frmMain.ShowDialog();
            
            trayIcon.Visible = false;

        }


        private void TimerCheck()
        {
            //intitilaze the timer control class
            TimerControl timerControl = new TimerControl();
            //Set loginform controller to represent the logging timer  status
            radioTimer.ForeColor = timerControl.CheckTimer(out bool timerStatus);
            radioTimer.Checked = timerStatus;
            radioTimer.Text = timerControl.TimerStatusText;
      

        }



        //CHeck if login credentials is calid
        private void CheckLogin()
        {
            bool loginOk;
            string userName, tmpPassword;
            //Get username and password form Loginform textboxes
            tmpPassword = txtPassword.Text;
            userName = txtUsername.Text;

            //Register Login class
            LoginUser loginUser = new LoginUser(userName, tmpPassword);
            loginOk = loginUser.UserValidated;
            //Check if loginclass returns bool- valid login
            if (loginOk)
            {
                //Login vas valid
                //Initilaize main screen
                LoadMain(loginOk);

            }
            else if (!loginUser.UserValidated)
            {
                //Login was not valid
                throw new InvalidLogin(userName);//("Username and/or password is incorrect");
            }
            else
            {
                
            }

        }



        //Bottom bar and  menu
        //Gets timer stautus
        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            TimerControl timerControl = new TimerControl();
            trayIcon.BalloonTipTitle = "Logging timer status";
            trayIcon.BalloonTipText = "Timer started:  " + timerControl.Timerstatus;
            trayIcon.ShowBalloonTip(5);
            

            //trayIcon.Visible = false;
        }


 

        private void frmLoginScreen_Resize(object sender, EventArgs e)
        {
            TimerCheck();
            if (this.WindowState == FormWindowState.Minimized && trayIcon.Visible == false)
            {
                 showLoginToolStripMenuItem.Enabled = true;
                Hide();
                trayIcon.Visible = true;
            }
            //else if (this.WindowState == FormWindowState.Minimized && trayIcon.Visible == true)
            //{
            //    this.WindowState = FormWindowState.Normal;

            //    trayIcon.Visible = false;
            //}
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1337);
        }

        //bottom bar and menu end

        //Errorprovider for username and password

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                loginErrorProv.SetError(txtUsername, "Enter username");
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
                loginErrorProv.Clear();
            }
            
        }
        //Errorprovider for username and password
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
                loginErrorProv.SetError(txtPassword, "Enter password");
            else
            {
                if (!(txtUsername.Text == ""))
                    loginErrorProv.Clear();
            }
        }
        //Errorprovider for username and password
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                btnLogin.Enabled = false;
                loginErrorProv.SetError(txtUsername, "Enter username");
            }
            else
            {
                btnLogin.Enabled = true;
                loginErrorProv.Clear();
            }
        }
        //Errorprovider for username and password
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
                loginErrorProv.SetError(txtPassword, "Enter password");
            else
            {
                if (!(txtUsername.Text == ""))
                {
                    loginErrorProv.Clear();
                   
                }
                else
                {
                    loginErrorProv.SetError(txtUsername, "Enter username");
                }
            }
        }
        //stop timer from traymenu
        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimerControl timerControl = new TimerControl();
            //Set loginform controller to represent the logging timer  status
            
            
            
            timerControl.ControlTimer(false);
            trayIcon.BalloonTipTitle = "Timer is stopped";
            trayIcon.BalloonTipText = "Stopped the logging timer";
            trayIcon.ShowBalloonTip(5);
        }

        //start timer from traymenu
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerControl timerControl = new TimerControl();
            //Set loginform trayicon/menu to represent the logging timer  status
            
            bool tmpTmrStatus = timerControl.Timerstatus;
            //
            if (!tmpTmrStatus) { 
            timerControl.ControlTimer(true);
                trayIcon.BalloonTipText = "Timer is started";
                trayIcon.BalloonTipTitle = "Started the logging timer";
                trayIcon.ShowBalloonTip(5);
            }
            else
            {
                trayIcon.BalloonTipText = "Timer is already running";
                trayIcon.BalloonTipTitle = "Cannot start timer";
                trayIcon.ShowBalloonTip(5);
            }

        }

        private void trayMenu_Opening(object sender, CancelEventArgs e)
        {

        }
        //SHow login screen after minimizing
        private void showLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            TimerCheck();
            //trayIcon.Visible = false;
        }

        private void frmLoginScreen_Enter(object sender, EventArgs e)
        {
            //showLoginToolStripMenuItem.Enabled = true;
        }
    }
    
}
