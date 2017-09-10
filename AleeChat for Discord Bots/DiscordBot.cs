using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.WebSocket;

namespace AleeChat_for_Discord_Bots
{
    public partial class DiscordBot : Form
    {
        DiscordSocketClient Client;

        public DiscordBot()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }

        private void guildComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            channelBox.Items.Clear();

            foreach(var Guild in Client.Guilds)
            {
                if(Guild.Name == guildComboBox.Text)
                {
                    foreach(var Tc in Guild.TextChannels)
                    {
                        channelBox.Items.Add(Tc.Name);
                    }
                }
            }
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            });

            Client.Log += Client_Log;

            try
            {
                await Client.LoginAsync(TokenType.Bot, tokenBox.Text);
                await Client.StartAsync();
            }
            catch
            {
                MessageBox.Show("Error occured while connecting your Bot!", "ERROR");
                return;
            }
            await Task.Delay(3000);

            foreach (var Guild in Client.Guilds)
            {
                guildComboBox.Items.Add(Guild.Name);
            }

            guildComboBox.SelectedIndexChanged += guildComboBox_SelectedIndexChanged;
        }

        private Task Client_Log(LogMessage arg)
        {
            Invoke((Action)delegate
            {
                discordConsole.AppendText(arg + "\n");
            });
            return null;
        }

        private void discordConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void tokenBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
