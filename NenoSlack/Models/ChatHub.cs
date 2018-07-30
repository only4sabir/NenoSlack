using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NenoSlack.Models
{
    public class ChatHub : Hub
    {
        private static List<string> users = new List<string>();
        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToGroups(string message)
        {
            List<string> groups = new List<string>() { "SignalR Users" };
            return Clients.Groups(groups).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            users.Add(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            users.Remove(Context.ConnectionId);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
        public string getid()
        {
            var a = "";// Context.ConnectionId;
            return a.ToString();
        }
        public async Task SendMessage(string user, string message)
        {
            var senderId = Context.ConnectionId;
            await Clients.All.SendAsync("ReceiveMessage", user, message, senderId);
        }
        //public async Task SendMessage(string user, string message)
        //{
        //    var o = Clients.All.SendAsync("ReceiveMessage", user, message);
        //    await o;
        //}
        public async Task Send(string name, string message, string connId)
        {
            var senderId = Context.ConnectionId;
            IReadOnlyList<string> lst = new List<string>() { connId, senderId };// ("s,h,,hh,h,".Split(',').ToList());
            var o = Clients.Clients(lst).SendAsync("ReceiveMessage", name, message, senderId);
            //var context = ConnectionManager.GetHubContext<SampleHub>();
            //Context.Clients.All.online(_userCount);
            //Clients.Client()

            await o;
        }
    }
    public class MyUserType
    {
        public string ConnectionId { get; set; }
        // Can have whatever you want here
    }
}
