
﻿namespace ToDoList.Application.DTOs.Common
{
    public class ResponseBase
    {
        public int StatusCode { get; set; }

        public ResponseBase() { }
        public ResponseBase(int Estado)
        {
            StatusCode = Estado;
        }
    }
}