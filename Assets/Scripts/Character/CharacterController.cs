using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float _playerInput;
    private bool _userJumped;
    private bool _restart;

    private const float _inputScale = 0.5f;
    
    private Rigidbody _rigidBody;
    private Transform _transform;

    public ScoreManager scoreManager;
    public ResetManager resetManager;

    public AudioClip gameOverAudioClip;
    public AudioClip collectableAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        scoreManager = GetComponent<ScoreManager>();
        resetManager = GetComponent<ResetManager>();
        GetComponent<AudioSource>().playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
        _playerInput = Input.GetAxis("Horizontal");
        _userJumped = Input.GetButton("Jump");
        _restart = Input.GetKeyDown("r");

        if (_restart) {
            resetManager.ResetGame();
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity += transform.forward * _playerInput * _inputScale;

        if(_userJumped && _rigidBody.velocity.y == 0)
        {
            _rigidBody.AddForce(Vector3.up * 8, ForceMode.Impulse);
            _userJumped = false;
        }
    } 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            GetComponent<AudioSource>().clip = collectableAudioClip;
            GetComponent<AudioSource>().Play();
            scoreManager.UpdateScore();
        } else if (collision.gameObject.tag == "Obstacle")
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().clip = gameOverAudioClip;
        GetComponent<AudioSource>().Play();
        Debug.Log("Game Over");
        scoreManager.characterInfo.GameOver();
    }
}
