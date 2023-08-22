using Microsoft.AspNetCore.SignalR;

namespace StudentManagement.Data.Helper
{
    public class UploadHub:Hub
    {
        public async Task SendProgress(int percentageCompleted,double uploadingRecords,double totalRecords)
        {
            await Clients.All.SendAsync("getprogress", percentageCompleted,  uploadingRecords,  totalRecords);
        }
    }
}
