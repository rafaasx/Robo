using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robo.Domain;
using Robo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain.Tests
{
  [TestClass()]
  public class CabecaTests
  {
    [TestMethod()]
    public void CabecaTest()
    {
      Cabeca cabeca = new Cabeca();
      Assert.AreEqual(EnumInclinacao.EmRepouso, cabeca.Inclinacao);
      Assert.AreEqual(EnumRotacao.EmRepouso, cabeca.Rotacao);
    }
    [TestMethod()]
    public void RotacionarTest()
    {
      try
      {
        Cabeca cabeca = new Cabeca();
        EnumRotacao expected = EnumRotacao.Rotacao45;
        cabeca.Rotacionar(expected);
        Assert.AreEqual(expected, cabeca.Rotacao);

      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }

    [TestMethod()]
    public void RotacionarProgressaoInvalidaTest()
    {
      try
      {
        Cabeca cabeca = new Cabeca();
        cabeca.Rotacionar(EnumRotacao.Rotacao90);
        Assert.Fail();
      }
      catch (Exception e)
      {
        Exception expected = new Exception("Progressão da rotação da cabeça inválida.");
        Assert.AreEqual(expected.Message, e.Message);
      }
    }

    [TestMethod()]
    public void RotacionarMovimentoInvalidaTest()
    {
      try
      {
        Cabeca cabeca = new Cabeca();
        cabeca.Rotacionar(EnumRotacao.Rotacao180);
        Assert.Fail();

      }
      catch (Exception e)
      {
        Exception expected = new Exception("Movimento de rotação da cabeça não permitida.");
        Assert.AreEqual(expected.Message, e.Message);

      }
    }

    [TestMethod()]
    public void RotacionarComInclinacaoParaBaixoTest()
    {
      try
      {
        Cabeca cabeca = new Cabeca();
        cabeca.Inclinar(EnumInclinacao.ParaBaixo);
        cabeca.Rotacionar(EnumRotacao.Rotacao45);
        Assert.Fail();

      }
      catch (Exception e)
      {
        Exception expected = new Exception("Não é permitido rotacionar com a cabeça para baixo.");
        Assert.AreEqual(expected.Message, e.Message);

      }
    }

    [TestMethod()]
    public void InclinarTest()
    {
      try
      {
        Cabeca cabeca = new Cabeca();
        EnumInclinacao expected = EnumInclinacao.ParaBaixo;
        cabeca.Inclinar(expected);
        Assert.AreEqual(expected, cabeca.Inclinacao);

      }
      catch (Exception)
      {
        Assert.Fail();

      }
    }

    [TestMethod()]
    public void InclinarProgressaoMovimentoInvalidaTest()
    {
      try
      {
        Cabeca cabeca = new Cabeca();
        cabeca.Inclinar(EnumInclinacao.ParaCima);
        cabeca.Inclinar(EnumInclinacao.ParaBaixo);
        Assert.Fail();

      }
      catch (Exception e)
      {
        Exception expected = new Exception("Progressão de inclinação da cabeça inválida.");
        Assert.AreEqual(expected.Message, e.Message);

      }
    }
  }
}