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

        GameState.bouquetAccepted = builder.placedFlowers.Count >= 3;
        GameState.bouquetDelivered = true;
        SceneManager.LoadScene("OrderScene");
    }
}
