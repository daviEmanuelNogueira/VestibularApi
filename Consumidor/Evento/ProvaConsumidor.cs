using Azure.Messaging;
using Core;
using Core.Interface.Services;
using Core.Services;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using System.Text;

namespace Consumidor.Evento;
public class ProvaConsumidor : IConsumer<Prova>
{
    private readonly HttpClient _httpClient;

    public ProvaConsumidor(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Consume(ConsumeContext<Prova> context)
    {
        var apiUrl = "http://localhost:5259/api/Prova/CreateProvaByConsumer";
        string json = JsonConvert.SerializeObject(context.Message);
        using (var httpClient = new HttpClient())
        {
            // Create a StringContent object from the JSON message
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // Send the message via POST request
                var response = await httpClient.PostAsync(apiUrl, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent successfully");
                }
                else
                {
                    Console.WriteLine($"Failed to send message. Status code: {response.StatusCode}");
                    Console.WriteLine($"Response: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
