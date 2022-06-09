using Azure;
using Azure.AI.TextAnalytics;

namespace DemoTextAnalytics
{
    public class AzureCredentials
    {
        private static readonly AzureKeyCredential credendials = new ("your Key");

        private static readonly Uri endpoint = new ("your endpoint");

        public void TextAnalityc() 
        {
            Console.WriteLine("Testing text analytics with azure");

            var client = new TextAnalyticsClient(endpoint, credendials);

            Console.WriteLine("Write the text to be analyzed");

            string text = Console.ReadLine();

            KeyPhraseExtraction(client, text);

            Console.WriteLine("Press a key to finish");

            Console.ReadLine();

        }

        private void KeyPhraseExtraction(TextAnalyticsClient client, string text)
        {
            var response = client.ExtractKeyPhrases(text);

            Console.WriteLine("The following key phrases have been detected:");

            foreach (string keyPhrase in response.Value)
            {
                Console.WriteLine(keyPhrase + "\t");
            }
        }
    }
}
