﻿namespace VirtualPaws.Application.Wrappers
{
    public class QueryResponse<T> : BaseResponse
    {
        public T Value { get; set; }
        public string ServicesName { get; set; }

        public QueryResponse(string servicesName, string Message, T value) : base(Message)
        {
            ServicesName = servicesName;
            Value = value;  
        }
    }
}
