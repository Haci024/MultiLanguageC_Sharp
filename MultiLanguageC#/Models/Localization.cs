using System.ComponentModel.DataAnnotations;

namespace MultiLanguageC_.Models
{

public class Localization
    {
        [Key]
        public int Id { get; set; }
        public string Culture { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }
    }

}

