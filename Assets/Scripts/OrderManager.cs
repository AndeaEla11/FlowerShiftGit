using UnityEngine;
using System.Collections.Generic;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Istance;

    [SerializeField] private List<OrderData> orders = new List<OrderData>();

    public OrderData CurrentOrder { get; private set; }

    private void Awake()
    {
        if (Istance != null && Istance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Istance = this;
        DontDestroyOnLoad(gameObject);

        if (orders.Count == 0)
        {
            orders.Add(new OrderData{requiredFlowers = 2});
            orders.Add(new OrderData{requiredFlowers = 3});
            orders.Add(new OrderData{requiredFlowers = 4});
        }
    }

    public void GenerateNewOrder()
    {
        int randomIndex = Random.Range(0, orders.Count);
        CurrentOrder = orders[randomIndex];
    }
}
