using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class StrengthenFighterDecorator : BaseFighterDecorater
    {
        public StrengthenFighterDecorator(IFighter fighter) : base(fighter)
        {
        }

        public override Attack Attack()
        {
            Attack attack = base.Attack();
            attack.Value = (int)((double)attack.Value * 1.10);
            attack.Messages.Add("Strengthen succes, 10% added to damage.");
            return attack;
        }

        public override void Defend(Attack attack)
        { 
            DefenseValue = (int)((double)DefenseValue * 1.10);
            attack.Messages.Add("Blocked 10% extra damage");
            base.Defend(attack);
        }
    }
}
