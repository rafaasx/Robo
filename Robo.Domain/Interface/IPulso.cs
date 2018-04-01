using Robo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain.Interface
{
  public interface IPulso
  {
    void Rotacionar(EnumRotacao rotacao);
  }
}
