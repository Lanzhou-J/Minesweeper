using System.Collections.Generic;
using Minesweeper;

namespace MinesweeperTests
{
    public class MockInput : IInput
    {
        private readonly Queue <string>_testResponses = new Queue<string>();
        
        public MockInput(IEnumerable<string> testResponse)
        {
            foreach (var response in testResponse)
            {
                _testResponses.Enqueue(response);
            }
        }
        public string Ask(string question)
        {
            var response = _testResponses.Dequeue();
            return response;
        }
    }
}