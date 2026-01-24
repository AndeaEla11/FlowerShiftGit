using UnityEngine;
using UnityEngine.SceneManagement; 

public class BouquetSceneUI : MonoBehaviour
{
    public void DeliverBouquet()
    {
        GameState.bouquetDelivered = true;
        SceneManager.LoadScene("OrderScene");
    }
}
