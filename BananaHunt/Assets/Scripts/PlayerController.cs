using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(JumpLeft());

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(JumpRight());
        }

        //playerAnimations.SetBool("jump_left", false);
        //playerAnimations.SetBool("jump_right", false);
    }
    IEnumerator JumpLeft()
    {
        playerAnimations.SetBool("jump_left", true);
        yield return new WaitForSeconds(1);
        playerAnimations.SetBool("jump_left", false);
    }

    IEnumerator JumpRight() {
        playerAnimations.SetBool("jump_right", true);
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        playerAnimations.SetBool("jump_right", false);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.DecreaseLives();
            int lives = LivesManager.instance.GetLives();
            if(lives <= 0)
            {
                Destroy(this.gameObject);
                GameManager.Instance.isGameOver = true;
                GameManager.Instance.GameOver();
            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }
       else if(other.gameObject.tag == "Heart")
        {
            Destroy(other.gameObject);
            GameManager.Instance.IncreaseLives();
        }
       else if (other.gameObject.tag == "Banana")
        {
            Destroy(other.gameObject);
            GameManager.Instance.IncreaseBanana();
        }
    }
}
