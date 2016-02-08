using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDealer : MonoBehaviour {

	private List<string> cards;
	private string[] cardTypes = new string[]{"diamonds", "spades", "hearts", "clubs"};
	private string[] cardImages = new string[]{"2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace"};
    private Transform playerCards;
	private Transform communityCards;

	private GameResultCalculator resultCalculator;

	public GameObject cardPrefab;

	// Use this for initialization
	void Start ()
	{
		playerCards = GameObject.Find("Canvas/Panel/PlayerCards").transform;
		communityCards = GameObject.Find("Canvas/Panel/CommunityCards").transform;

        resultCalculator = new GameResultCalculator();

		cards = new List<string>();
		AddCards();
	}

	private void AddCards()
	{
		cards.Clear();

		for (int i = 0; i < cardTypes.Length; i++)
		{
			for (int k = 0; k < cardImages.Length; k++)
			{
				cards.Add(cardImages[k] + "_of_" + cardTypes[i]);
			}
		}
	}

	public void HandPlayerCards()
	{
		for (int i = 0; i < 2; i++)
		{
			int index = Random.Range(0, cards.Count);
			GameObject card = Instantiate(cardPrefab);
			card.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + cards[index]);
            card.transform.SetParent(playerCards);
            card.transform.localScale = new Vector3(1, 1, 1);
			resultCalculator.SetPlayerCard(i, new CardValue(cards[index]));
			cards.RemoveAt(index);
		}
	}

	public void HandCommunityCards()
	{
		for (int i = 0; i < 5; i++)
		{
			int index = Random.Range(0, cards.Count);
			GameObject card = Instantiate(cardPrefab);
			card.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + cards[index]);
            card.transform.SetParent(communityCards);
            card.transform.localScale = new Vector3(1, 1, 1);
            resultCalculator.SetCommunityCard(i, new CardValue(cards[index]));
			cards.RemoveAt(index);
		}
	}

	public void Reset()
	{
        for (int i = playerCards.childCount - 1; i >= 0;  i--) {
            DestroyImmediate(playerCards.transform.GetChild(i).gameObject);
        }

        for (int i = communityCards.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(communityCards.transform.GetChild(i).gameObject);
        }

        AddCards();
	}
}
