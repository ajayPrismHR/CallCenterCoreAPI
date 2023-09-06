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
        public Int64 Short_Calls { get; set; }
        public Int64 Ans_LessThan_5_Secs { get; set; }
        public Int64 Ans_6to10_Secs { get; set; }
        public Int64 Ans_11to20_Secs { get; set; }
        public Int64 Ans_21to30_Secs { get; set; }
        public Int64 Ans_31to40_Secs { get; set; }
        public Int64 Ans_41to50_Secs { get; set; }
        public Int64 Ans_51to60_Secs { get; set; }
        public Int64 Ans_GreaterThan_60_Secs { get; set; }
        public Int64 Total_Calls_Abandon { get; set; }
        public Int64 Aban_LessThan5_Sec { get; set; }
        public Int64 Aban_6to10_Secs { get; set; }
        public Int64 Aban_11to20_Secs { get; set; }
        public Int64 Aban_21to30_Secs { get; set; }
        public Int64 Aban_31to40_Secs { get; set; }
        public Int64 Aban_41to50_Secs { get; set; }
        public Int64 Aban_51to60_Secs { get; set; }
        public Int64 Aban_GreaterThan_60_Secs { get; set; }
        public Int64 Failed { get; set; }
        public string Total_Call_Handling_Time { get; set; }
        public string Total_Talk_Time { get; set; }
        public string Average_Talk_Time { get; set; }
        public string Average_Call_Handling_Time { get; set; }
        public Int64 Calls_Held { get; set; }
        public Int64 Calls_Queued { get; set; }
        public string Calls_Queue_Time { get; set; }
        public string Avg_Queue_Time { get; set; }
        public float Service_per { get; set; }
        public float Aban_Per { get; set; }
        public float SLA_Per { get; set; }
        public Int64 ABN_10_Sec { get; set; }
        public float ABN_10_Sec_Per { get; set; }
        public Int64 ABN_20_Sec { get; set; }
        public float ABN_20_Sec_Per { get; set; }
        public Int64 ABN_30_Sec { get; set; }
        public float ABN_30_Sec_Per { get; set; }
        public Int64 ABN_60_Sec { get; set; }
        public float ABN_60_Sec_Per { get; set; }
        public Int64 ABN_90_Sec { get; set; }
        public float ABN_90_Sec_Per { get; set; }
        public Int64 SLA_10_Sec { get; set; }
        public float SLA_10_Sec_Per { get; set; }
        public Int64 SLA_20_Sec { get; set; }
        public float SLA_20_Sec_Per { get; set; }
        public Int64 SLA_30_Sec { get; set; }
        public float SLA_30_Sec_Per { get; set; }
        public Int64 SLA_60_Sec { get; set; }
        public float SLA_60_Sec_Per { get; set; }
        public Int64 SLA_90_Sec { get; set; }
        public float SLA_90_Sec_Per { get; set; }
        public string Total_Hold_Time { get; set; }
        public string Avg_Hold_Time_of_Ans { get; set; }
        public string Total_Wrapup_Time { get; set; }
        public string Avg_Wrapup_Time { get; set; }
        //public string Call_Type { get; set; }

    }
}
