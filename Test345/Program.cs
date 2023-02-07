using System;
using System.Collections.Generic;
using System.IO;

class Player
{
    public string Name { get; set; }
    public int TotalScore { get; set; }
    public int SuitScore { get; set; }
    public List<Card> Hand { get; set; }
    public int Score { get; internal set; }

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
}

class Card
{
    public int Value { get; set; }
    public int Suit { get; set; }

    public Card(int value, int suit)
    {
        Value = value;
        Suit = suit;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "";
        string outputFile = "";

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--in")
            {
                inputFile = args[i + 1];
            }
            else if (args[i] == "--out")
            {
                outputFile = args[i + 1];
            }
        }

        List<Player> players = ParseInput(inputFile);
        List<string> winners = FindWinners(players);
        WriteOutput(outputFile, winners);
    }

    private static List<Player> ParseInput(string inputFile)
    {
        List<Player> players = new List<Player>();
        try
        {
            using (StreamReader sr = new StreamReader(inputFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    string name = parts[0];
                    string[] cards = parts[1].Split(',');

                    List<Card> hand = new List<Card>();
                    foreach (string card in cards)
                    {
                        int value = GetValue(card[0]);
                        int suit = GetSuit(card[1]);
                        hand.Add(new Card(value, suit));
                    }

                    players.Add(new Player(name, hand));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error reading input file: " + e.Message);
        }
        return players;
    }

    private static int GetSuit(char v)
    {
        throw new NotImplementedException();
    }

    private static List<string> FindWinners(List<Player> players)
    {
        int maxScore = players.Max(player => player.Score);

        List<string> winners = players
            .Where(player => player.Score == maxScore)
            .Select(player => player.Name)
            .ToList();

        if (winners.Count == 1)
        {
            return winners;
        }
        else
        {
            int maxSuitScore = players
                .Where(player => player.Score == maxScore)
                .Max(player => player.SuitScore);

            return players
                .Where(player => player.Score == maxScore && player.SuitScore == maxSuitScore)
                .Select(player => player.Name)
                .ToList();
        }
    }

    private static void WriteOutput(string outputFile, List<string> winners)
    {
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string winner in winners)
            {
                writer.WriteLine(winner);
            }
        }
    }

    private static int GetValue(char face)
    {
        switch (face)
        {
            case 'J':
                return 11;
            case 'Q':
                return 12;
            case 'K':
                return 13;
            case 'A':
                return 11;
            default:
                return 0;
        }
    }
    private int GetSuit(string suite)
    {
        switch (suite)
        {
            case "hearts":
                return 1;
            case "diamonds":
                return 2;
            case "spades":
                return 3;
            case "clubs":
                return 4;
            default:
                return 0;
        }
    }

}



