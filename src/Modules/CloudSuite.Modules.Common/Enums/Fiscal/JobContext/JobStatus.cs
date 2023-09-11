namespace CloudSuite.Modules.Common.Enums.Fiscal.JobContext
{
    [Serializable]
    public enum JobStatus
    {
        Pending = 1,
        Running = 2,
        Canceled = 3,
        Failed = 4,
        Finished = 5,
        Aborted = 6
    }
}