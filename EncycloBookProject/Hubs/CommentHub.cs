using Microsoft.AspNetCore.SignalR;

namespace EncycloBookProject.Hubs
{
    public class CommentHub : Hub
    {
        public async Task AddComment(string user, string comment, string time)
        {
            await Clients.All.SendAsync("ReceiveComment", user, comment, time);
        }

    }
}
