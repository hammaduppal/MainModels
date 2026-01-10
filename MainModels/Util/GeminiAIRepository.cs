
using Mscc.GenerativeAI;

namespace MainModels.Util
{
    public class GeminiAIRepository
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;

        private readonly GoogleAI _googleAI;

        public GeminiAIRepository(GoogleAI googleAI)
        {
            _googleAI = googleAI;
        }

        public async Task<string> GenerateContent(string prompt)
        {
            var model = _googleAI.GenerativeModel(Model.Gemini25Flash);

            var request = new GenerateContentRequest(prompt);
            var response = await model.GenerateContent(request);
            return response.Text;
        }
    }
    public interface IDataRepository
    {
        Task<string> GenerateProductDescription(string textToAnalyze);
        Task<string> ProductAdditionalInformation(string textToAnalyze);


    }
    public class DataRepository : IDataRepository
    {
        private readonly GeminiAIRepository _geminiService;

        public DataRepository(GeminiAIRepository geminiService)
        {
            _geminiService = geminiService;
        }

        public async Task<string> GenerateProductDescription(string productName)
        {
            string prompt = $@"
        You are a professional e-commerce copywriter. 
        Write a detailed, realistic, and engaging product description for the following product: ""{productName}"".
        
        The entire response **MUST** be formatted using valid HTML (including <p> and <b> tags for structure). 
        Do not include any introductory text, markdown, or explanation outside of the HTML structure.
        The description should be concise and under 250 words.
    ";
            try
            {
                string analysisResult = await _geminiService.GenerateContent(prompt);

                return analysisResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gemini API Error: {ex.Message}");
                return "Analysis failed due to an external service error.";
            }
        }

        public async Task<string> ProductAdditionalInformation(string productName)
        {
            string prompt = $@"
        You are a professional e-commerce copywriter. 
        Write a detailed, realistic, and engaging product AdditionalDetail for the following product: ""{productName}"".
        
        The entire response **MUST** be formatted using valid HTML (including <p> and <b> tags for structure). 
        Do not include any introductory text, markdown, or explanation outside of the HTML structure.
        The additional information should be concise and under 250 words.
    ";
            try
            {
                string analysisResult = await _geminiService.GenerateContent(prompt);

                return analysisResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gemini API Error: {ex.Message}");
                return "Analysis failed due to an external service error.";
            }
        }

    }

}