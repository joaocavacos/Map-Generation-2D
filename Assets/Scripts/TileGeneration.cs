using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileGeneration : MonoBehaviour
{

    //Based on Conways Game of Life

    [Range(0, 100)]
    public int initialChance; //Chance for the tile to be "alive"

    [Range(1, 8)]
    public int activeLimit; //If the tile is "alive"

    [Range(1, 8)]
    public int disableLimit; //If the tile is "dead"

    [Range(1, 10)]
    public int nSimulation; //Number of repetitions the program runs

    private int[,] terrainMap; //Tile map array
    public Vector3Int tilemapSize;


    Tilemap topMap;
    Tilemap bottomMap;
    Tile topTile;
    Tile bottomTile;

    int w, h;

    void Simulation(int repetitions)
	{
        clearTileMap(false);

        w = tilemapSize.x;
        h = tilemapSize.y;

        if(terrainMap == null) //If there isn't a tile map create one
		{
            terrainMap = new int[w, h];
		}

		for (int i = 0; i < repetitions; i++)
		{
            terrainMap = generateTilePosition(terrainMap);
		}

		for (int x = 0; x < w; x++)
		{
			for (int y = 0; y < h; y++)
			{

			}
		}
	}

    public int[,] generateTilePosition(int[,] oldMap)
	{
        int[,] newMap = new int[w, h];
        int neighbourTile;
        BoundsInt bounds = new BoundsInt(-1,-1,0,3,3,1); //Border of the map

		for (int x = 0; x < w; x++)
		{
			for (int y = 0; y < h; y++)
			{
                neighbourTile = 0;

				foreach (var bound in bounds.allPositionsWithin)
				{
                    if (bound.x == 0 && bound.y == 0) continue; //Exclude x=0 and y=0 because it's current position (not a neighbour tile)
                    if(x+bound.x >= 0 && x+bound.x < w && y+bound.y >= 0 && y+bound.y < h) //Exclude values outside the map
					{
                        neighbourTile += oldMap[x + bound.x, y + bound.x];
					}
					else
					{
                        neighbourTile++;
					}
				}

                if (oldMap[x, y] == 1) //1= dead tile, 0= alive tile
                {
                    if(neighbourTile < disableLimit)
					{
                        newMap[x, y] = 0;
					}
					else
					{
                        newMap[x, y] = 1;
                    }
                }

                if (oldMap[x, y] == 0) //1= dead tile, 0= alive tile
                {
                    if (neighbourTile > activeLimit)
                    {
                        newMap[x, y] = 1;
					}
					else
					{
                        newMap[x, y] = 0;
                    }
                }
            }
            

        }


        return newMap;
	}

    void initialPos()
	{
		for (int x = 0; x < w; x++)
		{
			for (int y = 0; y < h; y++)
			{
                terrainMap[x, y] = Random.Range(1, 101) < initialChance ? 1 : 0; //Define the tile map position in random coords, if the tile is alive = 1, if dead = 0
			}
		}
	}

    void clearTileMap(bool isComplete)
	{
		if (isComplete)
		{
            terrainMap = null;
		}
	}

    void ClearAllTiles()
	{

	}

    void Update()
    {
        
    }

}
