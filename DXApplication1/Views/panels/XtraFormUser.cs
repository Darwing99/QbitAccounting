using ClassLibraryBLL.Implementations;
using ClassLibraryBLL.Interfaces;
using ClassLibraryEntity.Models.Accounting;
using DevExpress.XtraEditors;
using DXAccounting.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXAccounting.Views.panels
{
    public partial class XtraFormUser : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormUser()
        {
            InitializeComponent();
            DataGridUser();
        }
        void DataGridUser()
        {
            DataGridViewUser.ColumnCount= 7;
            DataGridViewUser.Columns[0].Name = "Codigo";
            DataGridViewUser.Columns[1].Name = "Nombre";
            DataGridViewUser.Columns[2].Name = "Correo";
            DataGridViewUser.Columns[3].Name = "Telefono";
            DataGridViewUser.Columns[4].Name = "Rol";
            DataGridViewUser.Columns[5].Name = "Estado";
            DataGridViewUser.Columns[6].Name = "Fecha Registro";
        }
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void XtraFormUser_Load(object sender, EventArgs e)
        {
            GetRol();
            GetUser();
        }
        private async void GetUser()
        {
            try
            {
                UserNegocio user = new UserNegocio();
                List<UserPerson> userPeople = await user.ListUserPerson();

                foreach (UserPerson person in userPeople)
                {

                    DataGridViewUser.Rows.Add(new object[]
                    {
                    person.IdRol,
                    person.NameUser,
                    person.CorreoUser,
                    person.TelephoneUser,                  
                    person.IdRolNavigation.Descripcion,
                    person.IsActive==true ? "Activo":"Inactivo",
                    person.DateRegistro,


                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        private async void GetRol()
        {
            RolBusisness rolBusisness= new RolBusisness();
            List<Rol> roles = await rolBusisness.GetRol();
            CbbRoles.Items.Clear();
            foreach (var role in roles)
            {
                CbbRoles.Items.Add(new OptionCombo() { Value=role.IdRol,Name=role.Descripcion});
               
            }
            CbbRoles.DisplayMember = "Name";
            CbbRoles.ValueMember = "Value";
            CbbRoles.SelectedIndex = 0;
        }
    }
}