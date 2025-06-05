using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("mi-proyecto")]
public class MiProyectoController: ControllerBase {
    [HttpGet("Integrantes")]
    public ActionResult<MiProyecto> Integrantes()
    {
        var proyecto = new MiProyecto
        {
            Integrante1 = "Nayeli Meza Sanchez",
            Integrante2 = "Frida Sofia Mejia Hernandez" 
        };

        return Ok(proyecto);
    }

    [HttpGet("presentacion")]
    public IActionResult Presentacion(){
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Escuela_Nayeli_Frida");
        var collection = db.GetCollection<Equipo>("Equipo");

        var list = collection.Find(FilterDefinition<Equipo>.Empty).ToList();
        return Ok(list);
    }
}