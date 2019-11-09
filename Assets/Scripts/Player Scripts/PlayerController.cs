using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // Movement
  
    protected DynamicJoystick _DynamicJoystick;
    // Instantiate velocity and animation
    private Rigidbody2D _rigibody;
    private Animator _animator;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _audioClipJump;
    [SerializeField] private AudioClip _audioClipDied;
    [SerializeField] private AudioClip _audioClipBoom;
    [SerializeField] private AudioClip _audioClipCoins;
    [SerializeField] private GameObject spawn;


    private Vector3 _positionSpawn;
    private bool _initialPush; 
    private bool _died;
    public static int Coins;
    public static int Score;
    public static int ScoreTemp;
    public static bool flap_Score = false;
    public float moveSpeed = 4f;
    private static readonly int JumpTrigger = Animator.StringToHash("JumpTrigger");
    private static readonly int Died = Animator.StringToHash("Died");

    void Awake()
    {
        _DynamicJoystick = FindObjectOfType<DynamicJoystick>();
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _initialPush = false;
        _positionSpawn = spawn.transform.position;
        Coins = 0;
        checkScore();
        checkSound();
        
    }

    #region Check Score
    private void checkScore()
    {
        if (flap_Score)
        {
            Score = ScoreTemp;
        }
        else
        {
            Time.timeScale = 0;
            Score = 0;
        }
    }
    #endregion

    #region Check Sound
    private void checkSound()
    {
        if (GameMenuManager.flag == 0)
        {
            _source.mute = true;
        }
        else
        {
            _source.mute = false;
        }
    }
    #endregion

    // Update is called once per frame
    private void Update()
    {
        #region Chedck die and show panel
        if (_died)
        {
            if (Coins >= 25)
            {
                flap_Score = true;
                ScoreTemp = Score;
                if (UIManager._UIManager != null)
                {
                    UIManager._UIManager.ShowPanelCongratulations();
                }
                   
            }
            else 
            {
                flap_Score = false;
                if (UIManager._UIManager != null)
                    UIManager._UIManager.ShowPanelDied();
            }
        }
        #endregion
        
    }

    void FixedUpdate()
    {
        SpawnFood();
        Movement();
    }

    void SpawnFood()
    {
        if (_positionSpawn.y <= transform.position.y)
        {
            PlatformSpawner.instance.SpawnPlatforms();
            _positionSpawn.y += 7f;
        }
    }

    #region Player Move
    void Movement()
    {
        if (_died) return;

        #region input A and D

        float Horizontal = _DynamicJoystick.Horizontal;
        _rigibody.velocity = new Vector2(Horizontal * moveSpeed, _rigibody.velocity.y);
        transform.localScale = new Vector2(Mathf.Sign(Horizontal) * 0.75f, 0.75f);
        #endregion*/
    }
    #endregion

    #region Event OnTrigger
    void OnTriggerEnter2D(Collider2D target)
    {
        float velocityInitial = Random.Range(15f, 20f);
        float velocityNormal = Random.Range(7f, 12f);

        if (_died) return;

        if (target.gameObject.CompareTag("Food"))
        {
            if (!_initialPush) // true
            {
                _initialPush = true;
                _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityInitial);
                target.gameObject.SetActive(false);
                _animator.SetTrigger(JumpTrigger);
                _source.PlayOneShot(_audioClipJump);
                return;// exit outrigger because initial_push
            }
        }

        if (target.gameObject.CompareTag("Food"))
        {

            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 2;
        }


        if (target.gameObject.CompareTag("Food_1"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 1;
        }

        if (target.gameObject.CompareTag("Food_2"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 3;
        }

        if (target.gameObject.CompareTag("Food_3"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 1;
        }

        if (target.gameObject.CompareTag("Food_4"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 1;
        }

        if (target.gameObject.CompareTag("Food_5"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 2;
        }

        if (target.gameObject.CompareTag("Food_6"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 4;
        }

        if (target.gameObject.CompareTag("Food_7"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 3;
        }

        if (target.gameObject.CompareTag("Food_8"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 3;
        }

        if (target.gameObject.CompareTag("Food_9"))
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, velocityNormal);
            target.gameObject.SetActive(false);
            _animator.SetTrigger(JumpTrigger);
            _source.PlayOneShot(_audioClipJump);
            Score += 2;
        }

        if (target.gameObject.CompareTag("Coins"))
        {
            target.gameObject.SetActive(false);
            _source.PlayOneShot(_audioClipCoins);
            Coins += 1;
        }
        
        if (target.gameObject.CompareTag("Boom"))
        {
            _source.PlayOneShot(_audioClipBoom);
            _animator.SetTrigger(Died);
            _died = true;
        }

        if (target.gameObject.CompareTag("FallDown"))
        {
            _animator.SetTrigger(Died);
            _source.PlayOneShot(_audioClipDied);
            _died = true;
        }
    }
    #endregion
}
