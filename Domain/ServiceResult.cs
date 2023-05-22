namespace Domain
{
    public class ServiceResult<T>
    {
        public bool IsSuccessfull { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}