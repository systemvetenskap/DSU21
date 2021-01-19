using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DSU21;
using DSU21.Data;
using Moq;
using System.Threading.Tasks;

namespace DSU21Tests
{
    public class Day1Tests
    {
        [Fact]
        public void SumTwoEntries_ShouldReturnSum()
        {
            // Arrange
            int expected = 514579;
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\eriobe\source\repos\DSU21\DSU21Tests\Input\Day1.txt");

            // Act
            int actual = Day1.SumTwoEntries(input);

            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("17,x,13,19", 3417)]
        [InlineData("17,x,13,3", 444)]
        [InlineData("17,x,13,19", 4545)]
        [InlineData("17,x,13,19", 34145457)]
        [InlineData("17,x,13,19", 34454517)]
        [InlineData("17,x,13,19", 45)]
        [InlineData("17,x,13,19", 22245)]
        public void CalculateBusTimeSlots_ShouldReturnSum(string value, int expected)
        {
            // Arrange

            // Act
            int actual = Day1.CalculateBusTimeSlots(value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetPerson_ShouldReturnPersonObject()
        {
            var person = new Person()
            {
                Name = "Erik"
            };
            var mock = new Mock<IPersonRepository>();
            var sut = new Controller(mock.Object);
            mock.Setup(x => x.GetPerson(It.IsAny<int>())).Returns(await Task.FromResult<Person>(person));
            var actual = await sut.GetPerson(2);
            Assert.Equal(actual.Name, person.Name);

            mock.Verify(x => x.GetPerson(2), Times.Exactly(1));

            
        }

    }
}
