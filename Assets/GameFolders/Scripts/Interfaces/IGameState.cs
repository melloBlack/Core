public interface IGameState
{
    public void Play();
    public void GameOver();
    public void Finish();

    public void AddListeners();
    public void RemoveListeners();
}
