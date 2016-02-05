using System.Collections;
using UnityEngine;

public class TestDeckCreator : MonoBehaviour
{

	public GameResultCalculator gameResultCalculator;
	public TestCard[] playerCards;
	public TestCard[] communityCards;

	public void CreateDeck()
	{
		for (int i = 0; i < playerCards.Length; i++)
		{
			gameResultCalculator.SetPlayerCard(i, new CardValue(GetValue(playerCards[i].value) + "_of_" + playerCards[i].type.ToString()));
		}

		for (int i = 0; i < communityCards.Length; i++)
		{
			gameResultCalculator.SetCommunityCard(i, new CardValue(GetValue(communityCards[i].value) + "_of_" + communityCards[i].type.ToString()));
		}
	}

	private string GetValue(TestCard.Values value)
	{
		if (value == TestCard.Values.two) {
			return "2";
		} else if (value == TestCard.Values.three) {
			return "3";
		} else if (value == TestCard.Values.four) {
			return "4";
		} else if (value == TestCard.Values.five) {
			return "5";
		} else if (value == TestCard.Values.six) {
			return "6";
		} else if (value == TestCard.Values.seven) {
			return "7";
		} else if (value == TestCard.Values.eight) {
			return "8";
		} else if (value == TestCard.Values.nine) {
			return "9";
		} else if (value == TestCard.Values.ten) {
			return "10";
		} else {
			return value.ToString();
		}
	}
}
