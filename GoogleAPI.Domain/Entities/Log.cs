using GoogleAPI.Domain.Entities.Common;

namespace GoogleAPI.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string Message { get; set; }
        public string MessageHeader { get; set; }
        public string Level { get; set; }
        public DateTime LoggedDate { get; set; }
        public string ExceptionText { get; set; }
        public string LogEvent { get; set; }
        public string UserId { get; set; }

    }
}
