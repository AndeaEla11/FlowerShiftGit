using UnityEngine;

public class FlowerPickup : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Camera worldCamera;
    [SerializeField] private LayerMask bouquetSurfaceMask;
    [SerializeField] private float yOffset = 0.02f;

    private GameObject dragged;
    private bool isDragging;

    void Awake()
    {
        if (worldCamera == null)
            worldCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (spawnPrefab == null || worldCamera == null) return;

        dragged = Instantiate(spawnPrefab);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging || dragged == null) return;

        Ray ray = worldCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, bouquetSurfaceMask))
        {
            float extra = yOffset;

            Collider col = dragged.GetComponentInChildren<Collider>();
            if (col != null)
            {
                extra += col.bounds.extents.y;
            }

            dragged.transform.position = hit.point + Vector3.up * extra;
        }
    }

    void OnMouseUp()
    {
        if (dragged == null) return;

        Ray ray = worldCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 100f, bouquetSurfaceMask))
        {
            Destroy(dragged);
        }

        dragged = null;
        isDragging = false;
    }

}
