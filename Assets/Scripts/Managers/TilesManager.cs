using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class TilesManager : MonoBehaviour
{
    public static TilesManager TileManagerInstance;
    [Header("Player Attributes")]
    public Transform _player;
    PlayerMovement _playerMovement;

    [Header("Tiles Generation Attributes")]
    public Transform _tilesParent;
    public GameObject[] _tilesPrefabs;
    public float _tileSpawnOffset;
    public float _tilesOnScreen;
    public float _zSpawnPosition;

    [Header("Pool Attributes")]
    private Queue<GameObject> _spawnTilesPool = new Queue<GameObject>();
    private Queue<GameObject> _moveSplinesPool = new Queue<GameObject>();
    public float _totalPoolSize;
    public List<GameObject> _activeTilesList = new List<GameObject>();
    public List<GameObject> _resetTilesList = new List<GameObject>();

    private void Awake()
    {
        if (TileManagerInstance == null)
        {
            TileManagerInstance = this;
        }
    }
    void Start()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
        StartGameT();
        GameManager.GameManagerInstance.OnGameReStarted += ResetGame;
        GameManager.GameManagerInstance.OnGameHomePage += ResetGame;
    }

    void Update()
    {
        PoolUpdate();
    }

    #region Pool Region
    void PoolUpdate()
    {
        if (_player.transform.position.z - (_tileSpawnOffset * _tilesOnScreen / 4) > _zSpawnPosition - _tilesOnScreen * _tileSpawnOffset)
        {
            SpawnTile();
            RecycleTile();
        }
    }
    public GameObject GetNextSplineTileToSpawn()
    {
        GameObject tile = _spawnTilesPool.Dequeue();
        tile.SetActive(true);
        _spawnTilesPool.Enqueue(tile);
        return tile;
    }
    void SpawnTile()
    {
        GameObject tile = GetNextSplineTileToSpawn();
        tile.transform.position = Vector3.forward * _zSpawnPosition;
        _activeTilesList.Add(tile);
        _zSpawnPosition += _tileSpawnOffset;
    }

    void RecycleTile()
    {
        GameObject oldTile = _activeTilesList[0];
        _activeTilesList.RemoveAt(0);
        oldTile.SetActive(false);
    }
    #endregion


    public GameObject GetNextSplineTileToMoveOn()
    {
        GameObject tile = _moveSplinesPool.Dequeue();
        tile.SetActive(true);
        _moveSplinesPool.Enqueue(tile);
        return tile;
    }
    void StartGameT()
    {
        for (int i = 0; i < _totalPoolSize; i++)
        {
            GameObject tile = Instantiate(_tilesPrefabs[i % _tilesPrefabs.Length], _tilesParent);
            tile.SetActive(false);
            _spawnTilesPool.Enqueue(tile);
            _moveSplinesPool.Enqueue(tile);
            _resetTilesList.Add(tile);
        }
        for (int i = 0; i < _tilesOnScreen; i++)
        {
            SpawnTile();
        }

        _playerMovement.AssignNextSpline();
    }


    public void ResetGame()
    {
        _zSpawnPosition = 0f;

        _player.position = Vector3.zero;

        foreach (GameObject tile in _activeTilesList)
        {
            tile.SetActive(false);
        }
        _activeTilesList.Clear();


        _spawnTilesPool.Clear();
        _moveSplinesPool.Clear();


        for (int i = 0; i < _totalPoolSize; i++)
        {
            GameObject tile = _resetTilesList[i % _tilesPrefabs.Length];
            tile.SetActive(false);

            _spawnTilesPool.Enqueue(tile);
            _moveSplinesPool.Enqueue(tile);
        }
        Debug.Log("Spawning");
        for (int i = 0; i < _tilesOnScreen; i++)
        {
            SpawnTile();
        }
        Debug.Log("Spawned");
        _playerMovement.AssignNextSpline();
    }
}