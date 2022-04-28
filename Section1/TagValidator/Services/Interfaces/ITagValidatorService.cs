using System;
using System.Collections.Generic;
using System.Text;

namespace TagValidator.Services.Interfaces
{
    public interface ITagValidatorService
    {
        public string GetClosingTag(string openingTag);
        public bool IsValidPair(string openingTag, string closingTag);
        public bool IsValidOpeningTag(string tagName);
        public bool IsValidClosingTag(string tagName);
    }
}
