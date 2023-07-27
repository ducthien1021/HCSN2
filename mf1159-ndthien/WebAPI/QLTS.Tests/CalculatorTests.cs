using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTS.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(1, 2, 3)]
        [TestCase(2, 3, 5)]
        [TestCase(int.MaxValue, 1, int.MaxValue + (long)1)]
        public void Add_ValidInput_ValidResult(int x, int y, long expectedResult)
        {
            // Ctrl R R: Rename toàn bộ tên biến, hàm
            // F12: Vào hàm
            // Ctrl - : thoát hàm
            // shift alt ;: bôi đen toàn bộ
            // ctrl k s: region

            // Act: hành động gọi đến hàm cần test 
            var actualResult = new Calculator().Add(x, y);

            // Assert: xác định kết quả trả về
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [TestCase(1, 2, -1)]
        [TestCase(2, 3, -1)]
        [TestCase(10, 3, 7)]
        [TestCase(10, 10, 0)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue - (long)int.MinValue)]
        public void Sub_ValidInput_ValidResult(int x, int y, long expectedResult)
        {
            // Act: hành động gọi đến hàm cần test 
            var actualResult = new Calculator().Sub(x, y);

            // Assert: xác định kết quả trả về
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(1, 2, 2)]
        [TestCase(2, -3, -6)]
        [TestCase(10, 3, 30)]
        [TestCase(10, 10, 100)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)int.MinValue)]
        public void Mul_ValidInput_ValidResult(int x, int y, long expectedResult)
        {
            // Act: hành động gọi đến hàm cần test 
            var actualResult = new Calculator().Mul(x, y);

            // Assert: xác định kết quả trả về
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [Test]
        public void Div_DivideByZero_ReturnsException()
        {
            // Arrange
            int x = 1;
            int y = 0;

            var expectedExceptionMessage = "Không chia được cho 0";

            // Act And Assert
            var exception = Assert.Throws<Exception>(() => { new Calculator().Div(x, y); });

            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [TestCase(1, 2, 0.5)]
        [TestCase(2, 3, (double)2 / 3)]
        public void Div_ValidInput_ValidResult(int x, int y, double expectedResult)
        {
            // Act: hành động gọi đến hàm cần test 
            var actualResult = new Calculator().Div(x, y);

            // Assert: xác định kết quả trả về
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1, 2, 3", 6)]
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,", 1)]
        [TestCase("1,2,", 3)]
        [TestCase("123,234,456", 123 + 234 + 456)]
        [TestCase("123111111,234456,456234", 123111111 + 234456 + 456234)]
        public void Add_ValidString_ValidResult(string s, long expectedResult)
        {
            // Act: hành động gọi đến hàm cần test 
            var actualResult = new Calculator().Add(s);

            // Assert: xác định kết quả trả về
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [Test]
        public void Add_InvalidString_ValidResult()
        {
            // Arrange
            var s = "1,-2,-3";

            var expectedExceptionMessage = "Không chấp nhận toán tử âm: -2, -3";

            // Act And Assert
            var exception = Assert.Throws<Exception>(() => { new Calculator().Add(s); });

            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void Add_InvalidNumberFormat_ValidResult()
        {
            // Arrange
            var s = "12311$abc,234da456,4562$34, 123";

            var expectedExceptionMessage = "Các chuỗi không phải là số: 12311$abc, 234da456, 4562$34";

            // Act And Assert
            var exception = Assert.Throws<Exception>(() => { new Calculator().Add(s); });

            Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
        }
    }
}
