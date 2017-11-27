using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hans_bot_24
{
    public class CommandHandler
    {
        private DiscordSocketClient _client;
        private CommandService _service;
        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            //_service.AddModulesAsync(Assembly.GetEntryAssembly());
            _service.AddModulesAsync(typeof(Komennot).Assembly);
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var message = s as SocketUserMessage;
            if (message == null)
                return;

            var context = new SocketCommandContext(_client, message);

            int argPos = 0;
            if(message.HasCharPrefix('!', ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);

                if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
        }
    }
}
