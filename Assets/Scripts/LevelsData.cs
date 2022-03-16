using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelsData
{
    public List<LevelO> levels;
    public LevelsData()
    {
        levels = new List<LevelO>();
    }
}

[Serializable]
public class LevelO
{
    public List<TileO> grid;
    public int theseus_Pos;
    public int minotaur_Pos;
    public int escape_Pos;
    public LevelO()
    {
        grid = new List<TileO>();
    }
}

[Serializable]
public class TileO
{
    public int pos;
    public int[] borders;

    public TileO()
    {
        borders = new int[4];
    }

    public int[] GetBorders()
    {
        return borders;
    }
}