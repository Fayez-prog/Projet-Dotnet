using Chatbot.Helpers;
using Chatbot.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Chatbot.Controllers
{
    public class ChatClientController : Controller
    {
        private readonly ChatService _chatService;
        private readonly HttpClient _httpClient;

        public ChatClientController(IConfiguration configuration, HttpClient httpClient)
        {
            _chatService = new ChatService(configuration);
            _httpClient = httpClient;
        }

        [Route("chat/Clients")]
        [HttpGet]
        public IActionResult Chat()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Questionner(string userQuestion)
        {
            if (string.IsNullOrEmpty(userQuestion))
            {
                ViewData["ResponseMessage"] = "La question est requise.";
                return View("Chat");
            }

            var query = await AnalyzeIntent(userQuestion);
            Console.WriteLine($"Requête : {query}");

            var analysis = new IntentAnalysisResult();
            analysis.Query = query;
            analysis.Table = "Clients";

            var data = await _chatService.ExecuteSqlQuery(analysis);
            Console.WriteLine($"Clients : {data}");

            ViewData["ResponseMessage"] = GenerateResponse(data);
            return View("Chat");
        }

        public async Task<string> AnalyzeIntent(string userQuestion)
        {
            {
                var prompt = $@"
                Tu es un assistant spécialisé en bases de données SQL Server.
                Génère une requête SQL Server valide et optimisée pour répondre à la question suivante :
                '{userQuestion}'
                - Assure-toi que la syntaxe est correcte et compatible avec SQL Server.
                - Si la question manque de précision, propose une requête qui retourne tous les clients.
                - Utilise des alias explicites pour améliorer la lisibilité si nécessaire.
                - le nom de la table est clients
                - Évite les requêtes dangereuses comme la suppression ou la modification massive des données.
                - Les noms des champs doivent être en un seul mot et en Français.
                - Les champs sont : Id Nom Adresse NumTel Email
                - Retourne uniquement la requête SQL, sans explication supplémentaire ni commentaire.
                - La requête se termine toujours par un point virgule.
                ";

                var llamaResponse = await CallLlama(prompt);
                Console.WriteLine($"Réponse brute de llama : {llamaResponse}");

                var responseText = "";
                try
                {
                    dynamic responseObject = JsonConvert.DeserializeObject(llamaResponse);
                    responseText = responseObject.response;
                    Console.WriteLine("La requête SQL :");
                    Console.WriteLine(responseText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de l'analyse de la réponse : {ex.Message}");
                }

                return responseText;
            }
        }

        public async Task<string> CallLlama(string prompt)
        {
            var requestContent = new OllamaRequest
            {
                Model = "llama3",
                Prompt = prompt,
                Stream = false
            };

            var jsonRequest = System.Text.Json.JsonSerializer.Serialize(requestContent);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ollama Response: {responseContent}");
                return responseContent;
            }

            Console.WriteLine($"Ollama Response Pb : {response.StatusCode} - {response.ReasonPhrase}");
            return "Error contacting Ollama API";
        }

        private string GenerateResponse(List<Dictionary<string, object>> data)
        {
            if (data.Count == 0)
                return "Aucune donnée trouvée.";

            var response = "<ul>";
            foreach (var row in data)
            {
                response += "<li>" + string.Join(", ", row.Select(kv => $"{kv.Key}: {kv.Value}")) + "</li>";
            }
            response += "</ul>";
            return response;
        }
    }
}
