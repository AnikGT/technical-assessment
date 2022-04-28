using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TagValidator.Services.Interfaces;

namespace TagValidator.Services.Implements
{
    public class TagCheckerService : ITagCheckerService
    {
        private readonly ITagValidatorService _tagValidatorService;
        public TagCheckerService(ITagValidatorService tagValidatorService)
        {
            _tagValidatorService = tagValidatorService;
        }


        /// <summary>
        /// To identify the paragraph is valid or not.
        /// Time Complexity : O(n) where n is the length of input string. 
        /// </summary>
        public void TagChecker(string inputString)
        {
            
            var openingTags = new Stack<string>(); // To hold all opening tag
            var ClosingTags = new Queue<string>(); // TO hold all closing tag
            var resultFlag = true; // To track the showing result
            var currentOpeningTag = string.Empty; // To hold the top element of the stack
            var currentClosingTag = string.Empty; // To hold the front element of the queue

            var expectedTag = string.Empty; // To hold expected closing tag for showing result
            var actualTag = string.Empty; // // To hold actual closing tag for showing result

            for (int i = 0; i < inputString.Length; i++)
            {
                // Checking every adjacent 3 character to find an opening tag
                if (i + 3 <= inputString.Length)
                {
                    // To insert valid opening tag into a stack
                    if (_tagValidatorService.IsValidOpeningTag(inputString.Substring(i, 3)))
                    {
                        openingTags.Push(inputString.Substring(i, 3));
                    }
                }

                // Checking every adjacent 4 character to find a closing tag
                if (i + 4 <= inputString.Length)
                {
                    if (_tagValidatorService.IsValidClosingTag(inputString.Substring(i, 4)))
                    {
                        // Inserting valid closing tag into a queue
                        ClosingTags.Enqueue(inputString.Substring(i, 4));

                        currentOpeningTag = openingTags.Count > 0 ? openingTags.Peek() : string.Empty;
                        currentClosingTag = ClosingTags.Count > 0 ? ClosingTags.Peek() : string.Empty;

                        // Removing top element from stack and front element from queue if those are valid pair
                        if (_tagValidatorService.IsValidPair(currentOpeningTag, currentClosingTag))
                        {
                            openingTags.Pop();
                            ClosingTags.Dequeue();
                        }
                        // Showing output for not matching between opening and closing tag
                        else
                        {
                            resultFlag = false;
                            expectedTag = String.IsNullOrEmpty(currentOpeningTag) == true ? "#" : _tagValidatorService.GetClosingTag(currentOpeningTag);
                            actualTag = String.IsNullOrEmpty(currentClosingTag) == true ? "#" : currentClosingTag;
                            ShowResult(expectedTag, actualTag);
                            break;
                        }
                    }
                }
            }

            // Checking "resultFlag" as output is not shown yet

            //Showing output for empty closing tags, however opening tags aren't empty. 
            //Test case like "<A><B></B></A><C>"
            if (resultFlag && openingTags.Count > 0)
            {
                currentOpeningTag = openingTags.Peek();
                expectedTag = _tagValidatorService.GetClosingTag(currentOpeningTag);
                actualTag = "#";
                ShowResult(expectedTag, actualTag);
            }

            //Showing output for valid paragraph
            else if (resultFlag)
            {
                ShowResult();
            }
        }


        // To show the expected result
        private void ShowResult(string expectedTag = "", string actualTag = "")
        {
            if(String.IsNullOrEmpty(expectedTag) && String.IsNullOrEmpty(actualTag))
            {
                Console.WriteLine("Correctly tagged paragraph");
            }
            else
            {
                Console.WriteLine("Expected " + expectedTag + " Found " + actualTag);
            }
            
        }
        
    }
}
