using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
using DXAccounting.Views.panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXAccounting.Views
{
    public partial class RibbonHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static RibbonPageGroup RibbonPageGroup=null;
        private static XtraForm XtraFormActive=null;
        public RibbonHome()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

            var data = sender;
            OpenForm(new XtraFormUser());
        }

        private void RibbonHome_Load(object sender, EventArgs e)
        {

        }
        private void OpenForm(XtraForm xtraForm)
        {
            if (XtraFormActive!=null)
            {
               XtraFormActive.Close();
            }
            XtraFormActive= xtraForm;
            xtraForm.TopLevel= false;
            xtraForm.FormBorderStyle= FormBorderStyle.None;             
            xtraForm.MdiParent= this;
            xtraForm.Show();
        }
    }
}