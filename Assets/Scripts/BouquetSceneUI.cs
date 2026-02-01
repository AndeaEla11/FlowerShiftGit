using UnityEngine;
using UnityEngine.SceneManagement; 

public class BouquetSceneUI : MonoBehaviour
{

    public void DeliverBouquet()
    {
        BouquetBuilder builder = FindFirstObjectByType<BouquetBuilder>();
        if (builder == null || builder.placedFlowers.Count == 0)
        {
            Debug.Log("No flowers placed. Can't deliver.");
            return;
        }

        if (OrderManager.Istance == null || OrderManager.Istance.CurrentOrder == null)
        {
            Debug.LogError("Missing OrderManager or CurrentOrder. Cannot Validare.");
            return;
        }

        OrderValidator.ValidateOrder(OrderManager.Istance.CurrentOrder, builder);

        GameState.bouquetDelivered = true;
        SceneManager.LoadScene("OrderScene");
    }
}
