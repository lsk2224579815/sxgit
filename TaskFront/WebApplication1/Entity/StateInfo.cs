using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFront.Entity
{
    public class StateInfo
    {
        int status = 200;
        string msg;
        Object data;

        public int Status { get => status; set => status = value; }
        public string Msg { get => msg; set => msg = value; }
        public object Data { get => data; set => data = value; }
    }
}
