using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
            noAdmin.Text = "Vous n'avez les droits nécessairse.\nVous n'aurez pas accès a toutes\nles fonctionnalitées";
        }

        private void returnToTaskManager(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
