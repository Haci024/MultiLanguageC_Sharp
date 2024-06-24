using Microsoft.AspNetCore.Localization;
using MultiLanguageC_.Services;

public class LanguageService
{
    private readonly LocalizationService _localizationService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LanguageService(LocalizationService localizationService, IHttpContextAccessor httpContextAccessor)
    {
        _localizationService = localizationService;
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetKey(string key)
    {
        var culture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "az-AZ";
        return _localizationService.GetResource(culture, key);
    }
}
