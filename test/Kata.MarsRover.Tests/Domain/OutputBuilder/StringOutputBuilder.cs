using System.Text;

namespace Kata.MarsRover.Tests.Domain.OutputBuilder {
    public class StringOutputBuilder : IOutputBuilder
    {
        public string Result => _sbResult.ToString();

        private readonly StringBuilder _sbResult;

        public StringOutputBuilder()
        {
            _sbResult = new StringBuilder();
        }

        public void AddResult(string result) {
            // TODO: if result is empty do noting
            if (_sbResult.Length > 0)
            {
                _sbResult.AppendLine();
            }

            _sbResult.Append(result);
        }
    }
}