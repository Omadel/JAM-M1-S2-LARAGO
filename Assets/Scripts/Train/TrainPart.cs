using UnityEngine;
public class TrainPart : MovableObject
{
    public void OnMoveMethod()
    {
        if(currentTile!=null)
            currentTile.ExecuteExitCode();
            GetCurrentTile();
        if (currentTile != null)
            currentTile.ExecuteEnterCode();

    }
}

