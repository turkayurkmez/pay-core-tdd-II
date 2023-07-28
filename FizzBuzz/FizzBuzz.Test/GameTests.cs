namespace FizzBuzz.Test
{
    public class GameTests
    {
        /*
         *   BDD
         *   User Story:
         *   
         *   Ben bir [ROL] olarak
         *   Bir [TALEP - İŞLEV] yapmak istiyorum
         *   Böylelikle [SONUÇ] elde ediyorum
         *   
         *   Ben bir OYUNCU olarak
         *   3 SAYISINI VERMEK İstiyorum
         *   Böylelikle FİZZ değerini elde ediyorum
         */

        //1. İhtiyaç duyduğunuz nesneler  ve fonksiyonlar var mı?

        //[Fact]
        //public void ItExists()
        //{
        //    var board = new FizzBuzz.Game.GameBoard();
        //    string response = board.GetWordOrNumber(8);

        //}

        [Fact]
        public void Given_3_Then_Fizz()
        {
            /*
             * AAA*/
            //Arrange: Test edeceğiniz objeyi, fonksiyonu ve bu fonksiyona göndereceğiniz parametreleri hazırlayın

            var board = new FizzBuzz.Game.GameBoard();
            var number = 3;

            //Act: Test edeceğiniz fonksiyon (birim)
            var response = board.GetWordOrNumber(number);
            //Assert: Elde etmek istediğiniz sonuç(lar) ile asıl sonucu karşılaştırın.
            Assert.Equal("Fizz", response);
        }

        [Fact]
        public void Given_5_Then_Buzz()
        {
            var board = new FizzBuzz.Game.GameBoard();
            var number = 5;

            //Act: Test edeceğiniz fonksiyon (birim)
            var response = board.GetWordOrNumber(number);
            //Assert: Elde etmek istediğiniz sonuç(lar) ile asıl sonucu karşılaştırın.
            Assert.Equal("Buzz", response);
        }

        [Fact]
        public void Given_15_Then_FizzBuzz()
        {
            var board = new FizzBuzz.Game.GameBoard();
            var number = 15;

            //Act: Test edeceğiniz fonksiyon (birim)
            var response = board.GetWordOrNumber(number);
            //Assert: Elde etmek istediğiniz sonuç(lar) ile asıl sonucu karşılaştırın.
            Assert.Equal("FizzBuzz", response);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void Given_Multiply_3_Then_Fizz(int number)
        {
            var board = new FizzBuzz.Game.GameBoard();
            //var number = 15;

            //Act: Test edeceğiniz fonksiyon (birim)
            var response = board.GetWordOrNumber(number);
            //Assert: Elde etmek istediğiniz sonuç(lar) ile asıl sonucu karşılaştırın.
            Assert.Equal("Fizz", response);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void Given_Another_Numbers_Then_String_Of_A_Number(int number)
        {
            var board = new FizzBuzz.Game.GameBoard();
            //var number = 15;

            //Act: Test edeceğiniz fonksiyon (birim)
            var response = board.GetWordOrNumber(number);
            //Assert: Elde etmek istediğiniz sonuç(lar) ile asıl sonucu karşılaştırın.
            Assert.Equal(number.ToString(), response);
        }

        [Theory]
        [InlineData(25)]
        [InlineData(10)]
        [InlineData(20)]
        public void Given_Multiply_5_Then_Buzz(int number)
        {
            var board = new FizzBuzz.Game.GameBoard();
            //var number = 15;

            //Act: Test edeceğiniz fonksiyon (birim)
            var response = board.GetWordOrNumber(number);
            //Assert: Elde etmek istediğiniz sonuç(lar) ile asıl sonucu karşılaştırın.
            Assert.Equal("Buzz", response);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void Given_Multiply_15_Then_Buzz(int number)
        {
            var board = new FizzBuzz.Game.GameBoard();
            //var number = 15;

            //Act: Test edeceğiniz fonksiyon (birim)
            var response = board.GetWordOrNumber(number);
            //Assert: Elde etmek istediğiniz sonuç(lar) ile asıl sonucu karşılaştırın.
            Assert.Equal("FizzBuzz", response);
        }
    }
}