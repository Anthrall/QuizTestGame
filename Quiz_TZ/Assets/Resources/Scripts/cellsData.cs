using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellsData
{
    public TypeCell[] type;
}

[System.Serializable]
public class TypeCell
{
    public string name;
    public float scale_x, scale_y;
    public Database[] data; 
}

[System.Serializable]
public class Database
{
    public string letter;
    public Sprite sprite;
    public Color backgroundcolor;
}