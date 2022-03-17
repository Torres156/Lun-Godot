using LiteNetLib;
using Lun.Server.Models.Player;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Services
{
    internal static class PlayerService
    {
        public static List<Account> Accounts = new List<Account>();

        public static void SaveAccount(Account account)
        {
            var path = "Accounts/";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var filePath = path + $"{account.Name.ToLower()}.json";
            var json = JsonConvert.SerializeObject(account, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static Account LoadAccount(string accountName)
        {
            var path = "Accounts/";

            if (!Directory.Exists(path))
                return null;

            var filePath = path + $"{accountName.ToLower()}.json";
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Account>(json);
        }

        public static bool ExistsAccount(string accountName)
            => File.Exists($"Accounts/{accountName.ToLower()}.json");

        public static Account FindAccount(NetPeer peer)
            => Accounts.Find(i => i.peer == peer);

        public static Account FindAccount(string accountName)
            => Accounts.Find(i => i.Name.Equals(accountName, StringComparison.OrdinalIgnoreCase));
    }
}
