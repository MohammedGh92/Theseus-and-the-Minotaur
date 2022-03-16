using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private TextAsset jsonFile;
    private LevelsData levelsData;
    [SerializeField]
    private tileItem[] grid;
    [SerializeField]
    private PlayerManager playerManager;
    [SerializeField]
    private RectTransform escapleSymbol;
    [SerializeField]
    private EnemyManager enemyManager;

    private void Start()
    {
        StartCoroutine(LoadLevelCor(LevelManager.GetcLevel()));
    }

    private IEnumerator LoadLevelCor(int levelNu)
    {
        //Set Grid
        levelsData = JsonUtility.FromJson<LevelsData>(jsonFile.text);
        LevelO clevel = levelsData.levels[levelNu];
        for (int i = 0; i < clevel.grid.Count; i++)
        {
            TileO cTile = clevel.grid[i];
            grid[cTile.pos].SetData(cTile);
        }
        yield return new WaitForEndOfFrame();
        //Set Escape Pos
        escapleSymbol.anchoredPosition = grid[clevel.escape_Pos].GetComponent<RectTransform>().localPosition;
        //Set Player Pos
        playerManager.SetData(grid, clevel, grid[clevel.theseus_Pos].GetComponent<RectTransform>().localPosition);
        //Set Enemy Pos
        enemyManager.SetData(grid, clevel, grid[clevel.minotaur_Pos].GetComponent<RectTransform>().localPosition);
    }
}