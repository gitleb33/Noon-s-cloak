using UnityEngine;

public class knife : MonoBehaviour
{
    public Rigidbody2D knifebody;
    public bool isinair;
    public float flight_time;
    [Header("Player objesi gelecek")]
    [SerializeField] private PlayerStateManager playermanager;

    private void Awake()
    {
        knifebody = GetComponent<Rigidbody2D>();
        flight_time = 2;
    }

    private void Update()
    {
        if(flight_time > 0)
        {
            flight_time -= Time.deltaTime;
        }
        else
        {
            isinair = false;
            gameObject.SetActive(false);
            flight_time = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy" || collision.tag == "Boss" || collision.tag == "stoneman" || collision.tag == "shadow")
        {
            gameObject.SetActive(false);
            flight_time = 2;
        }
    }
}