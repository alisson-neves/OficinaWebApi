using Microsoft.AspNetCore.Mvc;

namespace OficinaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        static List<string> funcionarios = new List<string>();

        public DbContexto context { get; set; }

        public FuncionarioController(DbContexto dbContext) 
        { 
            context = dbContext;
        }

        [HttpGet]
        public ActionResult Get() 
        {
            //return Ok(funcionarios.ToList());
            return Ok(context.Employee.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var funcionario = context.Employee.FirstOrDefault(x => x.Id == id);

            if (funcionario == null)
            {
                return BadRequest("Usuário não encontrado.");
            }
            //return Ok(funcionarios.ToList());
            return Ok(funcionario);
        }

        [HttpPost]
        public ActionResult Post(Employee funcionario)
        {
            
            context.Employee.Add(funcionario);
            context.SaveChanges();
           // funcionarios.Add(funcionario);
            return Ok("Funcionário adicionado com sucesso!");
        }

        [HttpPut]
        public ActionResult Put(string nome)
        {
            var funcionario = funcionarios.FirstOrDefault(x => x == nome);
            if (funcionario == null)
            {
                return BadRequest("Funcionário não encontrado.");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var funcionario = context.Employee.FirstOrDefault(x => x.Id == id);

            if (funcionario == null) 
            {
                return BadRequest("Usuário não encontrado.");
            }

            context.Employee.Remove(funcionario);
            context.SaveChanges();
            return Ok("Funcionário removido!");
        }

    }
}
