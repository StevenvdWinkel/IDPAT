using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    abstract class BaseFighterDecorater : IFighter
    {
        protected IFighter fighter;

        public BaseFighterDecorater(IFighter fighter)
        {
            this.fighter = fighter;
        }

        public int AttackValue
        {
            get
            {
                return fighter.AttackValue;
            }

            set
            {
                fighter.AttackValue = value;
            }
        }

        public int DefenseValue
        {
            get
            {
                return fighter.DefenseValue;
            }

            set
            {
                fighter.DefenseValue = value;
            }
        }

        public int Lives
        {
            get
            {
                return fighter.Lives;
            }

            set
            {
                fighter.Lives = value;
            }
        }

        public virtual Attack Attack()
        {
            return fighter.Attack();
        }

        public virtual void Defend(Attack attack)
        {
            fighter.Defend(attack);
        }
    }
}
