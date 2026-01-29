using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class OrderUI : MonoBehaviour
{
    [SerializeField] private GameObject orderPanel;
    [SerializeField] private TMP_Text orderText;

    private void Awake()
    {
        orderPanel.SetActive(false);
    }

    public void ShowOrder(int requiredFlowers)
    {
        orderText.text = "I'd like " + requiredFlowers + " flowers, please!";
        orderPanel.SetActive(true);
    }

    public void HideOrder()
    {
        orderPanel.SetActive(false);
    }

    public void StartBuilding()
    {
        HideOrder();
        SceneManager.LoadScene("BouquetArrangementScene");
    }
}
