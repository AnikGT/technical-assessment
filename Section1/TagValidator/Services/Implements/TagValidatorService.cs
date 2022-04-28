using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TagValidator.Services.Interfaces;

namespace TagValidator.Services.Implements
{
    public class TagValidatorService : ITagValidatorService
    {
        // To get a closing tag from an opening tag
        public string GetClosingTag(string openingTag)
        {
            return "<" + "/" + openingTag[1] + ">";
        }

        //To identify the pair of opening and closing are valid or not.
        public bool IsValidPair(string openingTag, string closingTag)
        {
            if (String.IsNullOrEmpty(openingTag) || String.IsNullOrEmpty(closingTag)) return false;
            if (openingTag[1] == closingTag[2]) return true;
            return false;
        }


        // To identify a valid opening tag.
        public bool IsValidOpeningTag(string tagName)
        {
            string openingTagPattern = @"(^<[A-Z]{1}>$)";
            var validatorExpression = new Regex(openingTagPattern);
            if (validatorExpression.IsMatch(tagName)) return true;
            return false;
        }

        // To identify a valid closing tag.
        public bool IsValidClosingTag(string tagName)
        {
            string closingTagPattern = @"(^</[A-Z]{1}>$)";
            var validatorExpression = new Regex(closingTagPattern);
            if (validatorExpression.IsMatch(tagName)) return true;
            return false;

        }
    }
}
