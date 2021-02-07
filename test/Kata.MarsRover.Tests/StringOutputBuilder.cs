using System;
using FluentAssertions;
using Xunit;
namespace Kata.MarsRover.Tests
{
    public class StringOutputBuilder : IOutputBuilder
    {
        public string Result { get; private set; }

        public void AddResult(string result)
        {
            Result = result;
        }
    }

    public class StringOutputBuilderShould {
        [Fact]
        public void Add_to_result()
        {
            var outputBuilder = new StringOutputBuilder();
            outputBuilder.AddResult("Test");
            outputBuilder.Result.Should().Be("Test");
        }
        
        [Fact]
        public void Return_all_when_multiple_result_separated_by_new_line()
        {
            var outputBuilder = new StringOutputBuilder();
            outputBuilder.AddResult("Test");
            outputBuilder.AddResult("Test");
            outputBuilder.Result.Should().Be("Test" + Environment.NewLine + "Test");
        }
    }
}