using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace TonTon_Discord_Bot.Services
{
    class SetStatus
    {
        public static IServiceProvider _provider;
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly IConfigurationRoot _config;

        public SetStatus(IServiceProvider provider, DiscordSocketClient discord, CommandService commands, IConfigurationRoot config)
        {
            _provider = provider;
            _config = config;
            _discord = discord;
            _commands = commands;
        }

        public async Task StartStatus()
        {
            while (true)
            {
                int startNumb = RandNumbGen(0, 4);

                if (startNumb == 1)
                {
                    await SetWatchingStatus(0, 9);
                }
                else if (startNumb == 2)
                {
                    await SetPlayingStatus(0, 8);
                }
                else if (startNumb == 3)
                {
                    await SetListeningStatus(0, 11);
                }
                await Task.Delay(1200000); //20 Minutes
            }
        }

        //Random Number Generator
        public int RandNumbGen(int Numb1, int Numb2)
        {
            int number;
            Random numberGen = new Random();
            number = numberGen.Next(Numb1, Numb2);
            return number;
        }

        //Set status and array types
        //0, 9 (EXCLUSIVE, REMEMBER TO CHECK SECOND VALUE. ALSO REMEMBER THAT ITEM ONE STARTS AT 0)
        public async Task SetWatchingStatus(int Numb1, int Numb2)
        {
            string[] watchingStatuses =
            {
                "How to tell if you're getting too fat",
                "EASY Fries Recipe (No Oil)",
                "Gawr Gura Ch. Videos",
                "Korone Ch. Videos",
                "Should I be worried if i'm overweight?",
                "Vines",
                "Random Twitter videos",
                "Doom Crossing - Official Teaser",
                "Pfp by ぶくろて: https://www.pixiv.net/en/artworks/78180605"
            };

            await _discord.SetGameAsync(watchingStatuses[RandNumbGen(Numb1, Numb2)], null, ActivityType.Watching);
            return;
        }

        //0, 8 (EXCLUSIVE, REMEMBER TO CHECK SECOND VALUE. ALSO REMEMBER THAT ITEM ONE STARTS AT 0)
        public async Task SetPlayingStatus(int Numb1, int Numb2)
        {
            string[] playingStatuses =
            {
                "Doom Crossing",
                "Animal Crossing: New Leaf",
                "Animal Crossing: New Horizons",
                "Slime Rancher",
                "Stardew Valley",
                "Kerbal Space Program",
                "Adobe Premier 2021",
                "Pfp by ぶくろて: https://www.pixiv.net/en/artworks/78180605"
            };

            await _discord.SetGameAsync(playingStatuses[RandNumbGen(Numb1, Numb2)], null, ActivityType.Playing);
            return;
        }

        //0, 11 (EXCLUSIVE, REMEMBER TO CHECK SECOND VALUE. ALSO REMEMBER THAT ITEM ONE STARTS AT 0)
        public async Task SetListeningStatus(int Numb1, int Numb2)
        {
            string[] listeningStatuses =
            {
                "Yutaka Hirasaka - eau",
                "A Short Hike (Full OST)",
                "Broke For Free - Add And",
                "Broke For Free - Juparo",
                "Broke For Free - Xxxv",
                "not Mask by dream because that's a pretty bad song",
                "Delayde - sunday morning bacon",
                "Classical music on my radio",
                "A random radio I found",
                "Animal Crossing: New Leaf OST",
                "Pfp by ぶくろて: https://www.pixiv.net/en/artworks/78180605"
            };

            await _discord.SetGameAsync(listeningStatuses[RandNumbGen(Numb1, Numb2)], null, ActivityType.Listening);
            return;
        }
    }
}
