using Newtonsoft.Json;
using Robo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Robo.Web.Controllers
{
  public class RoboController : ApiController
  {
    private Domain.Robo _robo;

    public RoboController()
    {
      _robo = CarregarRobo();     
    }
    // GET: api/Robo1
    public IHttpActionResult Get()
    {
      return Ok(_robo);
    }

    //// GET: api/Robo1/5
    //public Domain.Robo Get(int id)
    //{
    //  Domain.Robo robo = new Domain.Robo();
    //  return robo;
    //}

    // POST: api/Robo1
    public void Post([FromBody]Domain.Robo robo)
    {
      _robo = robo;
    }

    // PUT: api/Robo1/5
    public void Put([FromBody]Domain.Robo robo)
    {
      _robo = robo;
    }

    // DELETE: api/Robo1/5
    public void Delete()
    {
      _robo = new Domain.Robo();
    }

    public IHttpActionResult RotacionarPulso(EnumRotacao rotacaoPulso, EnumLado lado)
    {
      try
      {
        if (lado == EnumLado.Direito)
          _robo.BracoDireito.Pulso.Rotacionar(rotacaoPulso);
        else
          _robo.BracoEsquerdo.Pulso.Rotacionar(rotacaoPulso);
        SalvarJson(_robo);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public IHttpActionResult RotacionarCabeca(EnumRotacao rotacaoCabeca)
    {
      try
      {
        _robo.Cabeca.Rotacionar(rotacaoCabeca);
        SalvarJson(_robo);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public IHttpActionResult Contrair(EnumContracao contracao, EnumLado lado)
    {
      try
      {
        if (lado == EnumLado.Direito)
          _robo.BracoDireito.Cotovelo.Contrair(contracao);
        else
          _robo.BracoEsquerdo.Cotovelo.Contrair(contracao);

        SalvarJson(_robo);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public IHttpActionResult Inclinar(EnumInclinacao inclinacao)
    {
      try
      {
        _robo.Cabeca.Inclinar(inclinacao);
        SalvarJson(_robo);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    private void SalvarJson(Domain.Robo robo)
    {
      TextWriter writer;
      using (writer = new StreamWriter(Path.Combine(HttpRuntime.AppDomainAppPath, "robo.json"), append: false))
      {
        writer.WriteLine(JsonConvert.SerializeObject(robo, new JsonSerializerSettings()
        {
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }));
      }
    }

    private Domain.Robo CarregarRobo()
    {
      Domain.Robo robo = new Domain.Robo();
      try
      {
        string jsonPath = Path.Combine(HttpRuntime.AppDomainAppPath, "robo.json");
        string roboJson = string.Empty;
        if (File.Exists(jsonPath))
          roboJson = File.ReadAllText(jsonPath);
        robo = new Domain.Robo();
        if (!string.IsNullOrEmpty(roboJson))
          robo = JsonConvert.DeserializeObject<Domain.Robo>(roboJson);
        else
        {
          robo.Nome = "Eu Robo";
          robo.Cabeca.Nome = "Cabeça";
          robo.BracoDireito.Nome = "Braco Direito";
          robo.BracoEsquerdo.Nome = "Braco Direito";
          robo.BracoDireito.Lado = EnumLado.Direito;
          robo.BracoEsquerdo.Lado = EnumLado.Esquerdo;
          SalvarJson(robo);
        }
        return robo;
      }
      catch (Exception)
      {
        return robo;
      }
      
    }
  }
}
