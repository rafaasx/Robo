using Robo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Robo.Web.Controllers
{
  public class RoboController : ApiController
  {
    private Domain.Robo _robo;

    public RoboController()
    {
      _robo = new Domain.Robo();
      _robo.BracoDireito.Name = "Braço Direito";
      _robo.BracoEsquerdo.Name = "Braço Esquerdo";
      _robo.Cabecao.Name = "Cabeça";
      _robo.Name = "Eu Robo";
    }
    // GET: api/Robo1
    public Domain.Robo Index()
    {
      return _robo;
    }

    // GET: api/Robo1
    public Domain.Robo Get()
    {
      return _robo;
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

    public void Rotacionar(EnumRotacao rotacao)
    {
      try
      {
        _robo.BracoDireito.Pulso.Rotacionar(rotacao);
        Ok();
      }
      catch (Exception e)
      {
        BadRequest(e.Message);
      }
    }
  }
}
