using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

public class ProceduralGeneratedLevel : MonoBehaviour
{
    private const int MAP_SIZE = 100;
    private const int MAP_CENTER = 50;

    [SerializeField]
    private LevelAreasConfig _areasConfig;

    [SerializeField]
    private NavMeshSurface _navMeshSurface;

    private AreaModel[,] _labirint;

    // Start is called before the first frame update
    void Start()
    {
        _labirint = new AreaModel[MAP_SIZE, MAP_SIZE];
        GenerateNext(MAP_CENTER, MAP_CENTER, 15);
        InstantiateAreas();
    }

    void GenerateNext(int x, int y, int remaining)
    {
        if (remaining <= 0)
        {
            return;
        }

        _labirint[x, y] = new AreaModel();
        if (remaining == 1)
        {
            _labirint[x, y].IsEndLevel = true;
        }
        var free = GetFreeNeighbours(x, y);
        if (free.Count == 0)
        {
            return;
        }
        var (nx, ny) = free[Random.Range(0, free.Count)];
        GenerateNext(nx, ny, remaining - 1);
        if (remaining % 5 == 0)
        {
            free = GetFreeNeighbours(x, y);
            if (free.Count == 0)
            {
                return;
            }
            (nx, ny) = free[Random.Range(0, free.Count)];
            GenerateNext(nx, ny, remaining - 1);
        }
    }

    List<(int, int)> GetFreeNeighbours(int x, int y)
    {
        var free = new List<(int, int)>();
        if (IsFreeSpace(x + 1, y)) free.Add((x + 1, y));
        if (IsFreeSpace(x, y + 1)) free.Add((x, y + 1));
        if (IsFreeSpace(x - 1, y)) free.Add((x - 1, y));
        if (IsFreeSpace(x, y - 1)) free.Add((x, y - 1));

        return free;
    }

    void InstantiateAreas()
    {
        for (int i = 1; i < MAP_SIZE - 1; i++)
        {
            for (int j = 1; j < MAP_SIZE - 1; j++)
            {
                if (!IsFreeSpace(i, j))
                {
                    SpawnArea(i, j);
                }
            }
        }
        _navMeshSurface.BuildNavMesh();
    }

    void SpawnArea(int x, int y)
    {
        LevelArea area = Instantiate(_areasConfig.GetRandomArea(), new Vector3((x - MAP_CENTER)*LevelArea.AREA_SIZE, -5, (y - MAP_CENTER)*LevelArea.AREA_SIZE), Quaternion.identity);
        
        if (_labirint[x,y].IsEndLevel)
        {
            // end level...
        }
        area.SetMask(!IsFreeSpace(x + 1, y), !IsFreeSpace(x - 1, y), !IsFreeSpace(x, y + 1), !IsFreeSpace(x, y - 1));
    }

    bool IsFreeSpace(int x, int y) => _labirint[x, y] is null;

    private class AreaModel
    {
        public bool IsEndLevel { get; set; }
    }
}
