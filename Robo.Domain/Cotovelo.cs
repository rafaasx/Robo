using Robo.Domain.Enum;
using Robo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain
{
  public class Cotovelo : CotoveloBase, ICotovelo
  {
    public Cotovelo()
    {
      _contracao = EnumContracao.EmRepouso;
    }
    public void Contrair(EnumContracao contracao)
    {
      if (ValidarProgressaoMovimento(contracao))
      {
        Debug.WriteLine("Contraindo de " + Contracao.ToString() + " para " + contracao.ToString());
        _contracao = contracao;
      }
    }

    private bool ValidarProgressaoMovimento(EnumContracao contracao)
    {
      if (Math.Abs(Contracao - contracao) != 1)
        throw new Exception("Progressão da contração do cotovelo inválida.");
      return true;
    }
  }
}
