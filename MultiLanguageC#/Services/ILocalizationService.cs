namespace MultiLanguageC_.Services
{
    using MultiLanguageC_.Connect;
    using System.Linq;

    public class LocalizationService
    {
        private readonly LanguageDbContext _context;

        public LocalizationService(LanguageDbContext context)
        {
            _context = context;
        }

        public string GetResource(string culture, string key)
        {
            var resource = _context.Localizations
                .FirstOrDefault(r => r.Culture == culture && r.ResourceKey == key);

            return resource?.ResourceValue ?? key;
        }
    }

}
