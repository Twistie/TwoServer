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
    public partial class UsersConnected : Form
    {
        List<bool> _isConnected = new List<bool>();
        private PlayerList _playerList;
        public UsersConnected(PlayerList pL)
        {
            InitializeComponent();
            _playerList = pL;
            for( int i = 0; i < pL.NumberPlayers; i++)
            {
                _isConnected.Add(false);
            }
            BuildList();
        }

        private void UsersConnected_Load(object sender, EventArgs e)
        {

        }
        public void BuildList()
        {
            _playersLabel.Text = "";
            for(int  i = 0; i < _isConnected.Count; i++)
            {

                _playersLabel.Text += String.Format("{0} : {1}", _playerList.PlayerArray[i].Name,_isConnected[i].ToString());
            }
        }
        public void BuildListFromThread()
        {
            if (_playersLabel.InvokeRequired)
            {
                _playersLabel.BeginInvoke(new MethodInvoker(delegate() { BuildListFromThread(); }));

            }
            else
                BuildList();
        }
        public void PlayerJoined(int playerNumber)
        {
            _isConnected[playerNumber] = true;
            BuildListFromThread();
        }
        
    }
}
