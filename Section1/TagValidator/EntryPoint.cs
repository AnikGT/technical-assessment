using System;
using TagValidator.Services.Interfaces;

namespace TagValidator
{
    public class EntryPoint
    {
        private readonly ITagCheckerService _tagCheckerService;


        public EntryPoint(ITagCheckerService tagCheckerService)
        {
            _tagCheckerService = tagCheckerService;
        }
        public void Run(String[] args)
        {
            Console.WriteLine("Press ctrl + z to exit.");
            while (true)
            {
                Console.Write("Enter the input : ");
                var inputString = Console.ReadLine();
                _tagCheckerService.TagChecker(inputString);
            }
            
        }
    }
}