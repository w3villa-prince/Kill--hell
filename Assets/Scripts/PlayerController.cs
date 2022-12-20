//using System.Collections;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRd;
    public float speed = 10f;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    private float powerUpStrenght;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    private void Start()
    {
        playerRd = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        // powerupIndicator = GameObject.Find("PowerupIndicator");
    }

    // Update is called once per frame
    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRd.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);//not call
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
            Debug.Log("active");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidboady = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidboady.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
            Debug.Log("Collided  With ::" + gameObject.name + " WithPower uP" + hasPowerUp);
            //StartCoroutine(PowerupCountDownRoutine());
        }
    }

    public IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
        Debug.Log("disActive");
    }
}
