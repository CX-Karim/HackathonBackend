using System;
using System.Collections.Generic;
using System.Text;

namespace HackathonBackend.Options
{
    class LanguageOptions
    {
        public static readonly string options = "IdentifiableLanguages";
        public LangConfig[] IdentifiableLanguages;
    }

    class LangConfig{
        public string name { get; set; }
        public string code { get; set; }
    }
}
