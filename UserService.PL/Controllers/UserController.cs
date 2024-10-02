using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Asp.Versioning;
using System.Net;
using UserService.DAL.Entities;
using UserService.BLL.Interfaces;
using UserService.DAL.Infrastructures;
using UserService.Model;
using Microsoft.AspNetCore.Cors;

namespace UserService.PL.Controllers
{
    [EnableCors("AllowAll")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IOrderDetailService orderDetailService;
        private readonly IClientDataService clientDataService;

        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger, 
            IOrderDetailService orderDetailService, IClientDataService clientDataService)
        {
            this.orderDetailService = orderDetailService;
            this.clientDataService = clientDataService;

            this.logger = logger;
        }

        //=======================HttpRequest of entity OrderDetail=======================//

        /////<include file='../DocXML/UserControllerDoc.xml' path='docs/members[@name="controller"]/GetOrderDetails/*'/>
        [MapToApiVersion("1.0")]
        [HttpGet("order-details/{name?}", Name = "GetOrderDetails")]
        [ProducesResponseType(typeof(IEnumerable<OrderDetail>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetail([FromRoute] string? name)
        {
            try
            {
                return Ok(orderDetailService.getOrderDetails(name));
            }
            catch (DbException ex)
            {
                return BadRequest(new { ex.ErrorCode, ex.Message, ex.Source });
            }
            catch (StatusCode404 ex)
            {
                return NotFound(new { ex.code, ex.Message, ex.property });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { code = 400, ex.Message, ex.ParamName });
            }
        }

        //=======================HttpRequest of entity ClientData=======================//

        /////<include file='../DocXML/UserControllerDoc.xml' path='docs/members[@name="controller"]/GetClientData/*'/>
        [MapToApiVersion("1.0")]
        [HttpGet("client-data/{firstName}-{lastName}", Name = "GetClientCourseData")]
        [ProducesResponseType(typeof(ClientData), (int)HttpStatusCode.OK)]
        public ActionResult<ClientCourseData> GetClientData([FromRoute] string firstName, string lastName)
        {
            try
            {
                return Ok(clientDataService.getClientData($"{firstName}-{lastName}"));
            }
            catch (StatusCode404 ex)
            {
                return NotFound(new { ex.code, ex.Message, ex.property });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { code = 400, ex.Message, ex.ParamName });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.HResult, ex.Message, ex.InnerException });
            }
        }
    }
}
