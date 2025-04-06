using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Resources
    public WeaponData defaultWeapon; // Set in inspector
    public List<WeaponData> inventoryWeapons = new List<WeaponData>();
    public int[] potions = { 0, 0, 0, 0 };
    public bool hasGoldKey = false;
    public bool hasSilverKey = false;
    public bool defeatedBoss = false;

    // References
    public Player player;
    public Weapon currentWeapon;
    public FloatingTextManager floatingTextManager;
    public CharacterMenu menu;
    public HUD hud;
    
    // Logic
    //public int coins;
    //public int experience;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        Time.timeScale = 0f;
        //SceneManager.sceneLoaded += LoadState;
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Start player off with a normal sword
        AddWeapon(defaultWeapon);
        player.currentWeapon.SetCurrentWeapon(defaultWeapon);
    }

    void Update()
    {
        // Regain stamina
        if (player.stamina < player.maxStamina) player.stamina += player.staminaRechargeRate * Time.deltaTime;

        // Update health bars
        hud.SetHealthBar((float)player.health / player.maxHealth);
        hud.SetStaminaBar(player.stamina / player.maxStamina);
    }

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    // Weapons
    public void AddWeapon(WeaponData weapon)
    {
        // Only max of 4 weapons
        if (inventoryWeapons.Count >= 4) return;

        // Add weapon
        inventoryWeapons.Add(weapon);

        // Add weapon to menu display
        menu.AddWeaponToMenu(inventoryWeapons.Count - 1, weapon);

        //Debug.Log($"Added {weapon.name} to inventory weapons");
    }

    // Potions
    public void UsePotion(PotionType type)
    {
        if (potions[(int)type] <= 0) return;

        string message = "";
        Color color = Color.clear;
        switch(type)
        {
            case PotionType.Health:
                if (player.health == player.maxHealth)
                {
                    message = "Health already full";
                }
                else
                {
                    player.health = player.maxHealth;
                    message = "Health now full";
                    potions[(int)type] -= 1;
                }
                color = Color.red;
                break;

            case PotionType.Stamina:
                if (player.stamina >= player.maxStamina - 0.01f)
                {
                    message = "Stamina already full";
                }
                else
                {
                    player.stamina = player.maxStamina;
                    message = "Stamina now full";
                    potions[(int)type] -= 1;
                }
                color = Color.green;
                break;

            case PotionType.Speed:
                player.xSpeed += 0.25f;
                player.ySpeed += 0.25f;
                message = $"Movement speed increased permanently";
                color = Color.blue;
                potions[(int)type] -= 1;
                break;

            case PotionType.Strength:
                player.strength += 1;
                message = $"Strength increased permanently";
                color = Color.yellow;
                potions[(int)type] -= 1;
                break;
        }

        ShowText(   message,
                    20,
                    color,
                    Camera.main.ScreenToWorldPoint(new Vector3(400, 100, 0)),
                    Vector3.zero,
                    1.5f );

        menu.UpdateMenu();
    }

    // Keys
    public bool HasCorrectKey(KeyType key)
    {
        switch (key)
        {
            case KeyType.Gold: return hasGoldKey;
            case KeyType.Silver: return hasSilverKey;
            case KeyType.Enemy: return defeatedBoss;
            default: return false;
        }
    }

    // Menu
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Save state
    public void SaveState()
    {
        //string s = "";

        //s += "0" + "|"; // TEMP
        //s += coins.ToString() + "|";
        //s += experience.ToString() + "|";
        //s += "0"; // TEMP

        //PlayerPrefs.SetString("SaveState", s);
        //Debug.Log("SaveState");
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        //if (!PlayerPrefs.HasKey("SaveState")) return;

        //string[] data = PlayerPrefs.GetString("SaveState").Split("|");
        //Debug.Log($"[{data[0]}, {data[1]}, {data[2]}, {data[3]}]");

        // TODO: change player skin
        //coins = int.Parse(data[1]);
        //experience = int.Parse(data[2]);
        // TODO: change the weapon level

        //Debug.Log("LoadState");
    }

}