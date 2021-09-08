using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //UpButton
    public KeyCode UpButton = KeyCode.W;

    //DownButton
    public KeyCode DownButton = KeyCode.S;

    //MovementSpeed
    public float speed = 10.0f;

    //UpperLimit and LowerLimit
    public float yBoundary = 9.0f;

    //RigidBody racket
    private Rigidbody2D rigidBody2D;

    //Score
    private int score;

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;

    // Untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //value racket
        Vector2 velocity = rigidBody2D.velocity;

        //if push upbutton
        if (Input.GetKey(UpButton))
        {
            velocity.y = speed;
        }
        //if push downbutton
        else if (Input.GetKey(DownButton))
        {
            velocity.y = -speed;
        }

        //if not push button
        else
        {
            velocity.y = 0;
        }

        //reenter speed
        rigidBody2D.velocity = velocity;

        //value racket now
        Vector3 position = transform.position;

        //if racket position cross the line up
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        //if racket position cross the line down
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        //reenter position to transform
        transform.position = position;

    }

    //raise point 1
    public void IncrementScore()
    {
        score++;
    }

    //reset point to 0
    public void ResetScore()
    {
        score = 0;
    }

    //get score
    public int Score {
        get { return score; }
    }
}
