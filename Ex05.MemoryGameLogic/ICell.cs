namespace MemoryGameLogic
{
    public interface ICell
    {

        bool CheckCellsImageIsSimilar( Cell io_secondCell);
        bool CheckIfNotSameCell( Cell io_secondCell);
        void HideCell();
        void ExposeCell();
    }
}
