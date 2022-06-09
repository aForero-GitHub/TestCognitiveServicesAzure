using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Translation;

namespace DemoTranslationVoice
{
    public class AzureTranslation
    {
        private readonly string speechKey = "60d0ca6bad7d4deebcf3d623148e595b";
        private readonly string speechreRegion = "westus2";

        public async Task TraslateSpeechAsync()
        {
            var translationConfig = SpeechTranslationConfig.FromSubscription(speechKey, speechreRegion);

            var fromLanguage = "es-MX";

            var toLanguages = new List<string> { "en", "fr", "de"};

            translationConfig.SpeechRecognitionLanguage = fromLanguage;
            toLanguages.ForEach(translationConfig.AddTargetLanguage);

            using var recognizer = new TranslationRecognizer(translationConfig);

            Console.WriteLine($"Di algo que quieras traducir ({fromLanguage})");

            Console.WriteLine($"we'll translate into ' {string.Join("', '", toLanguages)}'\n");

            var result = await recognizer.RecognizeOnceAsync();

            if (result.Reason == ResultReason.TranslatedSpeech)
            {
                Console.WriteLine($"Recognized: \"{result.Text}\":");
                foreach (var (language, translation)in result.Translations)
                {
                    Console.WriteLine($"Translated into '{language}': {translation}");
                }
            }
        }
    }
}
