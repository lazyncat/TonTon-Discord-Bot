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



        //Variables so that I can easily make changes for the arrays (Don't change values here)
        int watchCount = 0;
        int playCount = 0;
        int listenCount = 0;

        //Arrays
        string[] watchingStatuses =
        {
            "How to tell if you're getting too fat",
            "EASY Fries Recipe (No Oil)",
            "Gawr Gura Ch. Videos",
            "Korone Ch. Videos",
            "Should I be worried if i'm overweight?",
            "vines",
            "random Twitter videos",
            "Doom Crossing - Official Teaser",
            "cat videos",
            "parrot videos",
            "Pfp by ぶくろて: https://www.pixiv.net/en/artworks/78180605"
        };

        string[] playingStatuses =
        {
            "Doom Crossing",
            "Animal Crossing: New Leaf",
            "Animal Crossing: New Horizons",
            "Slime Rancher",
            "Stardew Valley",
            "Kerbal Space Program",
            "Adobe Photoshop 2021",
            "Nintendogs",
            "Pfp by ぶくろて: https://www.pixiv.net/en/artworks/78180605"
        };

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
            "a cool random radio I found",
            "Animal Crossing: New Leaf OST",
            "upbeat music",
            "Pfp by ぶくろて: https://www.pixiv.net/en/artworks/78180605"
        };

        public async Task StartStatus()
        {
            watchCount = watchingStatuses.Length + 1;
            playCount = playingStatuses.Length + 1;
            listenCount = listeningStatuses.Length + 1;

            while (true)
            {
                int startNumb = RandNumbGen(0, 5);

                if (startNumb == 1)
                {
                    await SetWatchingStatus();
                }
                else if (startNumb == 2)
                {
                    await SetPlayingStatus();
                }
                else if (startNumb == 3)
                {
                    await SetListeningStatus();
                }
                else if (startNumb == 4)
                {
                    await ClearStatus();
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

        //Set statuses
        public async Task SetWatchingStatus()
        {
            await _discord.SetGameAsync(watchingStatuses[RandNumbGen(0, watchCount)], null, ActivityType.Watching);
            return;
        }

        public async Task SetPlayingStatus()
        {
            await _discord.SetGameAsync(playingStatuses[RandNumbGen(0, playCount)], null, ActivityType.Playing);
            return;
        }

        public async Task SetListeningStatus()
        {
            await _discord.SetGameAsync(listeningStatuses[RandNumbGen(0, listenCount)], null, ActivityType.Listening);
            return;
        }

        public async Task ClearStatus()
        {
            await _discord.SetGameAsync(null, null, ActivityType.Listening);
            return;
        }
    }
}
