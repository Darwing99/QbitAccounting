using ClassLibraryBLL.Implementations;
using ClassLibraryEntity.Models.Accounting;
using DXAccounting.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        public MainView()
        {
            InitializeComponent();
            ProgressBarCircle.Visible = false;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
        }

        #region Inicio de Sesion
        private async void LoginSession()
        {


            if (!String.IsNullOrEmpty(TxtPassword.Text) && !String.IsNullOrEmpty(TxtUser.Text))
            {
                ProgressBarCircle.Visible = true;
                Task.Delay(2000).Wait();

                var PasswordEncryptada = new UtilitieService().ConvertirSha256(TxtPassword.Text);


                Console.Write(PasswordEncryptada);
                UserNegocio personNegocio = new UserNegocio();

                UserPerson user = await personNegocio.GetUserPerson(TxtUser.Text, PasswordEncryptada);
                ProgressBarCircle.Visible = false;

                if (user != null)
                {
                    RibbonHome ribbonHome = new RibbonHome();

                    ribbonHome.Show();
                    this.Hide();
                    ribbonHome.FormClosing += Frm_Clossing;
                }

            }
            else
            {
                MessageBox.Show("Datos invalidos");
            }

        }
        #endregion


        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

      

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            LoginSession();
        }

        private void editFormUserControl1_Load(object sender, EventArgs e)
        {

        }
        #region Control de cierre formulario
        private void Frm_Clossing(object sender, FormClosingEventArgs e)
        {
            TxtPassword.Text = "";
            TxtUser.Text = "";
            this.Show();
        }

        #endregion

        private void rangeControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
