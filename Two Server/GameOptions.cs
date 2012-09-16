using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Two_Server
{
    public partial class GameOptions : Form
    {
        public int Drink = 2;

        public int NumberCards,
                   PrincessCards,
                   PrincessDrinkCards,
                   DrawCards,
                   BoomCards,
                   PassCards,
                   LightMasterCards,
                   GrayCards;
        public GameOptions()
        {
            InitializeComponent();
        }

        private void changeDrink(RadioButton r)
        {
            foreach (RadioButton b in DrinkBox.Controls)
            {
                if (b != r)
                    if(b.Checked)
                        b.Checked = false;
            }
        }

        private void Drink2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Checked)
            {
                changeDrink((RadioButton) sender);
                Drink = 2;
            }
        }

        private void Drink1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Checked)
            {
                changeDrink((RadioButton)sender);
                Drink = 1;
            }
        }

        private void Drink0_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Checked)
            {
                changeDrink((RadioButton)sender);
                Drink = 0;
            }
        }


        private void GameOptions_Load(object sender, EventArgs e)
        {

        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            NumberCards = (int)NumberSpinner.Value;
            PrincessCards = (int) PrincessSpinner.Value;
            PrincessDrinkCards = (int) PrincessDrinkSpinner.Value;
            DrawCards = (int) DrawSpinner.Value;
            BoomCards = (int) BoomSpinner.Value;
            PassCards = (int) PassSpinner.Value;
            GrayCards = (int) GraySpinner.Value;
            LightMasterCards = (int) LightMasterSpinner.Value;
            Close();
        }
    }
}
