using Microsoft.AspNetCore.Mvc;
using UsersDot.Models;

namespace UsersDot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {   
        private readonly DataContext _datacontext;
        public UserController(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        private static List<User> users = new List<User>
        {
                
        };

        [HttpGet("GetAll")]

        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _datacontext.Users.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User usuario)
        {
            _datacontext.Users.Add(usuario);
            await _datacontext.SaveChangesAsync();

            return Ok(await _datacontext.Users.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task <ActionResult<User>> GetSingleUser(int id){

           var user = await _datacontext.Users.FirstOrDefaultAsync(x=>x.Id == id);

                if(user == null)
                    return BadRequest("No se Encontro Usuario");

                return Ok(user);


        }

         [HttpPut]

         public async Task<ActionResult<User>> UpdateUser(User usuario){
             var user = await _datacontext.Users.FirstOrDefaultAsync(x=>x.Id == usuario.Id);
                if(user == null)
                    return BadRequest("No se Encontro Usuario");

                user.Nombre = usuario.Nombre;
                user.Direccion = usuario.Direccion;
                user.Edad = usuario.Edad;
                user.CorreoElectronico = usuario.CorreoElectronico;

                await _datacontext.SaveChangesAsync();

                return Ok(await _datacontext.Users.ToListAsync());
         }

         [HttpDelete ("{id}")]

        public async Task<ActionResult<List<User>>> Get(int id)
        {
            var user = await _datacontext.Users.FirstOrDefaultAsync(x=>x.Id == id);
                if(user == null)
                    return BadRequest("No se Encontro Usuario");
            _datacontext.Users.Remove(user);
            await _datacontext.SaveChangesAsync();
            return Ok(await _datacontext.Users.ToListAsync());
        }

    }
}