using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum TypeMovement : int {
        Transform,
        Rigid
    }
    public float speed = 10f;
    public TypeMovement typeMovement = TypeMovement.Rigid;
    private Rigidbody rigidBody;
    bool isCanMove;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init()
    {
        rigidBody = GetComponent<Rigidbody>();
        if(typeMovement == TypeMovement.Rigid && rigidBody == null)
        {
            typeMovement = TypeMovement.Transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (canMove())
        if (isCanMove)
        {
            switch(typeMovement)
            {
                case TypeMovement.Transform:
                    moveByTransform();
                    break;
                case TypeMovement.Rigid:
                    moveByRigidBody();
                    break;
            }
        }
    }

    private bool canMove()
    {
        // TODO: Check player can move or not. Will implement later.
        return Input.GetKey(KeyCode.LeftControl);
    }

    public void SetMoveState(bool state){
        isCanMove = state;
    }
    public bool IsCanMove(){
        return isCanMove;
    }

    private Vector3 getDirectionCamera()
    {
        Vector3 direction = Camera.main.transform.forward.normalized;
        direction.y = 0;
        return direction;
    }

    private void moveByTransform()
    {
        transform.position += getDirectionCamera() * speed * Time.deltaTime;
    }

    private void moveByRigidBody()
    {
        rigidBody.MovePosition(rigidBody.transform.position + getDirectionCamera() * speed * Time.deltaTime);
    }
}
