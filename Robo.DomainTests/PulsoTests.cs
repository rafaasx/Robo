using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robo.Domain;
using Robo.Domain.Enum;
using Robo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain.Tests
{
  [TestClass()]
  public class PulsoTests
  {
    [TestMethod()]
    public void PulsoTest()
    {
      Braco braco = new Braco(EnumLado.Direito);
      Assert.AreEqual(EnumRotacao.EmRepouso, braco.Pulso.Rotacao);
    }
    [TestMethod()]
    public void RotanionarPulsoCotoveloEmRepousoTest()
    {
      try
      {
        Braco braco = new Braco(EnumLado.Direito);
        braco.Pulso.Rotacionar(EnumRotacao.Rotacao45);
        Assert.Fail();
      }
      catch (Exception e)
      {
        Exception expected = new Exception("O cotovelo não está totalmente contraído.");
        Assert.AreEqual(expected.Message, e.Message);
      }

    }

    [TestMethod()]
    public void RotanionarPulsoCotoveloFortementeContraidoTest()
    {
      try
      {
        Braco braco = new Braco(EnumLado.Direito);
        braco.Cotovelo.Contrair(EnumContracao.LevementeContraido);
        braco.Cotovelo.Contrair(EnumContracao.Contraido);
        braco.Cotovelo.Contrair(EnumContracao.FortementeContraido);
        EnumRotacao expected = EnumRotacao.Rotacao45;
        braco.Pulso.Rotacionar(expected);        
        Assert.AreEqual(expected, braco.Pulso.Rotacao);
      }
      catch (Exception)
      {
        Assert.Fail();
      }

    }

    [TestMethod()]
    public void RotanionarPulsoCotoveloFortementeContraidoMovimentoInvalidoTest()
    {
      try
      {
        Braco braco = new Braco(EnumLado.Direito);
        braco.Cotovelo.Contrair(EnumContracao.LevementeContraido);
        braco.Cotovelo.Contrair(EnumContracao.Contraido);
        braco.Cotovelo.Contrair(EnumContracao.FortementeContraido);
        braco.Pulso.Rotacionar(EnumRotacao.Rotacao90);
      }
      catch (Exception e)
      {
        Exception expected = new Exception("Progressão da rotação do pulso inválida.");
        Assert.AreEqual(expected.Message, e.Message);
      }

    }

    [TestMethod()]
    public void RotanionarPulsoEmRepousoParaEmRepousoCotoveloFortementeContraidoMovimentoInvalidoTest()
    {
      try
      {
        Braco braco = new Braco(EnumLado.Direito);
        braco.Cotovelo.Contrair(EnumContracao.LevementeContraido);
        braco.Cotovelo.Contrair(EnumContracao.Contraido);
        braco.Cotovelo.Contrair(EnumContracao.FortementeContraido);
        braco.Pulso.Rotacionar(EnumRotacao.EmRepouso);
      }
      catch (Exception e)
      {
        Exception expected = new Exception("Progressão da rotação do pulso inválida.");
        Assert.AreEqual(expected.Message, e.Message);
      }

    }

  }
}