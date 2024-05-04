using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    public ParticleSystem particleOnDeath;
    public ParticleSystem particleOnWalk;
    public AudioClip crashAudio;
    public AudioClip jumpAudio;

    private AudioSource audioSource;

    bool canJump;
    public float jumpValue = 50;
    public Vector3 gravityValue;
    public bool gameOver;
    public bool devTest;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity = gravityValue;
    }
    private void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canJump)
                {

                    rb.AddForce(Vector3.up * jumpValue * Time.fixedDeltaTime, ForceMode.Impulse);
                    particleOnWalk.Stop();
                    audioSource.PlayOneShot(jumpAudio, 1);
                    animator.SetTrigger("Jump_trig");
                    canJump = false;

                }

            }
            if (Input.GetKeyDown(KeyCode.G))
            {

                Physics.gravity = gravityValue;
                print(Physics.gravity);
            }
        }

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (!devTest)
        {

            if (collision.gameObject.tag == "Obstacles")
            {
                gameOver = true;
                particleOnDeath.Play();
                particleOnWalk.Stop();
                audioSource.PlayOneShot(crashAudio, 1);

                animator.SetBool("Death_b", true);
                animator.SetInteger("DeathType_int", 1);
            }
        }
        if (collision.gameObject.tag == "Ground")
        {
            particleOnWalk.Play();
            //audioSource.PlayDelayed();
            canJump = true;
        }

    }

}
