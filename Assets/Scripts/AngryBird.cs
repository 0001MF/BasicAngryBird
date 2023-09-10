using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngryBird : MonoBehaviour
{
    Vector3 startingPos;
    private Vector2 directionPos;
    public float force;
    private bool birdFlag;
    float birdCount;

    AudioSource source;
    public AudioClip introSound;
    public AudioClip angleSound;
    public AudioClip releaseBird;

    private void Awake() {
        startingPos = transform.position;
        source = GetComponent<AudioSource>();
        source.clip = introSound;
        source.Play();
        // GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDown() {
        // GetComponent<SpriteRenderer>().color = Color.blue;
        GetComponent<LineRenderer>().enabled = true;
        source.clip = angleSound;
        source.Play();
    }

    private void OnMouseUp() {
        // GetComponent<SpriteRenderer>().color = Color.white;
        directionPos = startingPos - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionPos * force);
        GetComponent<Rigidbody2D>().gravityScale = 1;

        birdFlag = true;

        source.clip = releaseBird;
        source.Play();
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

    private void Update() {

        GetComponent<LineRenderer>().SetPosition(0, startingPos);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);

        if(transform.position.x >= 32
        || transform.position.x <= -27 
        || transform.position.y >= 17
        || transform.position.y <= -15
        || birdCount >= 5f
        || Input.GetKeyDown(KeyCode.Q)) {
            string sceneName = SceneManager.GetActiveScene().name;
            // Debug.Log(sceneName);
            SceneManager.LoadScene(sceneName);
        }

        if(birdFlag == true && GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f) {
            birdCount += Time.deltaTime;
        }
    }
}
