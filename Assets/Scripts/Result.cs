using System.Collections.Generic;
using UnityEngine;

public class Result
{

	private int resultIndex = -1;
	private CardValue communityKicker;
	private CardValue playerKicker;
	private CardValue[] playerHand;

	public int ResultIndex {
		get {
			return resultIndex;
		}
	}

	public CardValue CommunityKicker {
		get {
			return communityKicker;
		}
	}

	public CardValue PlayerKicker {
		get {
			return playerKicker;
		}
	}

	public CardValue[] PlayerHand {
		get {
			return playerHand;
		}
	}

	private List<CardValue> cards;

	public Result(CardValue[] playerCards, CardValue[] communityCards)
	{
		playerKicker = playerCards[0].GetIntegerValue() > playerCards[1].GetIntegerValue() ? playerCards[0] : playerCards[1];

		communityKicker = communityCards[0];

		for (int i = 1; i < communityCards.Length; i++)
		{
			if (communityCards[i].GetIntegerValue() > communityKicker.GetIntegerValue())
			{
				communityKicker = communityCards[i];
			}
		}

		cards = new List<CardValue>();
		cards.AddRange(playerCards);
		cards.AddRange(communityCards);

		cards.Sort((p1, p2) => p1.GetIntegerValue().CompareTo(p2.GetIntegerValue()));
	}

	public void CalculateResult()
	{
		List<CardValue> straight = GetStraight();

		if (straight.Count > 4)
		{
			CheckForHighFlush(straight);
		}

		if (resultIndex == -1)
		{
			playerHand = GetCardValueResult();

			if (resultIndex < 6)
			{
				CardValue flush = GetFlush();

				if (flush != null)
				{
					resultIndex = (int) PlayerResult.Flush;
					playerHand = new CardValue[] {flush};
				} else if (straight.Count > 4)
				{
					resultIndex = (int) PlayerResult.Straight;
					playerHand = new CardValue[] {straight[straight.Count - 1]};
				}
			}
		} else
		{
			playerHand = new CardValue[]{straight[straight.Count - 1]};
		}
	}

	private void CheckForHighFlush(List<CardValue> straight)
	{
		string type = straight[straight.Count - 1].GetCardType();
		bool isHighFlush = true;

		for (int i = straight.Count - 1; i >= 0; i--)
		{
			if (!straight[i].GetCardType().Equals(type))
			{
				isHighFlush = false;
				break;
			}
		}

		if (straight[straight.Count - 1].GetIntegerValue() == 14)
		{
			if (isHighFlush)
			{
				resultIndex = (int) PlayerResult.RoyalFlush;
			}
		} else
		{
			if (isHighFlush)
			{
				resultIndex = (int) PlayerResult.StraightFlush;
			}
		}
	}

	private CardValue GetFlush()
	{
		int diamondsCount = 0;
		int spadesCount = 0;
		int clubsCount = 0;
		int heartsCount = 0;

		CardValue spadesKicker = null;
		CardValue clubsKicker = null;
		CardValue heartsKicker = null;
		CardValue diamondsKicker = null;

		for (int i = 0; i < cards.Count; i++)
		{
			if (cards[i].GetCardType().Equals("spades"))
			{
				if (spadesKicker == null)
				{
					spadesKicker = cards[i];
				} else if (spadesKicker.GetIntegerValue() < cards[i].GetIntegerValue())
				{
					spadesKicker = cards[i];
				}

				spadesCount++;
			}
			else if (cards[i].GetCardType().Equals("clubs"))
			{
				if (clubsKicker == null)
				{
					clubsKicker = cards[i];
				} else if (clubsKicker.GetIntegerValue() < cards[i].GetIntegerValue())
				{
					clubsKicker = cards[i];
				}

				clubsCount++;
			}
			else if (cards[i].GetCardType().Equals("hearts"))
			{
				if (heartsKicker == null)
				{
					heartsKicker = cards[i];
				} else if (heartsKicker.GetIntegerValue() < cards[i].GetIntegerValue())
				{
					heartsKicker = cards[i];
				}

				heartsCount++;
			}
			else
			{
				if (diamondsKicker == null)
				{
					diamondsKicker = cards[i];
				} else if (diamondsKicker.GetIntegerValue() < cards[i].GetIntegerValue())
				{
					diamondsKicker = cards[i];
				}

				diamondsCount++;
			}
		}

		CardValue flushCard = null;

		if (spadesCount > 4)
		{
			flushCard = spadesKicker;
		} else if (clubsCount > 4)
		{
			flushCard = clubsKicker;
		} else if (heartsCount > 4)
		{
			flushCard = heartsKicker;
		} else if (diamondsCount > 4)
		{
			flushCard = diamondsKicker;
		}

		return flushCard;
	}

