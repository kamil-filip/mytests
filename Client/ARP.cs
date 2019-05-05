using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class ARP : IARP
    {
        public event EventHandler OnPermissionChanged;
        public event EventHandler OnError;

        public async Task<string> HasAccess(string userName, string where)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44382/api/values");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();                          
                }
            }
            return "";
        }

        public async Task Load(string username, Action<bool, string> output)
        {
            OnNotify(new EventArgs());
            Error(new EventArgs());

            return; 
        }

        private void OnNotify(EventArgs e)
        {            
            OnPermissionChanged(this, e);            
        }

        private void Error(EventArgs e)
        {
            OnError(this, e);
        }
    }
}
