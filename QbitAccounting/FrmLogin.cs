using ClassLibraryBLL.Implementacion;
using ClassLibraryEntity.Models.Accounting;
using System.Runtime.CompilerServices;

namespace QbitAccounting
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private async  void Form1_Load(object sender, EventArgs e)
        {
          
           
        }
        private async void LoginSession()
        {
            if(!String.IsNullOrEmpty(TxtPassword.Text) && !String.IsNullOrEmpty(TxtUser.Text))
            {
                var PasswordEncryptada = new UtilitieService().ConvertirSha256(TxtPassword.Text);
                var generarClave = new UtilitieService().GenerarClave();

                Console.Write(PasswordEncryptada);
                UserNegocio personNegocio = new UserNegocio();

                List<UserPerson> data = await personNegocio.ListUserPerson();
                foreach (var result in data)
                {
                    if (result.CorreoUser==TxtUser.Text && result.Clave== PasswordEncryptada && result.IsActive==true)
                    {
                        MessageBox.Show("Datos correctos");
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Datos invalidos");
            }
          
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

   
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            LoginSession(); 
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}