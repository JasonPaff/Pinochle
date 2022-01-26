using Nez;
using Pinochle.Enums;
using Pinochle.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pinochle.Helpers
{
    public static class BidHelper
    {
        private const byte MarriagePointValue = 20;
        private const byte PinochlePointValue = 40;
        private const byte RoyalMarriagePointValue = 40;
        private const byte FortyJacksPointValue = 40;
        private const byte SixtyQueensPointValue = 60;
        private const byte EightyKingsPointValue = 80;
        private const byte HundredAcesPointValue = 100;
        private const byte RunPointValue = 150;
        private const short DoublePinochlePointValue = 300;
        private const short FourHundredJacksPointValue = 400;
        private const short SixHundredQueensPointValue = 600;
        private const short EightHundredKingsPointValue = 800;
        private const short OneThousandAcesPointValue = 1000;
        private const short DoubleRunPointValue = 1500;

        private static int GetHandValue(List<Card> cards, Suit trump)
        {
            var handValue = 0;

            handValue += GetPinochlePoints(cards);
            handValue += GetMarriagePoints(cards, trump);
            handValue += GetRoyalMarriagePoints(cards, trump);
            handValue += GetJacksPoints(cards);
            handValue += GetQueensPoints(cards);
            handValue += GetKingsPoints(cards);
            handValue += GetAcesPoints(cards);
            handValue += GetRunPoints(cards, trump);

            return handValue;
        }
        private static int GetRunPoints(List<Card> cards, Suit trump)
        {
            var tenCount = cards.Count(i => i.Rank == Rank.Ten && i.Suit == trump);
            var aceCount = cards.Count(i => i.Rank == Rank.Ace && i.Suit == trump);
            var kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == trump);
            var queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == trump);
            var jackCount = cards.Count(i => i.Rank == Rank.Jack && i.Suit == trump);

            var a = Math.Min(tenCount, aceCount);
            var b = Math.Min(kingCount, queenCount);
            var c = Math.Min(a, jackCount);
            var runCount = Math.Min(b, c);

            return runCount switch
            {
                0 => 0,
                1 => RunPointValue,
                _ => DoubleRunPointValue
            };
        }
        private static int GetPinochlePoints(List<Card> cards)
        {
            var queenOfSpadesCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Spade);
            var jackOfDiamondsCount = cards.Count(i => i.Rank == Rank.Jack && i.Suit == Suit.Diamond);
            var pinochleCount = Math.Min(queenOfSpadesCount, jackOfDiamondsCount);

            return pinochleCount switch
            {
                0 => 0,
                1 => PinochlePointValue,
                _ => DoublePinochlePointValue
            };
        }
        private static int GetMarriagePoints(List<Card> cards, Suit trump)
        {
            var marriagePoints = 0;

            var queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Spade);
            var kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Spade);
            var numberOfMarriages = Math.Min(queenCount, kingCount);
            if (trump != Suit.Spade) marriagePoints += numberOfMarriages * MarriagePointValue;

            queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Club);
            kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Club);
            numberOfMarriages = Math.Min(queenCount, kingCount);
            if (trump != Suit.Club) marriagePoints += numberOfMarriages * MarriagePointValue;

            queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Heart);
            kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Heart);
            numberOfMarriages = Math.Min(queenCount, kingCount);
            if (trump != Suit.Heart) marriagePoints += numberOfMarriages * MarriagePointValue;

            queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Diamond);
            kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Diamond);
            numberOfMarriages = Math.Min(queenCount, kingCount);
            if (trump != Suit.Diamond) marriagePoints += numberOfMarriages * MarriagePointValue;

            return marriagePoints;
        }
        private static int GetRoyalMarriagePoints(List<Card> cards, Suit trump)
        {
            var royalMarriagePoints = 0;

            var queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Spade);
            var kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Spade);
            var numberOfRoyalMarriages = Math.Min(queenCount, kingCount);
            if (trump == Suit.Spade) royalMarriagePoints += numberOfRoyalMarriages * RoyalMarriagePointValue;

            queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Club);
            kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Club);
            numberOfRoyalMarriages = Math.Min(queenCount, kingCount);
            if (trump == Suit.Club) royalMarriagePoints += numberOfRoyalMarriages * RoyalMarriagePointValue;

            queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Heart);
            kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Heart);
            numberOfRoyalMarriages = Math.Min(queenCount, kingCount);
            if (trump == Suit.Heart) royalMarriagePoints += numberOfRoyalMarriages * RoyalMarriagePointValue;

            queenCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Diamond);
            kingCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Diamond);
            numberOfRoyalMarriages = Math.Min(queenCount, kingCount);
            if (trump == Suit.Diamond) royalMarriagePoints += numberOfRoyalMarriages * RoyalMarriagePointValue;

            return royalMarriagePoints;
        }
        private static int GetJacksPoints(List<Card> cards)
        {
            var spadesCount = cards.Count(i => i.Rank == Rank.Jack && i.Suit == Suit.Spade);
            var clubsCount = cards.Count(i => i.Rank == Rank.Jack && i.Suit == Suit.Club);
            var heartsCount = cards.Count(i => i.Rank == Rank.Jack && i.Suit == Suit.Heart);
            var diamondsCount = cards.Count(i => i.Rank == Rank.Jack && i.Suit == Suit.Diamond);

            var a = Math.Min(spadesCount, clubsCount);
            var b = Math.Min(heartsCount, diamondsCount);
            var jacksCount = Math.Min(a, b);

            return jacksCount switch
            {
                0 => 0,
                1 => FortyJacksPointValue,
                _ => FourHundredJacksPointValue
            };
        }
        private static int GetQueensPoints(List<Card> cards)
        {
            var spadesCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Spade);
            var clubsCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Club);
            var heartsCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Heart);
            var diamondsCount = cards.Count(i => i.Rank == Rank.Queen && i.Suit == Suit.Diamond);

            var a = Math.Min(spadesCount, clubsCount);
            var b = Math.Min(heartsCount, diamondsCount);
            var queensCount = Math.Min(a, b);

            return queensCount switch
            {
                0 => 0,
                1 => SixtyQueensPointValue,
                _ => SixHundredQueensPointValue
            };
        }
        private static int GetKingsPoints(List<Card> cards)
        {
            var spadesCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Spade);
            var clubsCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Club);
            var heartsCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Heart);
            var diamondsCount = cards.Count(i => i.Rank == Rank.King && i.Suit == Suit.Diamond);

            var a = Math.Min(spadesCount, clubsCount);
            var b = Math.Min(heartsCount, diamondsCount);
            var kingsCount = Math.Min(a, b);

            return kingsCount switch
            {
                0 => 0,
                1 => EightyKingsPointValue,
                _ => EightHundredKingsPointValue
            };
        }
        private static int GetAcesPoints(List<Card> cards)
        {
            var spadesCount = cards.Count(i => i.Rank == Rank.Ace && i.Suit == Suit.Spade);
            var clubsCount = cards.Count(i => i.Rank == Rank.Ace && i.Suit == Suit.Club);
            var heartsCount = cards.Count(i => i.Rank == Rank.Ace && i.Suit == Suit.Heart);
            var diamondsCount = cards.Count(i => i.Rank == Rank.Ace && i.Suit == Suit.Diamond);

            var a = Math.Min(spadesCount, clubsCount);
            var b = Math.Min(heartsCount, diamondsCount);
            var acesCount = Math.Min(a, b);

            return acesCount switch
            {
                0 => 0,
                1 => HundredAcesPointValue,
                _ => OneThousandAcesPointValue
            };
        }
        public static void LogHandValue(List<Card> cards, Suit trump)
        {
            Debug.Log($"total hand value: {GetHandValue(cards, trump)} points ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"pinochle points: {GetPinochlePoints(cards)} ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"marriage points(club trump): {GetMarriagePoints(cards, trump)} ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"royal marriage points(club trump): {GetRoyalMarriagePoints(cards, trump)} ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"forty jacks points: {GetJacksPoints(cards)} ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"sixty queens points: {GetQueensPoints(cards)} ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"eighty kings points: {GetKingsPoints(cards)} ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"hundred aces points: {GetAcesPoints(cards)} ({DateTime.Now.ToLongTimeString()})");
            Debug.Log($"run points: {GetRunPoints(cards, trump)} ({DateTime.Now.ToLongTimeString()})");
        }
    }
}