	private List<CardValue> GetStraight()
	{
		List<CardValue> consecutiveCards = new List<CardValue>();

		int start = 0;

		if (cards[0].GetIntegerValue() == 2 && cards[cards.Count - 1].GetIntegerValue() == 14)
		{
			consecutiveCards.Add(cards[cards.Count - 1]);
			consecutiveCards.Add(cards[0]);
			start = 1;
		}

		for (int i = start; i < cards.Count; i++)
		{
			if (consecutiveCards.Count == 0)
			{
				consecutiveCards.Add(cards[i]);
			}
			else
			{
				if (cards[i].GetIntegerValue() == consecutiveCards[consecutiveCards.Count - 1].GetIntegerValue() + 1)
				{
					consecutiveCards.Add(cards[i]);
				}
				else if (cards[i].GetIntegerValue() != consecutiveCards[consecutiveCards.Count - 1].GetIntegerValue())
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

	private CardValue[] GetCardValueResult()
	{
		List<CardValue> tempCards = new List<CardValue>();
		tempCards.AddRange(cards);

		for (int i = 0; i < cards.Count; i++)
		{
			tempCards.Remove(cards[i]);

			for (int k = tempCards.Count - 1; k >= 0; k--)
			{
				if (cards[i].GetIntegerValue() == tempCards[k].GetIntegerValue())
				{
					cards[i].IncreaseCount();
					tempCards.RemoveAt(k);
				}
			}
		}

		List<CardValue> threeOfAKind = new List<CardValue>();
		List<CardValue> pair = new List<CardValue>();

		for (int i = 0; i < cards.Count; i++)
		{
			if (cards[i].GetCount() == 4)
			{
				resultIndex = (int) PlayerResult.FourOfAKind;

				return new CardValue[]{cards[i]};
			} else if (cards[i].GetCount() == 3)
			{
				threeOfAKind.Add(cards[i]);
			} else if (cards[i].GetCount() == 2)
			{
				pair.Add(cards[i]);
			}
		}

		threeOfAKind.Sort((p1, p2) => p1.GetIntegerValue().CompareTo(p2.GetIntegerValue()));
		pair.Sort((p1, p2) => p1.GetIntegerValue().CompareTo(p2.GetIntegerValue()));

		CardValue[] result = new CardValue[0];

		if (threeOfAKind.Count > 0 && pair.Count > 0)
		{
			resultIndex = (int) PlayerResult.FullHouse;

			result = new CardValue[]{threeOfAKind[threeOfAKind.Count - 1], pair[pair.Count - 1]};
		} else if (threeOfAKind.Count > 0)
		{
			resultIndex = (int) PlayerResult.FullHouse;

			result = new CardValue[]{threeOfAKind[threeOfAKind.Count - 1]};
		} else if (pair.Count > 0)
		{
			if (pair.Count > 1)
			{
				resultIndex = (int) PlayerResult.TwoPairs;

				result = new CardValue[]{pair[pair.Count - 1], pair[pair.Count - 2]};
			} else
			{
				resultIndex = (int) PlayerResult.Pair;

				result = new CardValue[]{pair[0]};
			}
		} else
		{
			resultIndex = (int) PlayerResult.HighestCard;
		}

		return result;
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
