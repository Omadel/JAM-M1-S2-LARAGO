public class TrainPart : MovableObject
{
    public void OnMove(Direction direction)
    {
        if (currentTile.neighbours.tiles[(int)direction] != null)
        {
            currentTile.ExecuteExitCode();
            currentTile = currentTile.neighbours.tiles[(int)direction];
            currentTile.ExecuteEnterCode();
        }

    }
}

