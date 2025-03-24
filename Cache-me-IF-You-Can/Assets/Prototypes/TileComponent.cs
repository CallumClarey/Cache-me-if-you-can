using UnityEngine;

public class TileComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject highlight;

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    void OnMouseExit()
    {
       highlight.SetActive(false);
    }
}
