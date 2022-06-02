using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 inputVector;
    Vector2 mouseDir;
    float health = 300;
    CanvasManager canvasManager;

    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canvasManager = FindObjectOfType<CanvasManager>();
    }

    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - rb.position;

        health -= Time.deltaTime * 6;
        canvasManager.setHealthText(health);

        if (health <= 0)
        {
            FindObjectOfType<LevelMangaer>().RestartGame();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputVector * speed * Time.fixedDeltaTime);
        rb.rotation = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
    }

    public Vector2 GetMouseDir()
    {
        return mouseDir;
    }

    public void GetDamage(float damage)
    {
        health += damage;
        health = Mathf.Clamp(health, 0, 300);
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }
}
