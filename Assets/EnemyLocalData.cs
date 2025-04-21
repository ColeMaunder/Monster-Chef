using UnityEngine;

public class EnemyLocalData : MonoBehaviour
{
    private bool canMove = true;

    public bool GetCanMove(){
        return canMove;
    }

    public void SetCanMove(bool canMoveIn){
        canMove= canMoveIn;
    }
}
