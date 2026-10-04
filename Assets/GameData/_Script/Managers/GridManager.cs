using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [Header("Settings")]
    [SerializeField] private int width;
    [SerializeField] private int height;

    [Header("Components")]
    [SerializeField] private Transform cam;
    [SerializeField] private Transform gridHolder;
    [SerializeField] private Tile grassTile, mountainTile;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var random = Random.Range(0, 12);
                var randomTile = random == 2 || random == 7 ? mountainTile : grassTile; 

                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity,gridHolder);
                spawnedTile.name = $"Tile {x} {y}";
                
                spawnedTile.Initialize(x,y);
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - .5f, (float)height / 2 - .5f,-10f);

        GameManager.Instance.ChangeState(GameState.SpawnPlayer);
    }
}
