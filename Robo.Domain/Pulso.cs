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
  public class Pulso : PulsoBase, IPulso
  {
    public Pulso(Braco braco) : base(braco)
    {
      Rotacao = EnumRotacao.EmRepouso;
    }

    public void Rotacionar(EnumRotacao rotacao)
    {
      if (ValidarMovimento(this.Braco.Cotovelo.Contracao, rotacao))
      {
        Debug.WriteLine("Rotacionando de " + Rotacao.ToString() + " para " + rotacao.ToString());
        Rotacao = rotacao;
      }
    }

    private bool ValidarMovimento(EnumContracao contracao, EnumRotacao rotacao)
    {
      if (contracao != EnumContracao.FortementeContraido)
        throw new Exception("O cotovelo não está totalmente contraído.");
      return ValidarRotacao(rotacao);
    }

    private bool ValidarRotacao(EnumRotacao rotacao)
    {
      if (Math.Abs(Rotacao - rotacao) == 1)
        return true;
      throw new Exception("Progressão da rotação do pulso inválida.");
    }
  }
}
