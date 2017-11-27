using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace hans_bot_24
{
    public class Komennot : ModuleBase<SocketCommandContext>
    {

        //Toistaa mitä pyydetään
        [Command("hans")]
        public async Task Vastaus([Remainder] string repeat)
        {
            await Context.Channel.SendMessageAsync(repeat);
        }

        //Valitsee hanskaskun listasta ja sanoo sen
        [Command("hanskasku")]
        public async Task HansKasku()
        {
            Random rand = new Random();
            
            List<string> kaskut = new List<string> { "Hipsut", "Oispa kaljaa", "Olinpa höpsö","SQL is the way to go", "Heh heh koodaaminen on hauskaa", "SQL-kielessä on primääriavain ja viiteavain", "Onpa meillä täällä hauskaa" };

            int valittukaskuIndeksi = rand.Next(kaskut.Count);

            await Context.Channel.SendMessageAsync((string)kaskut[valittukaskuIndeksi]);
        }

        //TODO 
        //hans-botin helppi
        [Command("hanshelp")]
        public async Task HansHelp()
        {

            string helppi = "Hei olen hans-bot ja olen täällä juuri sinua varten.\n" +
                            "\nTässä komentoni:" +
                            "\n!hanshelp - kirjoitit juuri tämän, lol" +
                            "\n!hans - toistan kaiken mitä sanot" +
                            "\n!hanskasku - kerron sinulle yhden viisauksistani";

            await Context.Channel.SendMessageAsync(helppi);  
        }

    }
}
