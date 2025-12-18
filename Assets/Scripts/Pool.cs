using UnityEngine;

public class Pool : MonoBehaviour
{
    private const int poolSize = 5;
    private const float spawnXPosition = 25f; // 25 units to the right in front of the camera
    // Tree 
    private GameObject[] trees; // Hold all reusable trees
    private Vector2 startPoolPosition = new Vector2(-15, -25); // Hidden position
    private const float treeSpawnRate = 3f; // When should we add the next tree
    private const float treeMin = -10f;
    private const float treeMax = -7f;
    private float treeTimeSinceLastSpawned; // How many time has passed since last tree
    private int currentTree = 0;
    public GameObject treePrefab; 


    // Coin
    private GameObject[] coins; // Hold all reusable coins
    private const float coinSpawnRate = 1f;
    private float coinTimeSinceLastSpawned; // How many time has passed since last coin
    private int currentCoin = 0;
    public GameObject coinPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trees = new GameObject[poolSize];
        coins = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            trees[i] = (GameObject)Instantiate(treePrefab, startPoolPosition, Quaternion.identity);
            coins[i] = (GameObject)Instantiate(coinPrefab, startPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // When ever player wait we will wait too
        if (!Input.GetKey(KeyCode.RightArrow))
            return;

        treeTimeSinceLastSpawned += Time.deltaTime;
        coinTimeSinceLastSpawned += Time.deltaTime;

        if (!GameController.instance.gameOver)
        {
            if(treeTimeSinceLastSpawned >= treeSpawnRate)
            {
                coinTimeSinceLastSpawned = 0;
                GenerateTree();
            }
            else if(coinTimeSinceLastSpawned >= coinSpawnRate)
                GenerateCoin();
        }
    }


    void GenerateTree()
    {        
        treeTimeSinceLastSpawned = 0;
        float spawnYPosition = Random.Range(treeMin, treeMax);
        trees[currentTree].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentTree++;
        
        if (currentTree == poolSize)
            currentTree = 0;
        
    }

    void GenerateCoin()
    {        
        coinTimeSinceLastSpawned = 0;
        coins[currentCoin].transform.position = new Vector2(spawnXPosition, -5);
        currentCoin++;
        
        if (currentCoin == poolSize)
            currentCoin = 0;
    }
   
}
