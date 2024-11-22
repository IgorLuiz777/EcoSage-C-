using GroqApiLibrary;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ECOSAGE.SERVICE.ai
{
    public class AiService
    {
        private readonly string _apiKey = "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";
        private readonly GroqApiClient _groqApi;

        public AiService()
        {
            _groqApi = new GroqApiClient(_apiKey);
        }

        public async Task<string> SendMessageToAiAsync(string userMessage)
        {
            var request = new JsonObject
            {
                ["model"] = "llama3-70b-8192", 
                ["temperature"] = 0.7,
                ["max_tokens"] = 150,
                ["messages"] = new JsonArray
                {
                    new JsonObject
                    {
                        ["role"] = "system",
                        ["content"] = "Você é um assistente que irá ajuadr usuário sobre o assunto de energia limpa e economia de energia. Com o foco em pegada de carbono" +
                        "Mande respostas curtas e que seja coerente ao assunto."
                    },
                    new JsonObject
                    {
                        ["role"] = "user",
                        ["content"] = userMessage
                    }
                }
            };

            var result = await _groqApi.CreateChatCompletionAsync(request);

            return result?["choices"]?[0]?["message"]?["content"]?.ToString();
        }
    }
}
