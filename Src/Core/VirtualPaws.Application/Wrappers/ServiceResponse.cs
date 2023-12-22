namespace VirtualPaws.Application.Wrappers
{
    public class ServiceResponse : BaseResponse
    {
        public string ServicesName { get; set; }

        public ServiceResponse(string servicesName, string Message) : base(Message)
        {
            ServicesName = servicesName;
        }
    }
}
