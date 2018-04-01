using Robo.Domain.Enum;
using Robo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain
{
  public class CabecaBase
  {
    public string Name { get; set; }
    internal EnumRotacao _rotacao;
    internal EnumInclinacao _inclinacao;

    public EnumRotacao Rotacao { get => _rotacao; }
    public EnumInclinacao Inclinacao { get => _inclinacao; }
  }
}
