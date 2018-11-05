using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class PoisonFighterDecorater : BaseFighterDecorater
    {
        public int PoisonStrength { get; set; }

        public PoisonFighterDecorater(IFighter fighter) : base(fighter)
        {
            PoisonStrength = 10;
        }

        public override Attack Attack()
        {
            Attack attack = base.Attack();
            if (PoisonStrength > 0)
            {
                attack.Messages.Add("Poison weakening, current value: " + PoisonStrength);
                attack.Value += PoisonStrength;
                PoisonStrength -= 2;
            }
            else
            {
                attack.Messages.Add("Poison ran out.");
            }
            return attack;
        }
    }
}
