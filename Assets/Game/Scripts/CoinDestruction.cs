using UnityEngine;

public class CoinDestruction : MonoBehaviour
{
    private ScoreCount scoreBoard;
    private AudioSource pickUpCoin;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreCount>();
        pickUpCoin = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpCoin.Play();
            scoreBoard.ScoreHit();
            Destroy(this.gameObject);
        }
        else
        {
            Invoke("DestroyCoin", 5f);
        }
    }

    private void DestroyCoin()
    {
        Destroy(this.gameObject);
    }
}
