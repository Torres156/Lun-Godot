using LiteNetLib;
using LiteNetLib.Utils;
using Lun.Server.Models.Player;
using Lun.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Network
{
    internal static class Receive
    {
        public static void Handle(NetPeer peer, NetDataReader buffer)
        {
            var packet = (PacketClient)buffer.GetShort();

            switch(packet)
            {
                case PacketClient.Register: Register(peer, buffer); break;
                case PacketClient.Login: Login(peer, buffer); break;
            }
        }

        static void Login(NetPeer peer, NetDataReader buffer)
        {
            var user = buffer.GetString();
            var pwd = buffer.GetString();

            if (!PlayerService.ExistsAccount(user))
            {
                Sender.Alert(peer, $"{user} não existe!");
                return;
            }

            var find = PlayerService.FindAccount(user); 
            if (find != null)
            {
                Sender.Alert(peer, $"{user} já está sendo usado, caso não seja você contate o suporte!");
                find.peer.Disconnect();
                return;
            }

            var account = PlayerService.LoadAccount(user);
            if (account.Password != pwd)
            {
                Sender.Alert(peer, $"Conta ou senha incorreta!");
                return;
            }

            account.peer = peer;
            PlayerService.Accounts.Add(account);
            Sender.Logged(account);
        }

        static void Register(NetPeer peer, NetDataReader buffer)
        {
            var user = buffer.GetString();
            var pwd = buffer.GetString();

            if (PlayerService.ExistsAccount(user))
            {
                Sender.Alert(peer, $"{user} não está disponivel!");
                return;
            }

            var account = new Account();
            account.Name = user;
            account.Password = pwd;

            PlayerService.SaveAccount(account);
            Sender.Alert(peer, $"A conta {user} foi criada com sucesso!");
        }
    }
}
