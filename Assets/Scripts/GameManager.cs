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
    public Weapon[] weapons = new Weapon[4];
    public WeaponData defaultWeapon; // Set in inspector
    public FloatingTextManager floatingTextManager;
    
    // Logic
    public int coins;
    public int experience;


    private void Start()
    {
        // Start player off with a normal sword

    }


    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }



    // Save state
    public void SaveState()
    {
        string s = "";

        s += "0" + "|"; // TEMP
        s += coins.ToString() + "|";
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
        coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // TODO: change the weapon level

        //Debug.Log("LoadState");
    }

}