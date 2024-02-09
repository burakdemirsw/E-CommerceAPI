namespace GoogleAPI.Domain.Models.Response
{
    public class ResponseModel<T>
    {
        public int TotalCount { get; set; } = 0;
        public List<T>? Datas { get; set; }
    }
}
