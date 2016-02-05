using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDealer : MonoBehaviour {

	private List<string> cards;
	private string[] cardTypes = new string[]{"diamonds", "spades", "hearts", "clubs"};
	private string[] cardImages = new string[]{"2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace"};
	private Transform[] playerSpots = new Transform[2];
	private Transform[] communitySpots = new Transform[5];

	public GameResultCalculator resultCalculator;

	public GameObject cardPrefab;

	// Use this for initialization
	void Start ()
	{
		playerSpots[0] = GameObject.Find("Canvas/Panel/PlayerCards/Spot_1").transform;
		playerSpots[1] = GameObject.Find("Canvas/Panel/PlayerCards/Spot_2").transform;

		communitySpots[0] = GameObject.Find("Canvas/Panel/CommunityCards/Spot_1").transform;
		communitySpots[1] = GameObject.Find("Canvas/Panel/CommunityCards/Spot_2").transform;
		communitySpots[2] = GameObject.Find("Canvas/Panel/CommunityCards/Spot_3").transform;
		communitySpots[3] = GameObject.Find("Canvas/Panel/CommunityCards/Spot_4").transform;
		communitySpots[4] = GameObject.Find("Canvas/Panel/CommunityCards/Spot_5").transform;

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
			RectTransform rectTransform = card.GetComponent<RectTransform>();
			rectTransform.SetParent(playerSpots[i]);
			rectTransform.offsetMin = new Vector2();
			rectTransform.offsetMax = new Vector2(1, 1);
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
			RectTransform rectTransform = card.GetComponent<RectTransform>();
			rectTransform.SetParent(communitySpots[i]);
			rectTransform.offsetMin = new Vector2();
			rectTransform.offsetMax = new Vector2(1, 1);
			resultCalculator.SetCommunityCard(i, new CardValue(cards[index]));
			cards.RemoveAt(index);
		}
	}

	public void Reset()
	{
		DestroyImmediate(playerSpots[0].GetChild(0).gameObject);
		DestroyImmediate(playerSpots[1].GetChild(0).gameObject);

		for (int i = 0; i < 5; i++)
		{
			DestroyImmediate(communitySpots[i].GetChild(0).gameObject);
		}

		AddCards();
	}
}
