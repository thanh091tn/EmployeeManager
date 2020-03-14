using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class ConfirmTaskRequest
    {
        public Guid Id { get; set; }
        public int Mark { get; set; }
        public String Note { get; set; }
    }
}
