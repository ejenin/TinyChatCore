using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyChat.Core.Server;
using TinyChat.Core.Server.Interfaces;

namespace ServerApp
{
    public partial class Form1 : Form
    {
        private readonly IChatServer _chatServer;

        public Form1()
        {
            InitializeComponent();

            _chatServer = new ChatServer(8001);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _chatServer.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _chatServer.Stop();
        }

        private void saveChatButton_Click(object sender, EventArgs e)
        {
            _chatServer.SaveState();
        }

        private void restoreChatButton_Click(object sender, EventArgs e)
        {
            _chatServer.RestoreState();
        }

        private void refreshRooms_Click(object sender, EventArgs e)
        {
            var rooms = _chatServer.Chat.GetRooms();

            roomsListBox.Items.AddRange(rooms.Select(r => r.Name).ToArray());
        }

        private string Room => roomsListBox.SelectedItem?.ToString();

        private void timer1_Tick(object sender, EventArgs e)
        {
            var rooms = _chatServer.Chat.GetRooms();

            var index = -1;
            if (!string.IsNullOrEmpty(Room))
            {
                index = roomsListBox.SelectedIndex;
            }

            roomsListBox.Items.Clear();
            roomsListBox.Items.AddRange(rooms.Select(r => r.Name).ToArray());

            roomsListBox.SelectedIndex = index;

            if (!string.IsNullOrEmpty(Room))
            {
                var messages = _chatServer.Chat.GetMessages(Room);

                chatRichTextBox.Clear();

                chatRichTextBox.Clear();

                var messagesText = string.Join(Environment.NewLine, messages
                    .Select(t => $"{t.CreatedDate.ToShortTimeString()} [{t.SenderId} - {t.SenderName}]]: {t.Text})")
                    .ToArray());

                chatRichTextBox.Text = messagesText;
            }
        }
    }
}
