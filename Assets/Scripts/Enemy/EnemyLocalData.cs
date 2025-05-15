using UnityEngine;

public class EnemyLocalData : MonoBehaviour
{
    private bool canMove = true;
    private bool canLook = true;

    public bool GetCanMove(){
        return canMove;
    }

    public void SetCanMove(bool canMoveIn){
        canMove= canMoveIn;
    }

    public bool GetCanLook(){
        return canLook;
    }

    public void SetCanLook(bool canLookIn){
        canLook= canLookIn;
    }
}
