using Discord;
using Discord.API;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TonTon_Discord_Bot.Services;
using TonTon_Discord_Bot.Modules;

namespace TonTon_Discord_Bot.Modules
{
    public class Misc : ModuleBase
    {
        [Command("hello!")]
        [Alias("hi!", "hai!", "hallo!", "hewwo!", "hewo!", "bonjour!", "ni-hao!", "konnichiwa!", "kon'nichiwa", "konichiwa", "hola!", "guten-tag!", "ola!", "salve!")]
        [Summary("Say hello!")]
        public async Task Hello()
        {
            await Context.Channel.SendMessageAsync("Hallo!");
            await Context.Channel.SendMessageAsync("https://tenor.com/view/hey-hello-wave-waving-cute-gif-17837808");
        }

        [Command("sup")]
        [Alias("wassup")]
        public async Task Sup()
        {
            await Context.Channel.SendMessageAsync("Wasssaap! hehehe");
            await Context.Channel.SendMessageAsync("https://tenor.com/view/chen-mantis-gs_mantis-touhou-sunglasses-gif-11705505");
        }

        [Command("ew")]
        [Alias("eww", "ewww", "ewwww", "cringe", "feelscringeman", "thats-cringe")]
        
        public async Task Cringe()
        {
            await Context.Channel.SendMessageAsync("Ewww");
            await Context.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/738438140636692513/861977682081087488/a6pd49G2_700w_0.png");
        }

        [Command("cry")]
        [Alias("waaa", "waaaa", "waaaaa", "waaaaaa")]
        public async Task Cry()
        {
            await Context.Channel.SendMessageAsync("https://tenor.com/view/anime-cry-wataten-crying-gif-13356071");
        }

        [Command("das-sad")]
        [Alias("so-sad")]
        public async Task Cri()
        {
            await Context.Channel.SendMessageAsync("https://tenor.com/view/crying-boy-walkaway-cry-man-tears-gif-5637398");
        }

        [Command("run-motivation-exe")]
        [Alias("motivation-exe")]
        public async Task MotivationEXE()
        {
            var builder = new EmbedBuilder()
                .WithColor(new Color(255, 0, 0))
                .AddField("Motivation.EXE has stopped working", "Restart?", true);

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
