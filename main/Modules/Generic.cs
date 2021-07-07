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

namespace TonTon_Discord_Bot.Modules
{
    public class Generic : ModuleBase
    {
        [Command("ping!")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("What's ping?");
        }

        [Command("user-info")]
        public async Task UserInfo(SocketGuildUser user = null)
        {
            if (user == null)
            {
                var builder = new EmbedBuilder()
                    .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .WithDescription("Here's information of you!")
                    .WithColor(new Color(252, 161, 3))
                    .AddField("User ID", Context.User.Id, true)
                    .AddField("Created at", Context.User.CreatedAt.ToString("dd/MM/yyyy"))
                    .AddField("Joined at", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                    .AddField("Roles", string.Join(" ", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)))
                    .WithCurrentTimestamp();

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else
            {
                var builder = new EmbedBuilder()
                    .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                    .WithDescription("Here's information of them!")
                    .WithColor(new Color(80, 40, 200))
                    .AddField("User ID", user.Id, true)
                    .AddField("Created at", user.CreatedAt.ToString("dd/MM/yyyy"))
                    .AddField("Joined at", user.JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                    .AddField("Roles", string.Join(" ", user.Roles.Select(x => x.Mention)))
                    .WithCurrentTimestamp();

                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
        }

        [Command("server-info")]
        public async Task ServerInfo()
        {
            var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithTitle($"{Context.Guild.Name}")
                .WithDescription("Some information of the server you called this command in!")
                .WithColor(new Color(80, 40, 200))
                .AddField("Created at", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Total membercount", (Context.Guild as SocketGuild).MemberCount + " members!", true)
                .AddField("Online currently", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Online).Count() + " members", true)
                .AddField("Roles", string.Join(" ", (Context.Guild as SocketGuild).Roles.Select(x => x.Mention)))
                .WithCurrentTimestamp();

            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
