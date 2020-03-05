using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyChat.Core.Client;
using TinyChat.Core.Client.Interfaces;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private IChatClient _chatClient;

        public Form1()
        {
            InitializeComponent();

            textBox1.Text = "Admin";
            _chatClient = new ChatClient(8001, "127.0.0.1");
            timer1.Start();
        }

        private string Login => textBox1.Text;
        private string Message => textBox2.Text;
        private string Room => listBox1.SelectedItem != null ? listBox1.SelectedItem.ToString() : string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRoomForm f = new CreateRoomForm();
            f.ShowDialog();

            if (f.Created)
            {
                _chatClient.CreateRoom(f.RoomName, Login);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Room))
            {
                _chatClient.SendMessage(Room, Login, Message);
                textBox2.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var rooms = _chatClient.GetRooms();

            var index = -1;
            if (!string.IsNullOrEmpty(Room))
            {
                index = listBox1.SelectedIndex;
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(rooms.Select(r => r.Name).ToArray());

            listBox1.SelectedIndex = index;

            if (!string.IsNullOrEmpty(Room))
            {
                var messages = _chatClient.GetMessages(Room);

                richTextBox1.Clear();

                var messagesText = string.Join(Environment.NewLine, messages
                    .Select(t => $"{t.Time} [{t.Sender}]: {t.Text}")
                    .ToArray());

                richTextBox1.Text = messagesText;
            }
        }
    }
}
