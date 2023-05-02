namespace DemoModel.Interfaces
{
    public interface IDemoLayer
    {
        /// <summary>
        /// Редактор данного типа слоя.
        /// </summary>
        IDemoLayerEditor Editor { get; set; }
    }
}