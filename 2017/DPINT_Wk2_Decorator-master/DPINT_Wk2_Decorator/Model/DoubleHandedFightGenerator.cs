using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class DoubleHandedFightGenerator : BaseFighterDecorater
    {

        public DoubleHandedFightGenerator(IFighter fighter) : base(fighter)
        {
            
        }

        public override Attack Attack()
        {
            Attack attack = base.Attack();
            attack.Value += AttackValue;
            attack.Messages.Add("Doubled the original attack value: " + AttackValue);
            return attack;
        }

        public override void Defend(Attack attack)
        {
            attack.Messages.Add("One hand defended the attack: -" + DefenseValue);
            attack.Value -= DefenseValue;
            base.Defend(attack);
        }
    }
}
