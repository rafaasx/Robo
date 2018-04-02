using Robo.Domain.Enum;
using Robo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain
{
  public class PulsoBase
  {
    internal PulsoBase(Braco braco)
    {
      _braco = braco;
    }
    private Braco _braco;
    private EnumRotacao rotacao;
    public Braco Braco { get => _braco; set => _braco = value; }
    public EnumRotacao Rotacao { get => rotacao; set => rotacao = value; }
  }
}
