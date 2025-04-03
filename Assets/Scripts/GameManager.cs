using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    
    // Logic
    public int pesos;
    public int experience;


    // Save state
    public void SaveState()
    {
        string s = "";

        s += "0" + "|"; // TEMP
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0"; // TEMP

        PlayerPrefs.SetString("SaveState", s);
        //Debug.Log("SaveState");
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState")) return;

        string[] data = PlayerPrefs.GetString("SaveState").Split("|");
        //Debug.Log($"[{data[0]}, {data[1]}, {data[2]}, {data[3]}]");

        // TODO: change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // TODO: change the weapon level

        //Debug.Log("LoadState");
    }

}