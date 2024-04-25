namespace ToDo.Domain.ActionLogs
{
    public class ActionLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public OperationTypes OperationType { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
    public enum OperationTypes
    {
        Created,
        Updated,
        Deleted,
        MarkedAsDone
    }
}
