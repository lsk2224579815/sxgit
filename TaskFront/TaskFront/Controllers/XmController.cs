using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using RabbitSqlLib;
using TaskFront.Entity;

namespace TaskFront.Controllers
{
    [Route("api/[controller]")]
    [Microsoft.AspNetCore.Cors.EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class XmController : ControllerBase
    {
        [Microsoft.AspNetCore.Cors.EnableCors("AllowAllOrigins")]
        [HttpPost("GetJH")]
        public StateInfo Get_JH_TS_J_Basicinfo([FromForm] List<string> jh)
        {

            DBEntity dBEntity = new DBEntity();
            dBEntity.DBType = "oracle";
            dBEntity.DBPort = "1521";
            dBEntity.DBServer = "132.232.16.136";
            dBEntity.DBName = "orcl";
            dBEntity.DBUser = "dqts";
            dBEntity.DBPwd = "dqts";
            string dBType = "";
            string connstr = dBEntity.GetConnStr(out dBType);
            RabbitAccess access = new RabbitAccess(dBType, connstr);
            string sql = "select* from ts_j_basicinfo where bzjh in('" + string.Join("','", jh.ToArray()) + "')";
            DataTable dt = access.GetDataTable(sql);   
            StateInfo stateInfo = new StateInfo();
            JavaScriptSerializer json = new JavaScriptSerializer();
            json.Serialize(dt);
            stateInfo.Data = json;
            return stateInfo;
        }
      
    }
}
