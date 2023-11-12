using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //1. access (public or private)
    //2. type (int, float, bool)
    //3. name (naming conventions) they always start with a letter that is not capitalized, but you can have multiple words with no spaces and following words could be capitalized
    //4. OPTIONAL: you can give it a value
    //borders: 13.9 and 6.6

    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimit;
    public float verticalScreenLimit;
    public float middleScreen;
    public float bottomScreen; 
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4f;
        horizontalScreenLimit = 13.9f;
        verticalScreenLimit = 3.35f;
        middleScreen = -0.5f;
        bottomScreen = 2.5f;
    }

    // Update is called once per frame; if your computer runs at 60 fps
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0);
        }
        else if (transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0);
        }

        if (transform.position.y > verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
        else if (transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimit, 0);
        }
    }

    void Shooting()
    {
        //if I press SPACE, create a bullet
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //create a bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}