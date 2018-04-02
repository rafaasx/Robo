using Robo.Domain.Enum;
using Robo.Domain.Interface;

namespace Robo.Domain
{
  public class Braco : BracoBase, IBraco
  {
    private EnumLado _lado;
    private Cotovelo _cotovelo;
    private Pulso _pulso;

    public EnumLado Lado { get => _lado; set => _lado = value; }
    public Cotovelo Cotovelo { get => _cotovelo; set => _cotovelo = value; }
    public Pulso Pulso { get => _pulso; set => _pulso = value; }

    public Braco(EnumLado lado)
    {
      _lado = lado;
      _cotovelo = new Cotovelo();
      _pulso = new Pulso(this);
    }
  }
}