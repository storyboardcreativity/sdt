namespace View
{
    public class LayerReplaceEventArgs
    {
        /// <summary>
        /// ������������� ����.
        /// </summary>
        public int LayerId { get; set; }

        /// <summary>
        /// ������ ������������� ������������� ����.
        /// </summary>
        public int LayerOldParentId { get; set; }

        /// <summary>
        /// ����� ������������� ������������� ����.
        /// </summary>
        public int LayerNewParentId { get; set; }
    }
}