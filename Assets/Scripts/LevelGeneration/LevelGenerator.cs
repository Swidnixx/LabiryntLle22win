using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D texture;
    public ColorMapping[] mappings;

    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        for(int x=0; x < texture.width; x++)
        {
            for(int y=0; y < texture.height; y++)
            {
                Color pixel = texture.GetPixel(x, y);
                SpawnFragment(x, y, pixel);
            }
        }
    }

    private void SpawnFragment(int x, int y, Color pixel)
    {
        Vector3 position = new Vector3(x, 0, y);
        foreach( ColorMapping m in mappings )
        {
            if( m.color == pixel )
            {
                Instantiate(m.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
