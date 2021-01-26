using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facturation.Data.Entities;

namespace Facturation.UserControls
{
    public partial class Usecraitaire : UserControl
    {
        public Usecraitaire()
        {
            InitializeComponent();
        }

        private void Usecraitaire_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //ajouter : testé et validé !
            using (Facturation_DBEntities db = new Facturation_DBEntities())
            {
                if (db.SECRETAIREs.Find(InputCode.Text) is null)
                {
                    db.SECRETAIREs.Add(new SECRETAIRE
                    {
                        id = int.Parse(InputCode.ToString()),
                        nom = bunifuMaterialTextbox1.Text,
                        prenom = bunifuMaterialTextbox2.Text,
                        email = bunifuMaterialTextbox3.Text,
                        mdp = bunifuMaterialTextbox4.Text


                    });
                    db.SaveChanges();
                    AnimationFeedback("Ajouté avec succées !", Properties.Resources.good);
                }
                else
                    AnimationFeedback("Client déja existant !", Properties.Resources.notValid);
            }
        }

        public void LoadGridData()
        {
            //remplir data grid view : testé et validé !
            using (Facturation_DBEntities db = new Facturation_DBEntities())
            {
                var req = (from s in db.SECRETAIREs
                           select new
                           {
                               s.id,
                               s.nom,
                               s.prenom,
                               s.email,
                               s.mdp
                           });
                MyDataGrid.DataSource = req.ToList();
            }
            if (MyDataGrid.Columns.Count < 5)
            {
                MyDataGrid.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "columnSupr",
                    UseColumnTextForButtonValue = true,
                    Text = "Supprimer !",
                    HeaderText = "",
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Width = 488,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet,
                    MinimumWidth = 3
                });
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        
                  => LoadGridData(); //actualiser dataGridView : testé et validé !

        private void AnimationFeedback(String labelText, Image image)
        {
            //confirmation : testé et validé !
            pictureBox1.Image = image;
            label1.Text = labelText;
            bunifuTransition1.ShowSync(panelFeedback, true, BunifuAnimatorNS.Animation.HorizSlide);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // regulateur d'animation : testé et validé !
            bunifuTransition1.HideSync(panelFeedback, true, BunifuAnimatorNS.Animation.HorizSlide);
        }



        public void loaddata()
        {
            //remplissage comboBox data grid view : testé et validé !
         
            LoadGridData();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            // rendre interface d'ajout 
            // effacer les champs
            // testé et validé !
            bunifuTransition1.HideSync(bunifuShadowPanel1, false, BunifuAnimatorNS.Animation.HorizSlide);
            bunifuButton4.Visible = false;
            this.bunifuButton1.ButtonText = "Ajouter une secraitaire";
            this.bunifuButton1.Location = new System.Drawing.Point(343, 67);
            this.bunifuButton1.Size = new System.Drawing.Size(150, 32);
            if (InputCode.Enabled.Equals(false))
            {
                //this.bunifuButton1.Click -= new EventHandler(Modifier_Click);
                this.bunifuButton1.Click += new EventHandler(bunifuButton1_Click);
                InputCode.Enabled = true;
            }
            InputCode.ResetText();
            bunifuMaterialTextbox1.ResetText();
            bunifuMaterialTextbox2.ResetText();
            bunifuMaterialTextbox3.ResetText();
            bunifuMaterialTextbox4.ResetText();


            bunifuTransition1.ShowSync(bunifuShadowPanel1, false, BunifuAnimatorNS.Animation.HorizSlide);
        }
    }
}