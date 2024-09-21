using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringTotem : MonoBehaviour
{
    [SerializeField]
    private ResourceType resourceType;

    [SerializeField]
    private bool IsOnTheField = false, IsEnhanceable = true;

    [SerializeField]
    private Card card;
    
    [SerializeField]
    private int resourceAmount, gatheringTime, flowerCost, seedCost, waterCost;

    public int gatheringAmount;

    private void Start()
    {
        flowerCost = card.flowerCost / 2;
        seedCost = card.seedCost / 2;
        waterCost = card.waterCost / 2;
        IsOnTheField = true;
        StartCoroutine(GenerateResource());
    }

    public void EnhanceTotem()
    {
        if (IsEnhanceable)
        {
            gatheringTime -= 2;
            gatheringAmount += 5;
            IsEnhanceable = false;
        }
    }

    private void OnDestroy()
    {
        Counter.Instance.AddResource(ResourceType.Flowers, flowerCost);
        Counter.Instance.AddResource(ResourceType.Seeds, seedCost);
        Counter.Instance.AddResource(ResourceType.Water, waterCost);
    }


    private IEnumerator GenerateResource()
    {
        while (IsOnTheField)
        {
            yield return new WaitForSeconds(gatheringTime);
            Counter.Instance.AddResource(resourceType, gatheringAmount);
        }
    }
    
}

public enum ResourceType
{
    Flowers,
    Seeds,
    Water
}
