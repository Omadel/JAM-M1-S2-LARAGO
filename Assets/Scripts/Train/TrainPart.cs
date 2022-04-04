public class TrainPart : MovableObject
{
    public void OnMove()
    {

        if(currentTile!=null)
            currentTile.ExecuteExitCode();
            GetCurrentTile();
        if (currentTile != null)
            currentTile.ExecuteEnterCode();

    }
}

