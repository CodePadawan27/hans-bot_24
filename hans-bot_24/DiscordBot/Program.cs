using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace hansbot
{
    public class Program
    {
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _handler;

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();
            await _client.LoginAsync(TokenType.Bot, "Mzc3NzQ0NTEzMzU3MDUzOTUy.DOTNag.cunIt9A0uHwOh7PT12QTgUJKTfQ");
            await _client.StartAsync();
            _handler = new CommandHandler(_client);
            await Task.Delay(-1);
        }   
    }
}
