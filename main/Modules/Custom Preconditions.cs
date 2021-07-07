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
    // Inherit from PreconditionAttribute
    public class RequireServerIdAttribute : PreconditionAttribute
    {
        // Create a field to store the specified name
        private readonly Int64 _serverId;

        // Create a constructor so the name can be specified
        public RequireServerIdAttribute(Int64 RequiredServerId) => _serverId = RequiredServerId;

        // Override the CheckPermissions method
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (Convert.ToInt64(context.Guild.Id.ToString()) == _serverId)
            {
                return Task.FromResult(PreconditionResult.FromSuccess());
            }
            else
            {
                return Task.FromResult(PreconditionResult.FromError("Sorry, You're not in the guild this command was made for!"));
            }    
        }
    }
    
}
