namespace View
{
    public class LayerReplaceEventArgs
    {
        /// <summary>
        /// Идентификатор слоя.
        /// </summary>
        public int LayerId { get; set; }

        /// <summary>
        /// Старый идентификатор родительского слоя.
        /// </summary>
        public int LayerOldParentId { get; set; }

        /// <summary>
        /// Новый идентификатор родительского слоя.
        /// </summary>
        public int LayerNewParentId { get; set; }
    }
}