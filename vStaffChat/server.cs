using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace server
{
    public class Main : BaseScript
    {
        [Command("sc")]
        public void StaffCommand(int source, List<object> args, string raw)
        {
            var player = Players[source];

            if (IsPlayerAceAllowed(player.Handle, "Viper.StaffChat"))
            {
                if (args.Count > 0)
                {
                    var name = GetPlayerName(player.Handle);
                    string text = String.Join(" ", args);

                    foreach (Player p in Players)
                    {
                        if (IsPlayerAceAllowed(p.Handle, "Viper.StaffChat"))
                        {
                            TriggerClientEvent(p, "chat:addMessage", new
                            {
                                color = new[] { 255, 0, 0 },
                                multiline = true,
                                args = new[] { $"^8[Staff Chat] {name}: ^7{text}" }
                            });

                        }
                    }

                }

            }
        }
    }
}
