using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace hans_bot_24
{
    public class DiscordBot
    {
        public static void StartUp() => new DiscordBot().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _handler;

        public async Task StartAsync()
        {
            _client = new DiscordSocketClient();
            await _client.LoginAsync(TokenType.Bot, "Mzc3NzQ0NTEzMzU3MDUzOTUy.DOTNag.cunIt9A0uHwOh7PT12QTgUJKTfQ");
            await _client.StartAsync();
            _handler = new CommandHandler(_client);
            //await Task.Delay(-1);

            _client.MessageReceived += _client_MessageReceived;
        }

        private Task _client_MessageReceived(SocketMessage msg) {
            if (msg.Content.StartsWith("```cs")) {
                msg.Channel.SendMessageAsync("Aikamoista");
            }
            return (Task.FromResult(0));
        }
    }
}
