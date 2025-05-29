using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LevelArea : MonoBehaviour
{
    public const int AREA_SIZE = 40;

    public List<Entrance> entrances = new List<Entrance>();
    public Transform eastWall;
    public Transform westWall;
    public Transform northWall;
    public Transform southWall;

    public int GetMask()
    {
        var mask = 0;
        foreach (var entrance in entrances)
        {
            mask = mask | (int)entrance;
        }
        return mask;
    }

    public void SetMask(bool _eastEntrance,
                        bool _westEntrance,
                        bool _northEntrance,
                        bool _southEntrance
                        )
    {
        this.eastWall.gameObject.SetActive(!_eastEntrance);
        this.westWall.gameObject.SetActive(!_westEntrance);
        this.northWall.gameObject.SetActive(!_northEntrance);
        this.southWall.gameObject.SetActive(!_southEntrance);

        this.entrances.Clear();
        if (_eastEntrance) this.entrances.Add(Entrance.East);
        if (_westEntrance) this.entrances.Add(Entrance.West);
        if (_northEntrance) this.entrances.Add(Entrance.North);
        if (_southEntrance) this.entrances.Add(Entrance.South);
    }

}


[Flags]
public enum Entrance
{
    West = 1,
    East = 2,
    South = 4,
    North = 8
}