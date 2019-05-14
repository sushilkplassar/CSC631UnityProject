using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour {

    public SceneController controller;
    public GameObject Card_Back;
    public GameObject camera;

    public float distanceToSee;
    RaycastHit whatIsHit; // stores what is hit in this variable

    // Update is called once per frame
    void Update()
    {
        // check for raycast collision
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out whatIsHit, distanceToSee))
        {
            if (Input.GetKeyDown (KeyCode.E))
            {
                Debug.Log ("I interacted with " + whatIsHit.collider.gameObject.name);
                
                    // check for a specific game object collision
                    if (whatIsHit.collider.gameObject.GetComponent<MainCard>().Card_Back)
                    {
                        CheckCard();
                    }
            }
        }
    }

    public void CheckCard()
    {
        if(Card_Back.activeSelf && controller.canReveal)
        {
            Card_Back.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; //This gets the sprite renderer component and changes the property of it's sprite!
    }

    public void Unreveal()
    {
        Card_Back.SetActive(true);
    }


}
