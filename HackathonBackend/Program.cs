using System;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Translation;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Threading.Tasks;


namespace HackathonBackend
{
    class Program
    {
        public static async Task Transcribe() 
        {
            var config = SpeechTranslationConfig.FromSubscription("TEXT ME TO GET IT", "westeurope");
            var autoDetectSourceLanguageConfig =
            AutoDetectSourceLanguageConfig.FromLanguages(
            new string[] { "ar-EG", "en-US", "fr-FR" });

            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using (var recognizer = new SpeechRecognizer(
                config,
                autoDetectSourceLanguageConfig,
                audioConfig))
            {
                var speechRecognitionResult = await recognizer.RecognizeOnceAsync();
                var autoDetectSourceLanguageResult =
                    AutoDetectSourceLanguageResult.FromResult(speechRecognitionResult);
                var detectedLanguage = autoDetectSourceLanguageResult.Language;
                config.SpeechRecognitionLanguage = detectedLanguage;
                config.AddTargetLanguage("ar-EG");
                Console.WriteLine(detectedLanguage);
            }
        }
        static async Task Main(string[] args)
        {
            await Transcribe();
            Console.WriteLine("Hello World!");
        }
    }
}
