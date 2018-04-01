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
    internal EnumRotacao _rotacao;
    public EnumRotacao Rotacao { get => _rotacao; }
    public Braco Braco { get => _braco; set => _braco = value; }
  }
}
