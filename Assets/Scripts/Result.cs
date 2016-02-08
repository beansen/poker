using System.Collections.Generic;

public class Result {

    private int index;
    private int highestCard;
    private int secondHighestCard;

    private CardValue[] playerCards;

    public Result(int index, int highestCard)
    {
        this.index = index;
        this.highestCard = highestCard;
    }

    public Result(CardValue[] playerCards, CardValue[] communityCards)
    {

    }

    public void SetSecondHighestCard(int index)
    {
        this.secondHighestCard = index;
    }

    private int[] CheckForFlush(CardValue[] playerCards)
    {
        int diamondsCount = 0;
        int spadesCount = 0;
        int clubsCount = 0;
        int heartsCount = 0;

        for (int i = 0; i < playerCards.Length; i++)
        {
            if (playerCards[i].GetCardType().Equals("spades"))
            {
                spadesCount++;
            }
            else if (playerCards[i].GetCardType().Equals("clubs"))
            {
                clubsCount++;
            }
            else if (playerCards[i].GetCardType().Equals("hearts"))
            {
                heartsCount++;
            }
            else
            {
                diamondsCount++;
            }
        }

        for (int i = 0; i < communityCards.Length; i++)
        {
            if (communityCards[i].GetCardType().Equals("spades"))
            {
                spadesCount++;
            }
            else if (communityCards[i].GetCardType().Equals("clubs"))
            {
                clubsCount++;
            }
            else if (communityCards[i].GetCardType().Equals("hearts"))
            {
                heartsCount++;
            }
            else
            {
                diamondsCount++;
            }
        }

        int[] flush = new int[4];

        flush[0] = diamondsCount > 4 ? 1 : 0;
        flush[1] = spadesCount > 4 ? 1 : 0;
        flush[2] = heartsCount > 4 ? 1 : 0;
        flush[3] = clubsCount > 4 ? 1 : 0;

        return flush;
    }

    private List<CardValue> CheckForStraight(CardValue[] playerCards)
    {
        List<CardValue> tempCardValues = new List<CardValue>();
        tempCardValues.AddRange(playerCards);
        tempCardValues.AddRange(communityCards);

        tempCardValues.Sort((p1, p2) => p1.GetIntegerValue().CompareTo(p2.GetIntegerValue()));

        List<CardValue> consecutiveCards = new List<CardValue>();

        int start = 0;
        int endOffset = 0;

        if (tempCardValues[0].GetIntegerValue() == 2 && tempCardValues[tempCardValues.Count - 1].GetIntegerValue() == 14)
        {
            consecutiveCards.Add(tempCardValues[tempCardValues.Count - 1]);
            consecutiveCards.Add(tempCardValues[0]);
            start = 1;
            endOffset = 1;
        }

        for (int i = start; i < tempCardValues.Count - endOffset; i++)
        {
            if (consecutiveCards.Count == 0)
            {
                consecutiveCards.Add(tempCardValues[i]);
            }
            else
            {
                if (tempCardValues[i].GetIntegerValue() == consecutiveCards[consecutiveCards.Count - 1].GetIntegerValue() + 1)
                {
                    consecutiveCards.Add(tempCardValues[i]);
                }
                else
                {
                    if (consecutiveCards.Count > 4)
                    {
                        break;
                    }
                    else
                    {
                        consecutiveCards.Clear();
                    }
                }
            }
        }

        return consecutiveCards;
    }

    private int[] GetValueResult(CardValue[] playerCards)
    {
        int[] cardCount = new int[13];
        int highestCard = 0;

        for (int i = 0; i < playerCards.Length; i++)
        {
            int cardValue = playerCards[i].GetIntegerValue();
            if (cardValue > highestCard)
            {
                highestCard = cardValue;
            }
            cardCount[cardValue - 2]++;
        }

        for (int i = 0; i < communityCards.Length; i++)
        {
            int cardValue = communityCards[i].GetIntegerValue();
            if (cardValue > highestCard)
            {
                highestCard = cardValue;
            }
            cardCount[cardValue - 2]++;
        }

        int quadIndex = -1;
        List<int> tripleIndex = new List<int>();
        List<int> doubleIndex = new List<int>();

        for (int i = 0; i < cardCount.Length; i++)
        {
            if (cardCount[i] == 4)
            {
                quadIndex = i;
            }

            if (cardCount[i] == 3)
            {
                tripleIndex.Add(i);
            }

            if (cardCount[i] == 2)
            {
                doubleIndex.Add(i);
            }
        }

        tripleIndex.Sort();
        doubleIndex.Sort();

        if (quadIndex != -1)
        {
            return new int[] { 5, quadIndex };
        }

        if (tripleIndex.Count > 0 && doubleIndex.Count > 0)
        {
            return new int[] { 4, tripleIndex[tripleIndex.Count - 1], doubleIndex[doubleIndex.Count - 1] };
        }

        if (tripleIndex.Count > 0)
        {
            return new int[] { 3, highestCard, tripleIndex[tripleIndex.Count - 1] };
        }

        if (doubleIndex.Count > 1)
        {
            return new int[] { 2, highestCard, doubleIndex[doubleIndex.Count - 2], doubleIndex[doubleIndex.Count - 1] };
        }

        if (doubleIndex.Count == 1)
        {
            return new int[] { 1, highestCard, doubleIndex[0] };
        }

        return new int[] { 0, highestCard };
    }

    private int FlushIndex(int[] flush)
    {
        for (int i = 0; i < flush.Length; i++)
        {
            if (flush[i] == 1)
            {
                return i;
            }
        }

        return -1;
    }
}

public enum PlayerResult
{
    HighestCard,
    Pair,
    TwoPairs,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
    RoyalFlush
}
