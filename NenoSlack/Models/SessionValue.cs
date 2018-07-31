using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NenoSlack.Models
{
    public static class SessionValue 
    {
        public static List<OnlineUser> onlineUsers = new List<OnlineUser>();
    }
    public class OnlineUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> connectionIds { get; set; }
        public string Img { get; set; }
    }
    public class ConnectionId
    {
        public string connectionId { get; set; }
    }
}
