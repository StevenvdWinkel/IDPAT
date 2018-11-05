using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class ShieldFighterDecorater : BaseFighterDecorater
    {
        public int ShieldDefends { get; set; }

        public ShieldFighterDecorater(IFighter fighter) : base(fighter)
        {
            ShieldDefends = 3;
        }

        public override void Defend(Attack attack)
        {
            if (ShieldDefends > 0)
            {
                attack.Messages.Add("Shield protected, attack value = 0");
                attack.Value = 0;
                ShieldDefends--;
            }
            base.Defend(attack);
        }
    }
}
