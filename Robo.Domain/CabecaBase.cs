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
    public string Nome { get; set; }
    private EnumRotacao rotacao;
    private EnumInclinacao inclinacao;

    public EnumInclinacao Inclinacao { get => inclinacao; set => inclinacao = value; }
    public EnumRotacao Rotacao { get => rotacao; set => rotacao = value; }
  }
}
