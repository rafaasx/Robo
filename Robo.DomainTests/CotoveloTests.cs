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
  public class CotoveloTests
  {
    [TestMethod()]
    public void CotoveloTest()
    {
      Cotovelo cotovelo = new Cotovelo();
      EnumContracao contracao = EnumContracao.EmRepouso;
      Assert.AreEqual(contracao, cotovelo.Contracao);
    }

    [TestMethod()]
    public void ContrairTest()
    {
      try
      {
        Cotovelo cotovelo = new Cotovelo();
        EnumContracao expected = EnumContracao.LevementeContraido;
        cotovelo.Contrair(expected);
        Assert.AreEqual(expected, cotovelo.Contracao);
      }
      catch (Exception)
      {
        Assert.Fail();

      }
    }

    [TestMethod()]
    public void ContrairProgressaoInvalidaTest()
    {
      try
      {
        Cotovelo cotovelo = new Cotovelo();
        cotovelo.Contrair(EnumContracao.FortementeContraido);
        Assert.Fail();
      }
      catch (Exception e)
      {
        Exception expected = new Exception("Progressão da contração do cotovelo inválida.");
        Assert.AreEqual(expected.Message, e.Message);

      }
    }
  }
}