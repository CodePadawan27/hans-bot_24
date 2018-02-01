using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Flee.CalcEngine.PublicTypes;
using Flee.PublicTypes;
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
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync(repeat);

        }

        //Valitsee hanskaskun listasta ja sanoo sen
        [Command("hanskasku")]
        public async Task HansKasku()
        {

            Random rand = new Random();

            List<string> kaskut = new List<string> {
                "Hyvä!",
                "Saakeli!",
                "CSS on pain in the ass",
                "Hipsut",
                "Oispa kaljaa",
                "Olinpa höpsö",
                "SQL is the way to go",
                "Heh heh koodaaminen on hauskaa",
                "SQL-kielessä on primääriavain ja viiteavain",
                "Onpa meillä täällä hauskaa"
            };

            int valittukaskuIndeksi = rand.Next(kaskut.Count);

            await Context.Channel.SendMessageAsync((string)kaskut[valittukaskuIndeksi]);
        }
        //Hans-bot laskee laskun annetuilla parametreilla
        [Command("hansmitäon")]
        public async Task Hanslaskuri([Remainder] string lasku)
        {
            Random rand = new Random();

            try
            {
                ExpressionContext context = new ExpressionContext();
                IDynamicExpression e = context.CompileDynamic(lasku);
                var vastaus = e.Evaluate();


                List<string> laskukommentit = new List<string> {
                "Bitch please. Vastaus laskutoimitukseen on ",
                "Hih, no sehän on selvästi ",
                "Etkö nyt osaa jo itse? Sehän on ",
                "Luulisi nyt tuolla ohjelmointikokemuksella jo osaavan. Sehän on "
            };

                int valittukaskuIndeksi = rand.Next(laskukommentit.Count);
                await Context.Channel.SendMessageAsync(laskukommentit[valittukaskuIndeksi] + vastaus.ToString() + ".");
            }
            catch (ExpressionCompileException ex)
            {
                List<string> eitiedakommentit = new List<string> {
                "Nyt en oikein käsitä mitä tarkoitat.",
                "Odota hetki, käyn tarkistamassa.",
                "Nyt en ehdit valitettavasti auttaa.",
                "Voitko kysyä joltain muulta opettajalta?",
                "Anteeksi, mutta nyt on hieman kiire."
            };

                int valittueitiedaIndeksi = rand.Next(eitiedakommentit.Count);
                // Jos hans-bot ei pysty vastaamaan
                if (ex.Reason == CompileExceptionReason.SyntaxError)
                    await Context.Channel.SendMessageAsync(eitiedakommentit[valittueitiedaIndeksi]);
            }
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
