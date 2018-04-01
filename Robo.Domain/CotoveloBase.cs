using Robo.Domain.Enum;
using Robo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain
{
  public abstract class CotoveloBase
  {
    internal EnumContracao _contracao;

    public EnumContracao Contracao { get => _contracao; }
  }
}
