﻿using Robo.Domain.Enum;
using Robo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Domain
{
  public class Robo : RoboBase, IRobo
  {
    private Braco _bracoDireito;
    private Braco _bracoEsquerdo;
    private Cabeca _cabeca;
    public Robo()
    {
      BracoDireito = new Braco(EnumLado.Direito);
      BracoEsquerdo = new Braco(EnumLado.Esquerdo);
      Cabeca = new Cabeca();
    }

    public Braco BracoDireito { get => _bracoDireito; set => _bracoDireito = value; }
    public Braco BracoEsquerdo { get => _bracoEsquerdo; set => _bracoEsquerdo = value; }
    public Cabeca Cabeca { get => _cabeca; set => _cabeca = value; }
  }
}
