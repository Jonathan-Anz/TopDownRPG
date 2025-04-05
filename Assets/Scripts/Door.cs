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
                if (requiredKey == KeyType.Gold) color = Colors.gold;
                else if (requiredKey == KeyType.Silver) color = Colors.silver;
                GameManager.instance.ShowText(  $"Requires {requiredKey} key!",
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