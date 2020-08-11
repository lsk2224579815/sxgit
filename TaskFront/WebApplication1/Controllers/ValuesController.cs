using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitSqlLib;
using TaskFront.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
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
          
            stateInfo.Data = dt;
            return stateInfo;
        }


       /* // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
