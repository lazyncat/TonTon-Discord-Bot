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

namespace TonTon_Discord_Bot
{
	public class Program
	{
        public static async Task Run(string[] args) => await Startup.RunAsync(args);
        public static async Task Main(string[] args)
        {
            Console.Title = "TonTon Discord Bot";
            //Start phase
            //"Are you sure?" type check
            Console.WriteLine($"It's {DateTime.Now}...");
            await Task.Delay(500);
            Console.WriteLine("Ton is up in her room, doing who knows what");
            await Task.Delay(500);
            Console.WriteLine("Call her?");
            Console.WriteLine("");

            for (int i = 0; i <= 1; i--)
            {
                //Passcode reader
                Console.BackgroundColor = ConsoleColor.Blue;
                string userConsoleInput = Console.ReadLine();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");

                //Verify
                if (userConsoleInput == "Ton Futsumaki!")
                {
                    i = 10;

                    await Task.Delay(500);
                    Console.Write(".");
                    await Task.Delay(500);
                    Console.Write(".");
                    await Task.Delay(500);
                    Console.WriteLine(".");
                    Console.WriteLine("");
                    await Task.Delay(1000);

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("FUTSUMAKI!!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("");
                    await Task.Delay(2000);

                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Orokana haisha...");
                    await Task.Delay(1000);
                    Console.WriteLine("Why do I have to get uppp... T~T");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    await Task.Delay(500);

                    Console.WriteLine("You guess that she was sleeping after all");
                    Console.WriteLine("");

                    await Run(args);
                }
                else
                {
                    Console.WriteLine("Ton ignored you...");
                    Console.WriteLine("");
                }
            }
        }
    }
}
