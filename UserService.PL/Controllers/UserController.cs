using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using Asp.Versioning;
using System.Net;
using UserService.DAL.Entities;
using UserService.BLL.Interfaces;

namespace AdminService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            catch (Exception ex)
            {
                return NotFound(new { code = 404, ex.Message, });
            }
        }
    }
}
