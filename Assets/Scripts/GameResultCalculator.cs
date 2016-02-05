using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultCalculator : MonoBehaviour
{

	private string[] cardTypes = new string[]{"diamonds", "spades", "hearts", "clubs"};
	private Dictionary<string, int> cardValues;

	private CardValue[] tempPlayerCards;
	private CardValue[] communityCards;

	void Start ()
	{
		cardValues = new Dictionary<string, int>();

		cardValues.Add("2", 2);
		cardValues.Add("3", 3);
		cardValues.Add("4", 4);
		cardValues.Add("5", 5);
		cardValues.Add("6", 6);
		cardValues.Add("7", 7);
		cardValues.Add("8", 8);
		cardValues.Add("9", 9);
		cardValues.Add("10", 10);
		cardValues.Add("jack", 11);
		cardValues.Add("queen", 12);
		cardValues.Add("king", 13);
		cardValues.Add("ace", 14);

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
		int[] result = GetValueResult(tempPlayerCards);

		if (HasStraight(tempPlayerCards))
		{
			Debug.Log("Straight");
		}

		if (HasFlush(tempPlayerCards))
		{
			Debug.Log("Flush");
		}

		if (result[0] == 5)
		{
			Debug.Log("Four of a kind");
		} else if (result[0] == 4)
		{
			Debug.Log("Full house");
		} else if (result[0] == 3)
		{
			Debug.Log("Three of a kind");
		} else if (result[0] == 2)
		{
			Debug.Log("Two pairs");
		} else if (result[0] == 1)
		{
			Debug.Log("One pair");
		} else
		{
			Debug.Log("Highest card");
		}
	}

	private bool HasFlush(CardValue[] playerCards)
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
			} else if (playerCards[i].GetCardType().Equals("clubs"))
			{
				clubsCount++;
			} else if (playerCards[i].GetCardType().Equals("hearts"))
			{
				heartsCount++;
			} else
			{
				diamondsCount++;
			}
		}

		for (int i = 0; i < communityCards.Length; i++)
		{
			if (communityCards[i].GetCardType().Equals("spades"))
			{
				spadesCount++;
			} else if (communityCards[i].GetCardType().Equals("clubs"))
			{
				clubsCount++;
			} else if (communityCards[i].GetCardType().Equals("hearts"))
			{
				heartsCount++;
			} else
			{
				diamondsCount++;
			}
		}

		return diamondsCount > 4 || heartsCount > 4 || clubsCount > 4 || spadesCount > 4;
	}

	private bool HasStraight(CardValue[] playerCards)
	{
		List<int> straight = new List<int>();

		for (int i = 0; i < playerCards.Length; i++)
		{
			int cardValue = cardValues[tempPlayerCards[i].GetValue()];

			straight.Add(cardValue);
		}

		for (int i = 0; i < communityCards.Length; i++)
		{
			int cardValue = cardValues[communityCards[i].GetValue()];

			straight.Add(cardValue);
		}

		straight.Sort();

		int consecutiveCards = 0;

		if (straight[0] == 2 && straight[straight.Count - 1] == 14)
		{
			consecutiveCards++;
		}

		for (int i = 0; i < straight.Count; i++)
		{
			if (i < straight.Count - 1)
			{
				if (straight[i] + 1 == straight[i + 1])
				{
					consecutiveCards++;

					if (consecutiveCards > 3)
					{
						return true;
					}
				} else
				{
					consecutiveCards = 0;
				}
			}
		}

		return false;
	}

	private int[] GetValueResult(CardValue[] playerCards)
	{
		int[] cardCount = new int[13];
		int highestCard = 0;

		for (int i = 0; i < playerCards.Length; i++)
		{
			int cardValue = cardValues[tempPlayerCards[i].GetValue()];
			if (cardValue > highestCard)
			{
				highestCard = cardValue;
			}
			cardCount[cardValue - 2]++;
		}

		for (int i = 0; i < communityCards.Length; i++)
		{
			int cardValue = cardValues[communityCards[i].GetValue()];
			if (cardValue > highestCard)
			{
				highestCard = cardValue;
			}
			cardCount[cardValue - 2]++;
		}

		int quadIndex = -1;
		List<int> tripleIndex = new List<int>();
		List<int> doubleIndex = new List<int>();

		tripleIndex.Sort();
		doubleIndex.Sort();

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

		if (quadIndex != -1)
		{
			return new int[]{5, quadIndex};
		}

		if (tripleIndex.Count > 0 && doubleIndex.Count > 0)
		{
			return new int[]{4, tripleIndex[tripleIndex.Count - 1], doubleIndex[doubleIndex.Count - 1]};
		}

		if (tripleIndex.Count > 0)
		{
			return new int[]{3, tripleIndex[tripleIndex.Count - 1]};
		}

		if (doubleIndex.Count > 1)
		{
			return new int[]{2, doubleIndex[doubleIndex.Count - 2], doubleIndex[doubleIndex.Count - 1]};
		}

		if (doubleIndex.Count == 1)
		{
			return new int[]{1, doubleIndex[0]};
		}

		return new int[]{0, highestCard};
	}
}
