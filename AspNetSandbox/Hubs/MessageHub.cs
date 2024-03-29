﻿// <copyright file="MessageHub.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AspNetSandbox
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}