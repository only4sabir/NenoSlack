using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NenoSlack.Models
{
    public class SessionValue
    {
    }
    public class OnlineUser
    {
        public int UserId { get; set; }
        public List<ConnectionId> connectionIds{ get; set; }
    }
    public class ConnectionId
    {
        public string connectionId { get; set; }
    }
}
