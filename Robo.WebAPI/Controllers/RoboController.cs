using Newtonsoft.Json;
using Robo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Robo.Web.Controllers
{
  public class RoboController : ApiController
  {
    private Domain.Robo _robo;

    public RoboController()
    {
      string path = Environment.CurrentDirectory;
      string roboJson = File.ReadAllText(@"C:\Projetos\Desafio Becomex\ROBO\Robo.WebAPI\robo.json");

      _robo = new Domain.Robo();
      _robo = JsonConvert.DeserializeObject<Domain.Robo>(roboJson);
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
        SalvarJson();
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
        SalvarJson();
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

        SalvarJson();
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
        SalvarJson();
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    private void SalvarJson()
    {
      TextWriter writer;
      using (writer = new StreamWriter(@"C:\Projetos\Desafio Becomex\ROBO\Robo.WebAPI\robo.json", append: false))
      {
        writer.WriteLine(JsonConvert.SerializeObject(_robo, new JsonSerializerSettings()
        {
          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }));
      }
    }
  }
}
