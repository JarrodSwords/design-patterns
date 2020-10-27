namespace DesignPatterns.FactoryMethod.Domain
{
    public class Mario
    {
        #region Public Interface

        public void Attack(Enemy enemy, int damage)
        {
            enemy.ReceiveDamage(damage);
        }

        #endregion
    }
}
