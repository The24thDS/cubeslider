using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Rigidbody rb;
  [SerializeField]
  private float forwardForce = 2000f;
  public float sidewaysForce = 500f;
  private float dificultyIncreaseDistance = 200f;
  private GameManager gm;

  void Start()
  {
    gm = FindObjectOfType<GameManager>();
  }

  void Update()
  {
    if(transform.position.z >= dificultyIncreaseDistance)
    {
      dificultyIncreaseDistance += 200f;
      gm.increaseObstacleSpawnRate();
    }
  }
  void FixedUpdate()
  {
    rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

    float x = Input.GetAxisRaw("Horizontal");

    if (x!=0)
    {
      rb.AddForce(x * sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
    }
    if (rb.position.y < -1f)
    {
      FindObjectOfType<GameManager>().EndGame();
    }
  }
}
