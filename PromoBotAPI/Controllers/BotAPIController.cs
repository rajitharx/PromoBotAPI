namespace PromoBotAPI.Controllers
{
    using ApiAiSDK;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;

    public class BotAPIController : Controller
    {
        private string fbToken = "xxxxxxxxxxxxxxxxxx";
        private string postUrl = "https://graph.facebook.com/v2.6/me/messages";
        private string apiAiToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Webhook([FromQuery(Name = "hub.mode")] string mode,
                    [FromQuery(Name = "hub.challenge")] string challenge,
                    [FromQuery(Name = "hub.verify_token")] string verify_token)
        {
            if (verify_token.Equals("my_token_is_great"))
            {
                return challenge;
            }
            else
            {
                return "";
            }
        }

        [HttpPost]
        public void Webhook()
        {
            var json = (dynamic)null;
            try
            {
                using (StreamReader sr = new StreamReader(this.Request.Body))
                {
                    json = sr.ReadToEnd();
                }
                dynamic data = JsonConvert.DeserializeObject(json);

                PostToFB((string)data.entry[0].messaging[0].sender.id, (string)data.entry[0].messaging[0].message.text);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void PostToFB(string recipientId, string messageText)
        {
            //Post to ApiAi
            string messageTextAnswer = PostApiAi(messageText);
            string postParameters = string.Format("access_token={0}&recipient={1}&message={2}",
                                            fbToken,
                                            "{ id:" + recipientId + "}",
                                            "{ text:\"" + messageTextAnswer + "\"}");

            //Response from ApiAI or answer to FB question from user post it to FB back.
            var client = new HttpClient();
            client.PostAsync(postUrl, new StringContent(postParameters, Encoding.UTF8, "application/json"));
        }

        public string PostApiAi(string messageText)
        {
            var config = new AIConfiguration(apiAiToken, SupportedLanguage.English);
            ApiAi apiAi = new ApiAi(config);

            var response = apiAi.TextRequest(messageText);
            return response.Result.Fulfillment.Speech;
        }
    }
}