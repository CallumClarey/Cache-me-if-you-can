using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]private int width, height;
    [SerializeField] private GameObject tilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x + tilePrefab.transform.position.x, y + tilePrefab.transform.position.y), Quaternion.identity);
                spawnedTile.name = $" {x} {y}";
            }
        }
    }
}
