using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("mi-proyecto")]
public class MiProyectoController: ControllerBase
 {
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
    public IActionResult Presentacion()
    {

        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var database = client.GetDatabase("Escuela_Nayeli_Frida");
        var collection = database.GetCollection<Equipo>("Equipo");

        var filter =FilterDefinition<Equipo>.Empty;
        var item = collection.Find(filter).FirstOrDefault();
        return Ok(item);
    }
}