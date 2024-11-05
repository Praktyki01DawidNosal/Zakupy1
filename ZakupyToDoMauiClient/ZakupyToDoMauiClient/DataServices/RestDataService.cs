using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ZakupyToDoMauiClient.Models;

namespace ToDoMauiClient.DataServices
{
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService(HttpClient httpClient)
        {
            //_httpClient = new HttpClient();
            _httpClient = httpClient;

            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5209" : "https://localhost:7209";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }



        public async Task AddToDoAsync(ZakupyToDo zakupyToDo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize<ZakupyToDo>(zakupyToDo, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/todo", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully created ZakupyToDo");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;

        }

        public Task AddZakupyToDoAsync(ZakupyToDo zakupyToDo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteZakupyToDoAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/todo/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully created ZakupyToDo");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }

        public async Task<List<ZakupyToDo>> GetAllToDosAsync()
        {
            List<ZakupyToDo> zakupyToDos = new List<ZakupyToDo>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return zakupyToDos;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    zakupyToDos = JsonSerializer.Deserialize<List<ZakupyToDo>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return zakupyToDos;
        }

        public async Task UpdateToDoAsync(ZakupyToDo zakupyToDo)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                string jsonToDo = JsonSerializer.Serialize<ZakupyToDo>(zakupyToDo, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonToDo, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/todo/{zakupyToDo.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Successfully created ToDo");
                }
                else
                {
                    Debug.WriteLine("---> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return;
        }

        public Task UpdateZakupyToDoAsync(ZakupyToDo toDo)
        {
            throw new NotImplementedException();
        }

        Task<List<ZakupyToDo>> IRestDataService.GetAllToDosAsync()
        {
            throw new NotImplementedException();
        }
    }
}