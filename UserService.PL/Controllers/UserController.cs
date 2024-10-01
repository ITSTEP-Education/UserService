using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Asp.Versioning;
using System.Net;
using UserService.DAL.Entities;
using UserService.BLL.Interfaces;
using AdminService.DAL.Infrastructures;

namespace AdminService.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IOrderDetailService orderDetailService;

        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger, IOrderDetailService orderDetailService)
        {
            this.orderDetailService = orderDetailService;

            this.logger = logger;
        }

        //=======================HttpRequest of entity OrderDetail=======================//

        ///<include file='../DocXML/UserControllerDoc.xml' path='docs/members[@name="controller"]/GetOrderDetails/*'/>
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
    }
}
