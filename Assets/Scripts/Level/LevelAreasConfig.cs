using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Level Areas Config", fileName = "LevelAreasConfig")]
public class LevelAreasConfig : ScriptableObject
{
    [SerializeField]
    private List<LevelArea> _levelAreas = new List<LevelArea>();

    public LevelArea GetRandomArea()
    {
        return _levelAreas[UnityEngine.Random.Range(0, _levelAreas.Count)];
    }
    
    public LevelArea GetAreaWithMask(int mask)
    {
        var areasWithTargetMask = new List<LevelArea>();
        foreach (var area in _levelAreas)
        {
            if (area.GetMask() == mask)
            {
                areasWithTargetMask.Add(area);
            }
        }

        return areasWithTargetMask[UnityEngine.Random.Range(0, areasWithTargetMask.Count)];
    }
}
