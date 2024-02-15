﻿namespace Luftborn.Utils
{

    public class ErrorResponse
    {
        public Error error { get; set; }
        public InnerError innerError { get; set; }
    }
    public class Error
    {
        public Error(string _code, Message _message)
        {
            code = _code;
            message = _message;
        }
        public string code { get; set; }
        public Message message { get; set; }
    }
    public class Message
    {
        public Message(string _value)
        {
            value = _value;
        }
        public string value { get; set; }
    }
    public class InnerError
    {
        public InnerError(string _trace)
        {
            trace = _trace;
        }
        public string trace { get; set; }
    }
    
}
