using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;


namespace MyApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] Scopes = { GmailService.Scope.GmailModify };
            string ApplicationName = "ClearEmailBox";

            using var stream = new FileStream(
                "credentials/client_secret.json",
                FileMode.Open,
                FileAccess.Read
            );

            var credPath = "credentials/token.json";

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)
            );

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var request = service.Users.Messages.List("me");
            request.MaxResults = 100;

            var response = await request.ExecuteAsync();

            Console.WriteLine("📨 Últimos e-mails:");

            if (response.Messages != null)
            {
                foreach (var message in response.Messages)
                {
                    var mods = new Google.Apis.Gmail.v1.Data.ModifyMessageRequest
                    {
                        AddLabelIds = new List<string> { "TRASH" }
                    };

                    service.Users.Messages.Modify(mods, "me", message.Id).Execute();

                    Console.WriteLine($"🗑 Email {message.Id} enviado para a lixeira");

                }
            }
            else
            {
                Console.WriteLine("Nenhum e-mail encontrado.");
            }

            Console.WriteLine("Finalizado. Pressione qualquer tecla...");
            Console.ReadKey();

        }
    }
}