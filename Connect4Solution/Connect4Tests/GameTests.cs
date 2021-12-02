using Connect4Solution;
using NUnit.Framework;

namespace Connect4Tests
{
    public class GameTests
    {
        private Connect4 game;

        [SetUp]
        public void SetUp()
        {
            game = new Connect4();
        }

        [Test]
        public void Play_Players_Should_Take_Turns_To_Drop_Discs()
        {
            var firstPlay = game.Play(1);
            var secondPlay = game.Play(1);
            var thirdPlay = game.Play(1);
            var fourthPlay = game.Play(1);
            var fifthPlay = game.Play(1);

            Assert.That(firstPlay, Is.EqualTo("Player 1 has a turn"));
            Assert.That(secondPlay, Is.EqualTo("Player 2 has a turn"));
            Assert.That(thirdPlay, Is.EqualTo("Player 1 has a turn"));
            Assert.That(fourthPlay, Is.EqualTo("Player 2 has a turn"));
            Assert.That(fifthPlay, Is.EqualTo("Player 1 has a turn"));
        }

        [Test]
        public void Play_When_Column_Is_Full_Should_Return_Message_Column_Full()
        {
            game.Play(1);
            game.Play(1);
            game.Play(1);
            game.Play(1);
            game.Play(1);
            game.Play(1);

            var columnFull = game.Play(1);

            Assert.That(columnFull, Is.EqualTo("Column full!"));
        }

        [Test]
        public void Play_When_Column_Is_Full_Next_Move_Should_Be_By_The_Same_Player()
        {
            game.Play(1);
            game.Play(1);
            game.Play(1);
            game.Play(1);
            game.Play(1);
            game.Play(1);

            var columnFull = game.Play(1);
            var nextMove = game.Play(2);

            Assert.That(columnFull, Is.EqualTo("Column full!"));
            Assert.That(nextMove, Is.EqualTo("Player 1 has a turn"));
        }

        [Test]
        public void Play_When_Player_Has_Four_Horizontally_Shoul_Win()
        {
            game.Play(1);
            game.Play(1);
            game.Play(2);
            game.Play(2);
            game.Play(3);
            game.Play(3);

            var playerOne = game.Play(4);

            Assert.That(playerOne, Is.EqualTo("Player 1 wins!"));
        }

        [Test]
        public void Play_When_Player_Has_Four_Vertically_Shoul_Win()
        {
            game.Play(1);
            game.Play(2);
            game.Play(1);
            game.Play(3);
            game.Play(1);
            game.Play(2);

            var playerOne = game.Play(1);

            Assert.That(playerOne, Is.EqualTo("Player 1 wins!"));
        }

        [Test]
        public void Play_When_Player_Has_Four_Diagonally_Should_Win()
        {
            game.Play(0);
            game.Play(0);
            game.Play(0);
            game.Play(0);
            game.Play(1);
            game.Play(1);
            game.Play(0);
            game.Play(1);
            game.Play(2);
            game.Play(2);
            game.Play(0);

            var playerTwo = game.Play(3);

            Assert.That(playerTwo, Is.EqualTo("Player 2 wins!"));
        }

        [Test]
        public void Play_When_Player_Has_Four_In_Upward_Diagonal_Should_Win()
        {
            game.Play(0);
            game.Play(1);
            game.Play(1);
            game.Play(2);
            game.Play(2);
            game.Play(3);
            game.Play(2);
            game.Play(3);
            game.Play(3);

            var playerTwo = game.Play(4);

            Assert.That(playerTwo, Is.EqualTo("Player 2 wins!"));
        }

        [Test]
        public void Play_When_Game_Is_Over_Should_Return_Message_Game_Has_Finished()
        {
            game.Play(0);
            game.Play(1);
            game.Play(1);
            game.Play(2);
            game.Play(2);
            game.Play(3);
            game.Play(2);
            game.Play(3);
            game.Play(3);
            game.Play(4);

            var playerTwo = game.Play(5);

            Assert.That(playerTwo, Is.EqualTo("Game has finished!"));
        }
    }
}