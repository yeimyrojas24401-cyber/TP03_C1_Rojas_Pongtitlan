using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // The purpose of this script is to handle the movement of the player character in the game. It will allow the player to move left, right, up, and down. 

    [Header("Movement Settings")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;

    [SerializeField] private bool isContinuous = true;

    [Header("Speed Settings")]
    public float moveSpeedPlayer = 1f;
    private Rigidbody2D rb;

    [Range(1,2)][SerializeField] private int playerIndex = 1;

    
    void Awake()
    {
        // aqui desde que despierta mando a llamar a los componentes que existen dentro de mi sprite
        rb = GetComponent<Rigidbody2D>();

        switch (playerIndex)
        {
            case 1:
                moveSpeedPlayer = GameManager.Instance.player1Speed; //carga la velocidad instanciada desde el menu y la pone en el moveSpeed en esta nueva escena
                break;

            case 2:
                moveSpeedPlayer = GameManager.Instance.player2Speed; //carga la velocidad instanciada desde el menu y la pone en el moveSpeed en esta nueva escena
                break;

            default:
                moveSpeedPlayer = GameManager.Instance.player1Speed; //carga la velocidad instanciada desde el menu y la pone en el moveSpeed en esta nueva escena
                break;

        }
    }
    private void FixedUpdate() // fisicas
    {
        if (isContinuous)
        {
            // Movimiento continuo con fisicas
            if (Input.GetKey(moveUp))
            {
                rb.AddForce(new Vector3(0, moveSpeedPlayer * Time.fixedDeltaTime));
            }
            if (Input.GetKey(moveRight))
            {
                rb.AddForce(new Vector3(moveSpeedPlayer * Time.fixedDeltaTime, 0));
            }
            if (Input.GetKey(moveDown))
            {
                rb.AddForce(new Vector3(0, -moveSpeedPlayer * Time.fixedDeltaTime));
            }
            if (Input.GetKey(moveLeft))
            {
                rb.AddForce(new Vector3(-moveSpeedPlayer * Time.fixedDeltaTime, 0));
            }
        }
        else
        {
            // Movimiento no continuo 
            if (Input.GetKey(moveUp))
            {
                rb.position += new Vector2(0, moveSpeedPlayer * Time.fixedDeltaTime);
            }
            if (Input.GetKey(moveRight))
            {
                rb.position += new Vector2(moveSpeedPlayer * Time.fixedDeltaTime, 0);
            }
            if (Input.GetKey(moveDown))
            {
                rb.position += new Vector2(0, -moveSpeedPlayer * Time.fixedDeltaTime);
            }
            if (Input.GetKey(moveLeft))
            {
                rb.position += new Vector2(-moveSpeedPlayer * Time.fixedDeltaTime, 0);
            }
        }
    }
}