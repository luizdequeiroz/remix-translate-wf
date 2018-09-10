using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemixTranslate
{
    public partial class Translate : Form
    {
        public Translate()
        {
            InitializeComponent();
        }

        private string Transl(int index, string text)
        {
            var words = text
            #region replaces
                .Replace(".", " . ")
                .Replace(",", " , ")
                .Replace(":", " : ")
                .Replace(";", " ; ")
                .Replace("!", " ! ")
                .Replace("?", " ? ")
            #endregion
                .ToLower().Split(' ');
            var translateds = string.Empty;
            
            #region Lea-yiokari, Yiokal e Yiokari
            if (index == 0 || index  == 1 || index == 2)
            {
                foreach (var word in words)
                    if (!string.IsNullOrEmpty(word))
                        translateds += word.TranslateToYiokari();

                if (index == 0) translateds = translateds.VariationToLeaYiokari();
                else if (index == 1) translateds = translateds.VariationToYiokal();
            }
            #endregion
            #region Arconte
            else if (index == 3)
                foreach (var word in words)
                    if (!string.IsNullOrEmpty(word))
                        translateds += word.TranslateToArconte(); 
            #endregion

            return translateds
            #region replaces
                .Replace(" . ", ". ")
                .Replace(" , ", ", ")
                .Replace(" : ", ": ")
                .Replace(" ; ", "; ")
                .Replace(" ! ", "! ")
                .Replace(" ? ", "? ");
            #endregion
        }

        private void slctIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = (sender as ComboBox).SelectedIndex;
            var text = txtTexto.Text;

            txtTraducao.Text = Transl(index, text);
        }

        private void bttnTraduzir_Click(object sender, EventArgs e)
        {
            var index = slctIdioma.SelectedIndex;
            var text = txtTexto.Text;

            txtTraducao.Text = Transl(index, text);
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            var index = slctIdioma.SelectedIndex;
            var text = (sender as TextBox).Text;

            txtTraducao.Text = Transl(index, text);
        }

        private void Translate_Load(object sender, EventArgs e)
        {
            slctIdioma.SelectedIndex = 0;
        }
    }
}
