using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Direction currentDirection;
    private Vector2 playerInput;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float time;
    private int moveDistance = 4;

    public float moveSpeed = 0.2f;
    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int x = 0;
        int y = 0;
        Vector2 target = Vector2.zero;
        

        if (Input.GetKey(KeyCode.A))
        {
            x = -moveDistance;
            y = 0;
            currentDirection = Direction.West;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = moveDistance;
            y = 0;
            currentDirection = Direction.East;
        }

        if (Input.GetKey(KeyCode.S))
        {
            x = 0;
            y = -moveDistance;
            currentDirection = Direction.South;
        }

        if (Input.GetKey(KeyCode.W))
        {
            x = 0;
            y = moveDistance;
            currentDirection = Direction.North;
        }
        
        target = new Vector2(x, y);

        switch (currentDirection)
        {
            case Direction.North:
                gameObject.GetComponent<SpriteRenderer>().sprite = northSprite;
                break;
            case Direction.South:
                gameObject.GetComponent<SpriteRenderer>().sprite = southSprite;
                break;
            case Direction.East:
                gameObject.GetComponent<SpriteRenderer>().sprite = eastSprite;
                break;
            case Direction.West:
                gameObject.GetComponent<SpriteRenderer>().sprite = westSprite;
                break;
        }

        transform.Translate(target * moveSpeed * Time.deltaTime);
        Debug.Log(transform.position.x + " + " + x);
        Debug.Log(transform.position.y + " + " + y);
    }
}

enum Direction
{
    North,
    East,
    South,
    West
}