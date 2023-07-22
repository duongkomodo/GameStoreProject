using DataAccess.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace GameStoreClient.APIHelper
{
    public static class SendApiRequest
    {
        public static async Task<T>? SendApiRequestAsync<T>(string url, HttpMethod method, object? requestBody = null, string? jwt = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(method, url);
                    if (jwt != null)
                    {
                        // Set JWT token in Authorization header
                         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                    }
                    if (requestBody != null)
                    {
                        var content = JsonConvert.SerializeObject(requestBody);
                        request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                    }
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(responseContent);
                    }
                    throw new Exception($"Failed to send API request: {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static async Task<ImageOutputDto>? UploadImageAsync(string url, byte[] data = null, string? jwt = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    if (jwt != null)
                    {
                        // Set JWT token in Authorization header
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                    }

                    var content = data;
                        request.Content = new ByteArrayContent(content);
                    
                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                         responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ImageOutputDto>(responseContent);
                    }
                    throw new Exception($"Failed to send API request: {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
