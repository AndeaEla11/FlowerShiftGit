using UnityEngine;

public class OrderValidator
{
    public static void ValidateOrder(OrderData order, BouquetBuilder bouquet)
    {
        int placedFlowerCount = bouquet.GetCount();
        int requiredFlowerCount = order.requiredFlowers;

        bool pass = placedFlowerCount == requiredFlowerCount;

        GameState.placed = placedFlowerCount;
        GameState.required = requiredFlowerCount;
        GameState.isCorrect = pass;

        Debug.Log("Placed Flowers: " + placedFlowerCount + " Required: " + requiredFlowerCount); 
    }
}
