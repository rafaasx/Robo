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
    private EnumContracao contracao;

    public EnumContracao Contracao { get => contracao; set => contracao = value; }
  }
}
