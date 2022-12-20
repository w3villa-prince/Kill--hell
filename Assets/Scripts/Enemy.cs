using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRd;
    private GameObject player;
    public float speed = 50;

    // Start is called before the first frame update
    private void Start()
    {
        enemyRd = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRd.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
