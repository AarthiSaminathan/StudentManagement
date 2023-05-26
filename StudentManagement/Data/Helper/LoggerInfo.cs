namespace StudentManagement.Data.Helper
{
    internal class LoggerInfo
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public string CorrelationId { get; set; }
        public string RequestId { get; set; }
        public DateTime EventTime { get; set; }
        public string ServiceName { get; set; }
    }
}