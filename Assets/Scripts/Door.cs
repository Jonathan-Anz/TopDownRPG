using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D triggerCollider;
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private Sprite openDoorSprite;
    [SerializeField] private KeyType requiredKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Debug.Log("Collided with player!");
            if (GameManager.instance.HasCorrectKey(requiredKey)) Open();
            else
            {
                Color color = Color.clear;
                string message = "";
                if (requiredKey == KeyType.Gold)
                {
                    message = $"Requires {requiredKey} key!";
                    color = Colors.gold;
                }
                else if (requiredKey == KeyType.Silver)
                {
                    message = $"Requires {requiredKey} key!";
                    color = Colors.silver;
                }
                else if (requiredKey == KeyType.Enemy)
                {
                    message = $"Defeat final boss to unlock!";
                    color = Color.white;
                }
                GameManager.instance.ShowText(  message,
                                                25,
                                                color,
                                                transform.position,
                                                Vector3.zero,
                                                1.5f );
            }
        }
    }

    private void Open()
    {
        spriteRenderer.sprite = openDoorSprite;
        triggerCollider.enabled = false;
        doorCollider.enabled = false;
    }

}