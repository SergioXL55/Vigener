using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form1 : Form
    {
        private Cryptographer vigenerCryptographer = new VigenerCryptographer();

        public Form1()
        {
            InitializeComponent();
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                vigenerCryptographer.setKey(key.Text);
                resultText.Text = vigenerCryptographer.encode(inputText.Text);
            }
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                vigenerCryptographer.setKey(key.Text);
                resultText.Text = vigenerCryptographer.decode(inputText.Text);
            }
        }

        private Boolean ValidateFields()
        {
            if (!vigenerCryptographer.ValidateInputData(inputText.Text, key.Text))
            {
                MessageBox.Show("Допустим ввод букв Русского алфавита и цифр, либо поля пустые", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}
