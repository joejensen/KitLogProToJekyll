namespace KlpToJekyll
{
    /// <summary>
    /// Partial which adds data to the template class generated from PostRenderer.tt
    /// </summary>
    partial class PostRenderer
    {
        private WorkLog workLog;

        public PostRenderer(WorkLog workLog)
        {
            this.workLog = workLog;
        }
    }
}
