using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MainModels
{
    public class ApiMethods
    {
        private HttpClientHandler clientHandler;
        private HttpClient client;
        public ApiMethods()
        {
            clientHandler = new HttpClientHandler();
            client = new HttpClient(clientHandler);
        }
        public async Task<ApiResponse> PostMethodNew(string BaseURL, string APIUrl, string content, string cc)
        {
            ApiResponse response = new ApiResponse();
            string text = "";

            // Initialize HttpClientHandler and HttpClient
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback =
                (HttpRequestMessage sender, X509Certificate2? cert, X509Chain chain, SslPolicyErrors policy) => true; // Keep custom validation

            client = new HttpClient(clientHandler);

            try
            {
                // Construct full URL and set up the request
                string requestUrl = BaseURL + APIUrl;
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                };
                requestMessage.Headers.Add("CompanyCode", cc);

                // Send request asynchronously and get response
                HttpResponseMessage httpResponse = await client.SendAsync(requestMessage);

                // Process response
                text = await httpResponse.Content.ReadAsStringAsync();
                response.Status = httpResponse.ReasonPhrase ?? "Unknown";
                response.StatusCode = ((int)httpResponse.StatusCode).ToString();
                response.ResponseString = text;
                response.Message = "Api responded";
            }
            catch (Exception ex)
            {
                // Handle exceptions
                response.Status = "404";
                response.StatusCode = "404";
                response.ResponseString = "";
                response.Message = ex.Message;
            }

            return response;
        }
        public ApiResponse PostMethod(string BaseURL, string APIUrl, string content, string cc)
        {
            ApiResponse response = new ApiResponse();
            string text = "";
            HttpWebResponse httpWebResponse = null;
            clientHandler.ServerCertificateCustomValidationCallback = (HttpRequestMessage sender, X509Certificate2? cert, X509Chain chain, SslPolicyErrors policy) => true;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(BaseURL + APIUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("CompanyCode", cc);
            byte[] bytes = Encoding.ASCII.GetBytes(content);
            httpWebRequest.ContentLength = bytes.Length;
            using (Stream stream = httpWebRequest.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                text = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
                string responsestring = text;
                response.Status = httpWebResponse.StatusDescription.ToString();
                response.StatusCode = httpWebResponse.StatusCode.ToString();
                response.ResponseString = responsestring;
                response.Message = "Api responded";

            }
            catch (Exception ex)
            {

                response.Status = "404";
                response.StatusCode = "404";
                response.ResponseString = "";
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ApiResponse> KeyPairMethodOne(string apiBaseUrl, string apiUrl, Dictionary<string, string> formData, string companyCode)
        {
            ApiResponse apiResponse = new ApiResponse();
            using (HttpClient httpClient = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (HttpRequestMessage sender, X509Certificate2? cert, X509Chain? chain, SslPolicyErrors sslPolicyErrors) => true
            }))
            {
                FormUrlEncodedContent content = new FormUrlEncodedContent(formData);
                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(apiBaseUrl + apiUrl, content);
                    string responseString = await response.Content.ReadAsStringAsync();
                    apiResponse.Status = response.StatusCode.ToString();
                    apiResponse.StatusCode = ((int)response.StatusCode).ToString();
                    apiResponse.ResponseString = responseString;
                    apiResponse.Message = "API responded successfully";
                }
                catch (Exception ex2)
                {
                    Exception ex = ex2;
                    apiResponse.Status = "Error";
                    apiResponse.StatusCode = "500";
                    apiResponse.ResponseString = "";
                    apiResponse.Message = ex.Message;
                }
            }

            return apiResponse;
        }




        public ApiResponse GetMethod(string ApiBaseUrl, string apiUrl, string jsonData, string cc)
        {
            ApiResponse apiResponse = new ApiResponse();
            string text = "";
            HttpWebResponse httpWebResponse = null;
            clientHandler.ServerCertificateCustomValidationCallback = (HttpRequestMessage sender, X509Certificate2? cert, X509Chain? chain, SslPolicyErrors sslPolicyErrors) => true;
            if (!string.IsNullOrEmpty(jsonData))
            {
                apiUrl = apiUrl + "?" + jsonData;
            }

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + apiUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                text = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
                apiResponse.Status = httpWebResponse.StatusDescription.ToString();
                apiResponse.StatusCode = httpWebResponse.StatusCode.ToString();
                apiResponse.ResponseString = text;
                apiResponse.Message = "API responded";
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    httpWebResponse = (HttpWebResponse)ex.Response;
                    text = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
                    apiResponse.Status = httpWebResponse.StatusDescription.ToString();
                    apiResponse.StatusCode = httpWebResponse.StatusCode.ToString();
                    apiResponse.ResponseString = text;
                }
                else
                {
                    apiResponse.Status = "404";
                    apiResponse.StatusCode = "404";
                    apiResponse.ResponseString = "";
                }

                apiResponse.Message = ex.Message;
            }
            catch (Exception ex2)
            {
                apiResponse.Status = "500";
                apiResponse.StatusCode = "500";
                apiResponse.ResponseString = "";
                apiResponse.Message = ex2.Message;
            }

            return apiResponse;
        }

        public class ApiResponse
        {
            public string? Status { get; set; }
            public string? StatusCode { get; set; }
            public string? ResponseString { get; set; }
            public string? Message { get; set; }
        }
    }

}
