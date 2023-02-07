using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test345
{
    class Player
    {
        public string Name { get; set; }
        public int TotalScore { get; set; }
        public int SuitScore { get; set; }
        public List<Card> Hand { get; set; }

        public Player(string name, List<Card> hand)
        {
            Name = name;
            Hand = hand;
            TotalScore = CalculateTotalScore();
            SuitScore = CalculateSuitScore();
        }

        private int CalculateTotalScore()
        {
            int total = 0;
            foreach (Card card in Hand)
            {
                total += card.Value;
            }
            return total;
        }

        private int CalculateSuitScore()
        {
            int product = 1;
            foreach (Card card in Hand)
            {
                product *= card.Suit;
            }
            return product;
        }

        private int Score()
        {
            int score = 0;
            foreach (Card card in Cards)
            {
                switch (card.Value)
                {
                    case "J":
                        score += 11;
                        break;
                    case "Q":
                        score += 12;
                        break;
                    case "K":
                        score += 13;
                        break;
                    case "A":
                        score += 11;
                        break;
                    default:
                        score += int.Parse(card.Value);
                        break;
                }
            }

            return score;
        }

    }

}
