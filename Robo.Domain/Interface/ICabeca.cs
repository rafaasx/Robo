using Robo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain.Interface
{
  public interface ICabeca
  {
    void Rotacionar(EnumRotacao rotacao);
    void Inclinar(EnumInclinacao inclinacao);
  }
}
