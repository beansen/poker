using System.Collections.Generic;

public class GameResultCalculator
{

	private string[] cardTypes = new string[]{"diamonds", "spades", "hearts", "clubs"};

	private CardValue[] tempPlayerCards;
	private CardValue[] communityCards;

    public GameResultCalculator()
    {
        tempPlayerCards = new CardValue[2];
        communityCards = new CardValue[5];
    }

	public void SetPlayerCard(int index, CardValue cardValue)
	{
		tempPlayerCards[index] = cardValue;
	}

	public void SetCommunityCard(int index, CardValue cardValue)
	{
		communityCards[index] = cardValue;
	}

	public void CalculateResult()
	{
       
    }
}

/*
Pairs - When two players have a pair, the highest pair wins.   When both players have the same pair, the next highest card wins.   This card is called the 'Kicker'.   For example, 5-5-J-7-4 beats 5-5-9-8-7.
If the Pairs and the Kickers are the same, the consideration continues onward to the next highest card in the hand.   5-5-J-6-4 beats 5-5-J-5-3.   This evaluation process continues until both hands are exactly the same or there is a winner.

Two Pairs - the higher ranked pair wins.   A-A-7-7-3 beats K-K-J-J-9.   If the top pairs are equal, the second pair breaks the tie.   If both the top pair and the second pair are equal, the kicker (the next highest card) breaks the tie.
Three-of-a-Kind - the higher ranking card wins.   J-J-J-7-6 beats 10-10-10-8-7.
Straights - the Straight with the highest ranking card wins.   A-K-Q-J-10 beats 10-9-8-7-6, as the A beats the 10.   If both Straights contain cards of the same rank, the pot is split.
Flush - the Flush with the highest ranking card wins.   A-9-8-7-5 beats K-Q-J-5-4.   If the highest cards in each Flush are the same, the next highest cards are compared.   This process continues until either the hands are shown to be exactly the same, or there is a winner.
Full House - the hand with the higher ranking set of three cards wins.   K-K-K-4-4 beats J-J-J-A-A.
Four of a Kind - the higher ranked set of four cards wins.   7-7-7-7-2 beats 5-5-5-5-A.
Straight Flush - ties are broken in the same manner as a straight, as the highest ranking card is the winner.
Royal Flush - Sorry, Two or more Royal Flushes split the pot.
*/
