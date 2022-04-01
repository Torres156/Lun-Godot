using LiteNetLib;
using LiteNetLib.Utils;
using Lun.Server.Models.Player;
using Lun.Shared.Models;
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
                case PacketClient.Register           : Register(peer, buffer); break;
                case PacketClient.Login              : Login(peer, buffer); break;
                case PacketClient.CharacterCreate    : CharacterCreate(peer, buffer); break;
                case PacketClient.CharacterUse       : CharacterUse(peer, buffer); break;
                case PacketClient.RequestGameplayData: RequestGameplayData(peer, buffer); break;
            }
        }

        static void RequestGameplayData(NetPeer peer, NetDataReader buffer)
        {
            var player = PlayerService.FindCharacter(peer);
            PlayerService.JoinGame(player);
        }

        static void CharacterUse(NetPeer peer, NetDataReader buffer)
        {
            var slot = buffer.GetInt();

            var account   = PlayerService.FindAccount(peer);
            var character = PlayerService.LoadCharacter(account.CharacterName[slot]);
            character.peer = peer;
            PlayerService.Characters.Add(character);

            Sender.GameplayStart(character);
        }

        static void CharacterCreate(NetPeer peer, NetDataReader buffer)
        {
            var slot     = buffer.GetInt();
            var name     = buffer.GetString();
            var classId  = buffer.GetInt();
            var spriteId = buffer.GetInt();

            if (PlayerService.ExistsCharacter(name))
            {
                Sender.Alert(peer, $"O nome {name} não está disponivel!");
                return;
            }

            var character = new Character();
            character.Name     = name;
            character.ClassId  = classId;
            character.SpriteId = spriteId;
            character.Position = new Vector2(10, 10) * 32;
            character.MapId    = 1;
            PlayerService.SaveCharacter(character);

            var account = PlayerService.FindAccount(peer);
            account.CharacterName[slot] = name;
            PlayerService.SaveAccount(account);

            Sender.Logged(account);
            Sender.Alert(account, "Personagem criado com sucesso!");

        }

        static void Login(NetPeer peer, NetDataReader buffer)
        {
            var user = buffer.GetString();
            var pwd  = buffer.GetString();

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

            Sender.ClassUpdate(account);
            Sender.Logged(account);
        }

        static void Register(NetPeer peer, NetDataReader buffer)
        {
            var user = buffer.GetString();
            var pwd  = buffer.GetString();

            if (PlayerService.ExistsAccount(user))
            {
                Sender.Alert(peer, $"{user} não está disponivel!");
                return;
            }

            var account = new Account();
            account.Name     = user;
            account.Password = pwd;

            PlayerService.SaveAccount(account);
            Sender.Alert(peer, $"A conta {user} foi criada com sucesso!");
        }
    }
}
