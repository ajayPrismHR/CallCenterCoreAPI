namespace CallCenterCoreAPI.Models.QueryModel
{
    public class CallDetailModel
    {
        public DateTime date { get; set; }
        public Int64 Total_Calls_Offered { get; set; }
        public Int64 Total_Calls_Answered { get; set; }
        public Int64 Calls_Answered_within_60_Sec { get; set; }
        public Int64 Calls_Answered_After_60_Sec { get; set; }
        public float Percent_Calls_Attended_within_60_Sec { get; set; }
        public float Percent_Calls_Attended_After_60_Sec { get; set; }
        public Int64 Calls_Abandon { get; set; }
        public float Call_Abandon_Percentage { get; set; }
        public Int64 Calls_Abandon_within_60_Sec { get; set; }
        public Int64 Total_Call_Wait_Time { get; set; }
        public Int64 Call_Wait_Time_more_than_60_Sec { get; set; }

    }
}
