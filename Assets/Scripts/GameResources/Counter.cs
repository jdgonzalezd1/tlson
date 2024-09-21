using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI flowerCounter;

    [SerializeField]
    private TextMeshProUGUI seedCounter;

    [SerializeField]
    private TextMeshProUGUI waterCounter;

    private int flowers;

    private int seeds;

    private int water;

    public UnityEvent flowersWereUsed;

    public UnityEvent seedsWereUsed;

    public UnityEvent waterWasUsed;

    public static Counter Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void UpdateCount()
    {
        flowerCounter.text = flowers.ToString();
        seedCounter.text = seeds.ToString();
        waterCounter.text = water.ToString();
    }

    public void AddResource(ResourceType type, int quantity)
    {
        switch (type)
        {
            case ResourceType.Flowers:
                flowers += quantity;
                break;
            case ResourceType.Seeds:
                seeds += quantity;
                break;
            case ResourceType.Water:
                water += quantity;
                break;
        }
        UpdateCount();
    }

    public void UseResource(ResourceType type, int quantity)
    {
        switch (type)
        {
            case ResourceType.Flowers:
                if (quantity < flowers)
                {
                    print("Not enough flowers");
                }
                else
                {
                    flowersWereUsed.Invoke();
                }
                break;
            case ResourceType.Seeds:
                if (quantity < seeds)
                {
                    print("Not enough flowers");
                }
                else
                {
                    seedsWereUsed.Invoke();
                }
                break;
            case ResourceType.Water:
                if (quantity < water)
                {
                    print("Not enough flowers");
                }
                else
                {
                    waterWasUsed.Invoke();
                }
                break;
        }

    }

}
