using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    #region display card info
    [SerializeField]
    private Card card;

    [SerializeField]
    private TextMeshProUGUI cardName;

    [SerializeField]
    private TextMeshProUGUI cardDescription;

    [SerializeField]
    private TextMeshProUGUI cardFlowerCost;

    [SerializeField]
    private TextMeshProUGUI cardSeedCost;

    [SerializeField]
    private TextMeshProUGUI cardWaterCost;

    [SerializeField]
    private Image cardSplashArt;
        
    void Start()
    {
        cardName.text = card.cardName;
        cardDescription.text = card.cardDescription;
        cardFlowerCost.text = card.flowerCost.ToString();
        cardSeedCost.text = card.seedCost.ToString();
        cardWaterCost.text = card.waterCost.ToString();

        cardSplashArt.sprite = card.splashArt;
    }

    #endregion

    /*
    public void Test()
    {
        print("Success");
    }
    */
}
