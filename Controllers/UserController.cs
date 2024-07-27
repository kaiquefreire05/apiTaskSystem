using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Access to database methods

        private readonly IUserRepository _userRep;
        public UserController (IUserRepository userRep)
        {
            this._userRep = userRep;
        }

        // API methods

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchAllUsers()
        {
            List<UserModel> users = await _userRep.SearchAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindById(int id)
        {
            UserModel user = await _userRep.FindById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userRep.Add(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRep.Update(userModel, id);
            return Ok(user);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete (int id)
        {
            bool delete = await _userRep.Delete(id);
            return Ok(delete);   

        }

    }
}
