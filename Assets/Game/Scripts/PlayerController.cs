using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 0;
    private bool facingRight = true;
    private Animator anim;
    public AudioSource running;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();

        //turn control
        if (facingRight == false && speed > 0)
            Flip();
        else if(facingRight == true && speed < 0)
            Flip();

        //animation control
        if (speed == 0)
            anim.SetBool("isRunning", false);
        else
            anim.SetBool("isRunning", true);
    }

    private void Move()
    {
        if (speed < 0 && transform.localPosition.x >= -17)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (speed > 0 && transform.localPosition.x <= 17)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    public void OnLeftButton()
    {
        if(!running.isPlaying)
            running.Play();

        speed = -4;
    }

    public void OnRightButton()
    {
        if (!running.isPlaying)
            running.Play();

        speed = 4;
    }

    public void OnButtonUp()
    {
        speed = 0f;
        running.Stop();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
