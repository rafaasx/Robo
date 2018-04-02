using Robo.Domain.Enum;
using Robo.Domain.Interface;
using System;
using System.Diagnostics;

namespace Robo.Domain
{
  public class Cabeca : CabecaBase, ICabeca
  {
    public Cabeca()
    {
      Rotacao = EnumRotacao.EmRepouso;
      Inclinacao = EnumInclinacao.EmRepouso;
    }
    public void Inclinar(EnumInclinacao inclinacao)
    {
      if (ValidarInclinacao(inclinacao))
      {
        Debug.WriteLine("Inclinando de " + Inclinacao.ToString() + " para " + inclinacao.ToString());
        Inclinacao = inclinacao;
      }
    }

    private bool ValidarInclinacao(EnumInclinacao inclinacao)
    {
      if (Math.Abs(Inclinacao - inclinacao) != 1)
        throw new Exception("Progressão de inclinacao da cabeça inválida.");
      return true;
    }

    public void Rotacionar(EnumRotacao rotacao)
    {
      if (ValidarMovimento(rotacao))
      {
        Debug.WriteLine("Rotacionando de " + Rotacao.ToString() + " para " + rotacao.ToString());
        Rotacao = rotacao;
      }
    }

    private bool ValidarMovimento(EnumRotacao rotacao)
    {
      if (rotacao > EnumRotacao.Rotacao90)
        throw new Exception("Movimento de rotação da cabeça não permitida.");
      return ValidarProgressaoMovimento(rotacao);
    }

    private bool ValidarProgressaoMovimento(EnumRotacao rotacao)
    {
      if (Math.Abs(Rotacao - rotacao) != 1)
        throw new Exception("Progressão da rotação da cabeça inválida.");
      return ValidarPosicaoInclinacao();
    }

    private bool ValidarPosicaoInclinacao()
    {
      if (Inclinacao == EnumInclinacao.ParaBaixo)
        throw new Exception("Não é permitido rotacionar com a cabeça para baixo.");
      return true;
    }
  }
}
