using Robo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain
{
  public class RoboBase : IRobo
  {
    public string Name { get; set; }
  }
}
