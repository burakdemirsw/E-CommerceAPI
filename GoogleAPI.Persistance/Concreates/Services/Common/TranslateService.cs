
using Google.Api.Gax.ResourceNames;
using Google.Cloud.Translate.V3;
using GooleAPI.Application.Abstractions.IServices.Common;

namespace GoogleAPI.Persistance.Concreates.Services.Common
{
    public class TranslateService : ITranslateService
    {

        public async Task<T> Translate<T>(T obj, string targetLanguage, string sourceLanguage)
        {
            try
            {
                TranslationServiceClient client = TranslationServiceClient.Create();
                TranslateTextRequest request = new TranslateTextRequest
                {
                    Contents = { "It is raining." },
                    TargetLanguageCode = "fr-FR",
                    Parent = new ProjectName("beatzone-tr").ToString()
                };
                TranslateTextResponse response = client.TranslateText(request);
                // response.Translations will have one entry, because request.Contents has one entry.
                Translation translation = response.Translations[0];
                Console.WriteLine($"Detected language: {translation.DetectedLanguageCode}");
                Console.WriteLine($"Translated text: {translation.TranslatedText}");

                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Translation failed: {ex.Message}");
                return obj;
            }

        }

        public async static Task<string> TranslateTextAsync(string text, string targetLanguage, string sourceLanguage)
        {
            TranslationServiceClient client = await TranslationServiceClient.CreateAsync();
            LocationName location = new LocationName("beatzone-tr", "global");

            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents = { text },
                TargetLanguageCode = targetLanguage,
                SourceLanguageCode = sourceLanguage,
                ParentAsLocationName = location,
            };

            TranslateTextResponse response = await client.TranslateTextAsync(request);

            return response.Translations.First().TranslatedText;
        }


    }
}
