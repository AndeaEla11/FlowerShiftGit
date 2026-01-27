using System.Collections.Generic;
using UnityEngine;

public class BouquetBuilder : MonoBehaviour
{
    public List<GameObject> placedFlowers = new List<GameObject>();

    public static int placeFlowers = 0;
     
    public void RegisterFlower(GameObject flower)
    {
        placedFlowers.Add(flower);
        flower.transform.SetParent(transform); // keep bouquet organised
        Debug.Log("Flowers placed: " + placedFlowers.Count);
    }
    public int GetFlowerCount()
    {
        return placedFlowers.Count;
    }

    public void ClearBouquet()
    {
        placedFlowers.Clear();
    }
}
